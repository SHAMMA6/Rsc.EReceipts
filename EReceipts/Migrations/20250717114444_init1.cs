using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EReceipts.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Uuid = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PreviousUuid = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ReferenceOldUuid = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Header_DateTimeIssued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Header_ReceiptNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Header_Uuid = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Header_PreviousUuid = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Header_ReferenceOldUuid = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Header_Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Header_ExchangeRate = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    Header_SOrderNameCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Header_OrderDeliveryMode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Header_GrossWeight = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    Header_NetWeight = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    DocumentType_ReceiptType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DocumentType_TypeVersion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Seller_Rin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_CompanyTradeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_BranchAddress_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_BranchAddress_Governate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_BranchAddress_RegionCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_BranchAddress_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_BranchAddress_BuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_BranchAddress_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_BranchAddress_Floor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_BranchAddress_Room = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_BranchAddress_Landmark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_BranchAddress_AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_DeviceSerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_SyndicateLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller_ActivityCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Buyer_Type = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Buyer_Id = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Buyer_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Buyer_MobileNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Buyer_PaymentNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TotalSales = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    TotalCommercialDiscount = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    TotalItemsDiscount = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    FeesAmount = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adjustment = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    Contractor_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Contractor_Amount = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    Contractor_Rate = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    Beneficiary_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Beneficiary_Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExtraReceiptDiscountData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxTotals = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemData",
                columns: table => new
                {
                    InternalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UnitType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    NetSale = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    TotalSale = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    AdditionalCommercialDiscount_Amount = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    AdditionalCommercialDiscount_Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdditionalCommercialDiscount_Rate = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    AdditionalItemDiscount_Amount = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    AdditionalItemDiscount_Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdditionalItemDiscount_Rate = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    ValueDifference = table.Column<decimal>(type: "decimal(18,5)", precision: 18, scale: 5, nullable: false),
                    ReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CommercialDiscountData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDiscountData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxableItems = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemData", x => x.InternalCode);
                    table.ForeignKey(
                        name: "FK_ItemData_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemData_ReceiptId",
                table: "ItemData",
                column: "ReceiptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemData");

            migrationBuilder.DropTable(
                name: "Receipts");
        }
    }
}
