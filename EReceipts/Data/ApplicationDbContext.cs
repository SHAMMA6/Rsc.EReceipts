using EReceipts.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EReceipts.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<ItemData> ItemData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Receipt>(builder =>
            {
                builder.HasKey(r => r.Id);
                builder.OwnsOne(r => r.Header);
                builder.OwnsOne(r => r.DocumentType);
                builder.OwnsOne(r => r.Seller, sellerBuilder =>
                {
                    sellerBuilder.OwnsOne(s => s.BranchAddress);
                });
                builder.OwnsOne(r => r.Buyer);
                builder.OwnsOne(r => r.Contractor);
                builder.OwnsOne(r => r.Beneficiary);

                builder.OwnsMany(r => r.ExtraReceiptDiscountData, discountBuilder =>
                {
                    discountBuilder.ToJson();
                });

                builder.OwnsMany(r => r.TaxTotals, taxTotalBuilder =>
                {
                    taxTotalBuilder.ToJson();
                });


                builder.HasMany(r => r.ItemData)
                       .WithOne()
                       .HasForeignKey("ReceiptId")
                       .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ItemData>(builder =>
            {
                builder.HasKey(i => i.InternalCode);

                builder.OwnsMany(i => i.CommercialDiscountData, discountBuilder =>
                {
                    discountBuilder.ToJson();
                });

                builder.OwnsMany(i => i.ItemDiscountData, discountBuilder =>
                {
                    discountBuilder.ToJson();
                });

                builder.OwnsOne(i => i.AdditionalCommercialDiscount);
                builder.OwnsOne(i => i.AdditionalItemDiscount);

                builder.OwnsMany(i => i.TaxableItems, taxableItemBuilder =>
                {
                    taxableItemBuilder.ToJson();
                });

            });
        } 
    }
}
