using Http.Client.Factory.Application.Domains.Responses;

namespace Http.Client.Factory.Application.Interfaces
{
    public interface IHttpClientFactoryDirectlyService
    {
        Task<IEnumerable<UserContractOutput>> GetDirectly(CancellationToken cancellationToken);
    }
}
