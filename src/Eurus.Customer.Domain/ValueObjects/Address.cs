using Eurus.Common.Domain.Enums;

namespace Eurus.Customer.Domain.ValueObjects;

public class Address
{
    public string Building { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public District District { get; set; }
    public string ZipCode { get; set; }
    
    
}