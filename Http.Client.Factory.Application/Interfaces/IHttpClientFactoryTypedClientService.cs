using Http.Client.Factory.Application.Domains.Responses;

namespace Http.Client.Factory.Application.Interfaces
{
    public interface IHttpClientFactoryTypedClientService
    {
        Task<LoginContractOutput> CallLoginApi(HttpContent httpContent, CancellationToken cancellationToken);
    }
}
