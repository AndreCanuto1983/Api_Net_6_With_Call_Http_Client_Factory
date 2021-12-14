using Http.Client.Factory.Application.Domains.Responses;

namespace Http.Client.Factory.Application.Interfaces
{
    public interface IHttpClientFactoryNamedClientService
    {
        Task<IEnumerable<UserContractOutput>> GetNamedClient(CancellationToken cancellationToken);
    }
}
