namespace Rsc.EReceipts.Domain.ValueObjects;

public record TaxableItem(string TaxType, decimal Amount, string SubType, decimal Rate);

