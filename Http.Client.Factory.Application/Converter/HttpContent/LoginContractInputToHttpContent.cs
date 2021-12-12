using Http.Client.Factory.Application.Domains;
using System.Text;
using System.Text.Json;

namespace Http.Client.Factory.Application.Converter.HttpContent
{
    public static class UserContractToHttpContent
    {
        public static StringContent LoginInputToHttpContent(this LoginContractInput loginContractInput)
        {
            var json = JsonSerializer.Serialize(loginContractInput);

            return new StringContent(json, UnicodeEncoding.UTF8, "application/json");
        }
    }
}
