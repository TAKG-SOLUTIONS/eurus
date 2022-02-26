using Eurus.Common.Domain.Events;
using Eurus.Common.Domain.Events.Customer;
using Eurus.Customer.Domain.ValueObjects;

namespace Eurus.Customer.Domain.Aggregates;

public partial class Customer
{
    public void Apply(CustomerRegistered @event)
    {
        Id = @event.CustomerId;
        Email = @event.Email;
        PasswordHash = @event.PasswordHash;
        Version++;
    }

    public void Apply(CustomerEmailVerified @event)
    {
        if (Email != @event.Email) return;

        EmailConfirmed = true;
        Version++;
    }

    public void Apply(CustomerPasswordChanged @event)
    {
        PasswordHash = @event.PasswordHash;
        Version++;
    }

    public void Apply(CustomerPhoneNumberAdded @event)
    {
        if (@event.PhoneNumber == PhoneNumber && PhoneNumberConfirmed) return;

        PhoneNumber = @event.PhoneNumber;
        PhoneNumberConfirmed = false;
        Version++;
    }

    public void Apply(CustomerPhoneNumberVerified @event)
    {
        if (PhoneNumber != @event.PhoneNumber) return;

        PhoneNumberConfirmed = true;
        Version++;
    }
    
    public void Apply(CustomerSuspended @event)
    {
        Suspended = true;
        Version++;
    }
    
    public void Apply(CustomerKycApproved @event)
    {
        if (KycLevels.TryGetValue(@event.Level, out var status))
        {
            if (status.IsApproved)
            {
                return;
            }
        }

        KycLevels[@event.Level] = new KycStatus(IsApproved: true, Reason: null);
        Version++;
    }
    
    public void Apply(CustomerKycRejected @event)
    {
        KycLevels[@event.Level] = new KycStatus(IsApproved: false, Reason: @event.Reason);
        Version++;
    }
}