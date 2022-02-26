using System.Runtime.Serialization;

// ReSharper disable IdentifierTypo

namespace Eurus.Common.Domain.Enums;

public enum District
{
    Colombo,
    Gampaha,
    Kalutara,
    Kandy,
    Matale,
    [EnumMember(Value = "Nuwara Eliya")] 
    NuwaraEliya,
    Galle,
    Matara,
    Hambantota,
    Jaffna,
    Kilinochchi,
    Mannar,
    Vavuniya,
    Mullaitivu,
    Batticaloa,
    Ampara,
    Trincomalee,
    Kurunegala,
    Puttalam,
    Anuradhapura,
    Polonnaruwa,
    Badulla,
    Moneragala,
    Ratnapura,
    Kegalle
}