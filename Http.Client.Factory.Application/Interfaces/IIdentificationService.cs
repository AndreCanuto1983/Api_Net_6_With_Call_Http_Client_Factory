using Http.Client.Factory.Application.Domains;

namespace Http.Client.Factory.Application.Interfaces
{
    public interface IIdentificationService
    {
        Task<LoginContractOutput> CallUserApi(HttpContent httpContent);
    }
}
