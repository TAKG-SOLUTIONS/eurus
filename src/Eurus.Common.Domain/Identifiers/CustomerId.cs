using StronglyTypedIds;

namespace Eurus.Common.Domain.Identifiers;


[StronglyTypedId(backingType: StronglyTypedIdBackingType.Guid, converters: StronglyTypedIdConverter.SystemTextJson)] 
public partial struct CustomerId { }