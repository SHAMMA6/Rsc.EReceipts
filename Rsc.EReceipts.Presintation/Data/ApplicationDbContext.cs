using Microsoft.EntityFrameworkCore;
using Rsc.EReceipts.Domain.Models;
using Rsc.EReceipts.Domain.ValueObjects;

namespace Rsc.EReceipts.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ItemData> ItemData { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Receipt>(builder =>
            {
                
                builder.HasKey(r => r.Id);

                builder.Property(r => r.ReceiptNumber).IsRequired();
                builder.Property(r => r.Uuid).IsRequired(); 
                builder.Property(r => r.PreviousUuid).IsRequired(); 
                builder.Property(r => r.ReferenceOldUuid); 

                builder.OwnsOne(r => r.Header, headerBuilder =>
                {
                    headerBuilder.Property(h => h.DateTimeIssued).IsRequired();
                    headerBuilder.Property(h => h.ReceiptNumber).IsRequired();
                    headerBuilder.Property(h => h.Uuid).IsRequired();
                    headerBuilder.Property(h => h.PreviousUuid).IsRequired();
                    headerBuilder.Property(h => h.Currency).IsRequired();
                    headerBuilder.Property(h => h.ExchangeRate).HasPrecision(18, 5); 
                });

                builder.OwnsOne(r => r.DocumentType, dtBuilder =>
                {
                    dtBuilder.Property(dt => dt.ReceiptType).IsRequired();
                    dtBuilder.Property(dt => dt.TypeVersion).IsRequired();
                });

                builder.OwnsOne(r => r.Seller, sellerBuilder =>
                {
                    sellerBuilder.Property(s => s.Rin).IsRequired();
                    sellerBuilder.Property(s => s.CompanyTradeName).IsRequired();
                    sellerBuilder.Property(s => s.BranchCode).IsRequired();
                    sellerBuilder.Property(s => s.DeviceSerialNumber).IsRequired();
                    sellerBuilder.Property(s => s.ActivityCode).IsRequired();

                    sellerBuilder.OwnsOne(s => s.BranchAddress, addressBuilder =>
                    {
                        addressBuilder.Property(a => a.Country).IsRequired();
                        addressBuilder.Property(a => a.Governate).IsRequired();
                        addressBuilder.Property(a => a.RegionCity).IsRequired();
                        addressBuilder.Property(a => a.Street).IsRequired();
                        addressBuilder.Property(a => a.BuildingNumber).IsRequired();
                    });
                });

                builder.OwnsOne(r => r.Buyer, buyerBuilder =>
                {
                    buyerBuilder.Property(b => b.Type).IsRequired();
                });

                builder.OwnsOne(r => r.Contractor, contractorBuilder =>
                {
                    
                    contractorBuilder.Property(c => c.Amount).HasPrecision(18, 5);
                    contractorBuilder.Property(c => c.Rate).HasPrecision(18, 5);
                });

                
                builder.OwnsOne(r => r.Beneficiary, beneficiaryBuilder =>
                {
                    
                    beneficiaryBuilder.Property(b => b.Amount).HasPrecision(18, 5);
                    beneficiaryBuilder.Property(b => b.Rate).HasPrecision(18, 5);
                });


                builder.Property(r => r.TotalSales).HasPrecision(18, 5);
                builder.Property(r => r.TotalCommercialDiscount).HasPrecision(18, 5);
                builder.Property(r => r.TotalItemsDiscount).HasPrecision(18, 5);
                builder.Property(r => r.NetAmount).HasPrecision(18, 5);
                builder.Property(r => r.FeesAmount).HasPrecision(18, 5);
                builder.Property(r => r.TotalAmount).HasPrecision(18, 5);
                builder.Property(r => r.Adjustment).HasPrecision(18, 5);
                builder.Property(r => r.PaymentMethod).IsRequired();
            });

            modelBuilder.Entity<ItemData>(builder =>
            {
              
                builder.HasKey(i => i.InternalCode); 

                builder.Property(i => i.Description).IsRequired();
                builder.Property(i => i.ItemType).IsRequired();
                builder.Property(i => i.ItemCode).IsRequired();
                builder.Property(i => i.UnitType).IsRequired();
                builder.Property(i => i.Quantity).IsRequired();

                builder.Property(i => i.UnitPrice).HasPrecision(18, 5);
                builder.Property(i => i.NetSale).HasPrecision(18, 5);
                builder.Property(i => i.TotalSale).HasPrecision(18, 5);
            });
        }
    }
}
