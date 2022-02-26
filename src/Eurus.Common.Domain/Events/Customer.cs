using Eurus.Common.Domain.Enums;
using Eurus.Common.Domain.Identifiers;
// ReSharper disable All

namespace Eurus.Common.Domain.Events.Customer;

public record CustomerRegistered(CustomerId CustomerId, string Email, string PasswordHash, DateTime Registered);
public record CustomerEmailVerified(CustomerId CustomerId, string Email, DateTime Verified);

public record CustomerPhoneNumberAdded(CustomerId CustomerId, string PhoneNumber, DateTime Added);
public record CustomerPhoneNumberVerified(CustomerId CustomerId, string PhoneNumber, DateTime Verified);

public record CustomerPasswordChanged(CustomerId CustomerId, string PasswordHash, DateTime Changed);
public record CustomerSuspended(CustomerId CustomerId, string Reason, DateTime Suspended);

public record CustomerKycApproved(CustomerId CustomerId, KycLevel Level, DateTime Approved);
public record CustomerKycRejected(CustomerId CustomerId, KycLevel Level, string Reason, DateTime Rejected);

