using Eurus.Common.Domain;
using Eurus.Common.Domain.Enums;
using Eurus.Common.Domain.Identifiers;
using Eurus.Customer.Domain.ValueObjects;

namespace Eurus.Customer.Domain.Aggregates;

public partial class Customer : Aggregate<CustomerId, Guid>
{
    public override Guid AggregateId => Id.Value;
    public Dictionary<KycLevel, KycStatus> KycLevels { get; private set; }
    
    public string Email { get; private set; }
    public bool EmailConfirmed { get; private set; }

    public string? PhoneNumber { get; private set; } = default!;
    public bool PhoneNumberConfirmed { get; private set; }
    
    public string PasswordHash { get; private set; }
    
    public DateTime Registered { get; private set; }    
    public bool Suspended { get; private set; }


    private Customer() {}

    private Customer(CustomerId id, Dictionary<KycLevel, KycStatus> kycLevels, string email, bool emailConfirmed, string? phoneNumber, bool phoneNumberConfirmed, string passwordHash, DateTime registered, bool suspended)
    {
        Id = id;
        KycLevels = kycLevels;
        Email = email;
        EmailConfirmed = emailConfirmed;
        PhoneNumber = phoneNumber;
        PhoneNumberConfirmed = phoneNumberConfirmed;
        PasswordHash = passwordHash;
        Registered = registered;
        Suspended = suspended;
    }

    public static Customer Create(CustomerId id, string email, string passwordHash, DateTime registered)
    {
        return new Customer()
        {
            Id = id,
            Email = email,
            PasswordHash = passwordHash,
            Registered = registered,
            KycLevels = new()
        };
    }
}