using Rsc.EReceipts.Domain.StaticData;

namespace Rsc.EReceipts.Presintation.Enums;

public class Seller
{
    public string Rin { get; set; } = SD.Rin;
    public string CompanyTradeName { get; set; } = SD.CompanyTradeName;
    public string BranchCode { get; set; } = SD.BranchCode;
    public BranchAddress BranchAddress { get; set; } = new BranchAddress();
    public string DeviceSerialNumber { get; set; } = SD.DeviceSerialNumber;
    public string SyndicateLicenseNumber { get; set; } = SD.SyndicateLicenseNumber;
    public string ActivityCode { get; set; } = SD.ActivityCode;

}

