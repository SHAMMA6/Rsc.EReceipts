using Rsc.EReceipts.Domain.StaticData;

namespace Rsc.EReceipts.Domain.Enums;

public class BranchAddress
{
    public string Country { get; set; } = SD.Country;
    public string Governate { get; set; } = SD.Governate;
    public string RegionCity { get; set; } = SD.RegionCity;
    public string Street { get; set; } = SD.Street;
    public string BuildingNumber { get; set; } = SD.BuildingNumber;
    public string PostalCode { get; set; } = SD.PostalCode;
    public string Floor { get; set; } = SD.Floor;
    public string Room { get; set; } = SD.Room;
    public string Landmark { get; set; } = SD.Landmark;
    public string AdditionalInformation { get; set; } = SD.AdditionalInformation;
}


