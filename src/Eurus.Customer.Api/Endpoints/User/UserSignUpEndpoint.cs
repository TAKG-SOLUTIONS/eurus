using Ardalis.ApiEndpoints;
using Eurus.Common.Domain.Identifiers;
using Marten;
using Microsoft.AspNetCore.Mvc;
namespace Eurus.Customer.Api.Endpoints.User;


public class UserSignUpEndpoint : EndpointBaseAsync.WithoutRequest.WithActionResult<Domain.Aggregates.Customer>
{
    private readonly IDocumentSession _documentSession;

    public UserSignUpEndpoint(IDocumentSession documentSession)
    {
        _documentSession = documentSession;
    }

    [HttpGet("/")]
    public override async Task<ActionResult<Domain.Aggregates.Customer>> HandleAsync(CancellationToken cancellationToken = new())
    {
        var customerId = CustomerId.New();
        var customer =
            Domain.Aggregates.Customer.Create(customerId, "sumihiran.nuwan@gmail.com", "s3cr3t", DateTime.Now);
        _documentSession.Insert(customer);
        await _documentSession.SaveChangesAsync(cancellationToken);
        return customer;
    }
}