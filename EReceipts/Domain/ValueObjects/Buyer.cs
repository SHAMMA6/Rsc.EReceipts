using System.ComponentModel.DataAnnotations;

namespace EReceipts.Domain.ValueObjects;

public class Buyer
{
    [Required(ErrorMessage = "Buyer Type is mandatory.")]
    [StringLength(1, ErrorMessage = "Buyer Type must be 1 character.")]
    [RegularExpression("^[BPF]$", ErrorMessage = "Buyer Type must be 'B', 'P', or 'F'.")]
    public string Type { get; set; }

    [StringLength(30, ErrorMessage = "ID cannot exceed 30 characters.")]
    public string Id { get; set; }

    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; }

    [StringLength(30, ErrorMessage = "MobileNumber cannot exceed 30 characters.")]
    public string MobileNumber { get; set; }

    [StringLength(30, ErrorMessage = "PaymentNumber cannot exceed 30 characters.")]
    public string PaymentNumber { get; set; }
}

