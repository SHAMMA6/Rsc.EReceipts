using Microsoft.EntityFrameworkCore;
using Rsc.EReceipts.Domain.Models;
using Rsc.EReceipts.Domain.ValueObjects;

namespace Rsc.EReceipts.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        // DbSet for the Aggregate Root
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ItemData> ItemData { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- Configure Receipt Aggregate Root ---
            modelBuilder.Entity<Receipt>(builder =>
            {
                // Primary Key for the Aggregate Root
                builder.HasKey(r => r.Id);

                // Map private fields for properties with private setters
                builder.Property(r => r.ReceiptNumber).IsRequired();
                builder.Property(r => r.Uuid).IsRequired(); // PDF states Mandatory
                builder.Property(r => r.PreviousUuid).IsRequired(); // PDF states Mandatory
                builder.Property(r => r.ReferenceOldUuid); // Optional

                // Configure Value Objects as Owned Entity Types
                // Header Value Object
                builder.OwnsOne(r => r.Header, headerBuilder =>
                {
                    headerBuilder.Property(h => h.DateTimeIssued).IsRequired();
                    headerBuilder.Property(h => h.ReceiptNumber).IsRequired();
                    headerBuilder.Property(h => h.Uuid).IsRequired();
                    headerBuilder.Property(h => h.PreviousUuid).IsRequired();
                    headerBuilder.Property(h => h.Currency).IsRequired();
                    headerBuilder.Property(h => h.ExchangeRate).HasPrecision(18, 5); // Example precision
                    // Other properties are optional in the constructor, so no .IsRequired() unless specified
                });

                // DocumentType Value Object
                builder.OwnsOne(r => r.DocumentType, dtBuilder =>
                {
                    dtBuilder.Property(dt => dt.ReceiptType).IsRequired();
                    dtBuilder.Property(dt => dt.TypeVersion).IsRequired();
                });

                // Seller Value Object
                builder.OwnsOne(r => r.Seller, sellerBuilder =>
                {
                    sellerBuilder.Property(s => s.Rin).IsRequired();
                    sellerBuilder.Property(s => s.CompanyTradeName).IsRequired();
                    sellerBuilder.Property(s => s.BranchCode).IsRequired();
                    sellerBuilder.Property(s => s.DeviceSerialNumber).IsRequired();
                    sellerBuilder.Property(s => s.ActivityCode).IsRequired();
                    // SyndicateLicenseNumber is optional in constructor

                    // BranchAddress (nested Value Object within Seller)
                    sellerBuilder.OwnsOne(s => s.BranchAddress, addressBuilder =>
                    {
                        addressBuilder.Property(a => a.Country).IsRequired();
                        addressBuilder.Property(a => a.Governate).IsRequired();
                        addressBuilder.Property(a => a.RegionCity).IsRequired();
                        addressBuilder.Property(a => a.Street).IsRequired();
                        addressBuilder.Property(a => a.BuildingNumber).IsRequired();
                        // Other address properties are optional in constructor
                    });
                });

                // Buyer Value Object
                builder.OwnsOne(r => r.Buyer, buyerBuilder =>
                {
                    buyerBuilder.Property(b => b.Type).IsRequired();
                    // Id, Name, MobileNumber, PaymentNumber are optional in constructor
                });

                // Contractor Value Object (Optional)
                builder.OwnsOne(r => r.Contractor, contractorBuilder =>
                {
                    // No IsRequired() as Contractor itself is optional in Receipt
                    contractorBuilder.Property(c => c.Amount).HasPrecision(18, 5);
                    contractorBuilder.Property(c => c.Rate).HasPrecision(18, 5);
                });

                // Beneficiary Value Object (Optional)
                builder.OwnsOne(r => r.Beneficiary, beneficiaryBuilder =>
                {
                    // No IsRequired() as Beneficiary itself is optional in Receipt
                    beneficiaryBuilder.Property(b => b.Amount).HasPrecision(18, 5);
                    beneficiaryBuilder.Property(b => b.Rate).HasPrecision(18, 5);
                });

                // Map collections of Value Objects
                // ExtraReceiptDiscountData (Collection of owned entities)
                builder.OwnsMany(r => r.ExtraReceiptDiscountData, discountBuilder =>
                {
                    discountBuilder.ToJson(); // Store as JSON column (EF Core 7+)
                    // If using older EF Core or prefer separate table:
                    // discountBuilder.HasKey("Id"); // Need a shadow property or actual Id for key
                    // discountBuilder.WithOwner().HasForeignKey("ReceiptId"); // Foreign key to Receipt
                    // discountBuilder.Property(d => d.Amount).HasPrecision(18, 5);
                    // discountBuilder.Property(d => d.Description).IsRequired();
                    // discountBuilder.Property(d => d.Rate).HasPrecision(18, 5);
                    // discountBuilder.ToTable("ExtraReceiptDiscounts");
                });

                // TaxTotals (Collection of owned entities)
                builder.OwnsMany(r => r.TaxTotals, taxTotalBuilder =>
                {
                    taxTotalBuilder.ToJson(); // Store as JSON column (EF Core 7+)
                    // If using older EF Core or prefer separate table:
                    // taxTotalBuilder.HasKey("Id"); // Need a shadow property or actual Id for key
                    // taxTotalBuilder.WithOwner().HasForeignKey("ReceiptId"); // Foreign key to Receipt
                    // taxTotalBuilder.Property(tt => tt.TaxType).IsRequired();
                    // taxTotalBuilder.Property(tt => tt.Amount).HasPrecision(18, 5);
                    // taxTotalBuilder.ToTable("ReceiptTaxTotals");
                });


                // Map other properties with precision for decimal types
                builder.Property(r => r.TotalSales).HasPrecision(18, 5);
                builder.Property(r => r.TotalCommercialDiscount).HasPrecision(18, 5);
                builder.Property(r => r.TotalItemsDiscount).HasPrecision(18, 5);
                builder.Property(r => r.NetAmount).HasPrecision(18, 5);
                builder.Property(r => r.FeesAmount).HasPrecision(18, 5);
                builder.Property(r => r.TotalAmount).HasPrecision(18, 5);
                builder.Property(r => r.Adjustment).HasPrecision(18, 5);
                builder.Property(r => r.PaymentMethod).IsRequired();

                // Configure the relationship with ItemData
                // Receipt has many ItemData, and ItemData belongs to one Receipt
                builder.HasMany(r => r.ItemData)
                       .WithOne() // ItemData does not have a navigation property back to Receipt
                       .HasForeignKey("ReceiptId") // Shadow property for FK
                       .OnDelete(DeleteBehavior.Cascade); // If Receipt is deleted, ItemData is also deleted
            });

            // --- Configure ItemData Entity ---
            modelBuilder.Entity<ItemData>(builder =>
            {
                // ItemData has its own identity (InternalCode within the Receipt aggregate)
                // We can use a composite key if InternalCode + ReceiptId makes it unique,
                // or add a separate Guid Id for persistence if InternalCode isn't globally unique.
                // For simplicity and to match the model, let's assume InternalCode is unique per Receipt.
                // A better approach might be to add a Guid Id to ItemData for primary key.
                builder.HasKey(i => i.InternalCode); // This assumes InternalCode is unique globally or handled by composite key

                // If InternalCode is only unique within a Receipt, you'd make a composite key:
                // builder.HasKey("ReceiptId", i => i.InternalCode);
                // And ensure the "ReceiptId" shadow property is configured.

                builder.Property(i => i.Description).IsRequired();
                builder.Property(i => i.ItemType).IsRequired();
                builder.Property(i => i.ItemCode).IsRequired();
                builder.Property(i => i.UnitType).IsRequired();
                builder.Property(i => i.Quantity).IsRequired();

                // Map decimal properties with precision
                builder.Property(i => i.UnitPrice).HasPrecision(18, 5);
                builder.Property(i => i.NetSale).HasPrecision(18, 5);
                builder.Property(i => i.TotalSale).HasPrecision(18, 5);
                builder.Property(i => i.Total).HasPrecision(18, 5);
                builder.Property(i => i.ValueDifference).HasPrecision(18, 5);

                // Configure collections of Value Objects within ItemData
                builder.OwnsMany(i => i.CommercialDiscountData, discountBuilder =>
                {
                    discountBuilder.ToJson(); // Store as JSON column (EF Core 7+)
                    // If using older EF Core or prefer separate table:
                    // discountBuilder.HasKey("Id");
                    // discountBuilder.WithOwner().HasForeignKey("ItemDataInternalCode");
                    // discountBuilder.ToTable("ItemCommercialDiscounts");
                });

                builder.OwnsMany(i => i.ItemDiscountData, discountBuilder =>
                {
                    discountBuilder.ToJson(); // Store as JSON column (EF Core 7+)
                    // If using older EF Core or prefer separate table:
                    // discountBuilder.HasKey("Id");
                    // discountBuilder.WithOwner().HasForeignKey("ItemDataInternalCode");
                    // discountBuilder.ToTable("ItemItemDiscounts");
                });

                builder.OwnsOne(i => i.AdditionalCommercialDiscount, discountBuilder =>
                {
                    discountBuilder.Property(d => d.Amount).HasPrecision(18, 5);
                    discountBuilder.Property(d => d.Rate).HasPrecision(18, 5);
                });

                builder.OwnsOne(i => i.AdditionalItemDiscount, discountBuilder =>
                {
                    discountBuilder.Property(d => d.Amount).HasPrecision(18, 5);
                    discountBuilder.Property(d => d.Rate).HasPrecision(18, 5);
                });

                builder.OwnsMany(i => i.TaxableItems, taxableItemBuilder =>
                {
                    taxableItemBuilder.ToJson(); 
                });
            });
        }
    }
}
