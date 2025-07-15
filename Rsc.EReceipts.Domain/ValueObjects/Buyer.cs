namespace Rsc.EReceipts.Domain.ValueObjects;

public record Buyer(
    string Type,
    string Id,
    string Name,
    string MobileNumber,
    string PaymentNumber
);

