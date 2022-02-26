namespace Eurus.Customer.Domain.ValueObjects;

public record Identification(string LegalName, string Nic, DateOnly Dob);