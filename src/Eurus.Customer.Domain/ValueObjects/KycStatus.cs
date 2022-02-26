namespace Eurus.Customer.Domain.ValueObjects;

public record KycStatus(bool IsApproved, string? Reason);