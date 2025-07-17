using System.ComponentModel.DataAnnotations;

namespace EReceipts.Domain.ValueObjects;

public class DocumentType
{
    [Required(ErrorMessage = "ReceiptType is mandatory.")]
    [StringLength(20, ErrorMessage = "ReceiptType cannot exceed 20 characters.")]
    [RegularExpression("^S$", ErrorMessage = "ReceiptType must be 'S' for Sale Receipt.")]
    public string ReceiptType { get; set; }

    [Required(ErrorMessage = "TypeVersion is mandatory.")]
    [StringLength(100, ErrorMessage = "TypeVersion cannot exceed 100 characters.")]
    [RegularExpression("^1\\.2$", ErrorMessage = "TypeVersion must be '1.2'.")]
    public string TypeVersion { get; set; }
}


