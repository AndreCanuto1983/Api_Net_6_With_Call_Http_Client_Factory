using Http.Client.Factory.Application.Domains.Responses;
using Http.Client.Factory.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Http.Client.Factory.Svc.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HttpClientFactoryNamedClientsController : Controller
    {
        private readonly IHttpClientFactoryNamedClientService _httpClientFactoryNamedClientService;        

        public HttpClientFactoryNamedClientsController(
            IHttpClientFactoryNamedClientService httpClientFactoryNamedClientService)
        {
            _httpClientFactoryNamedClientService = httpClientFactoryNamedClientService;            
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<UserContractOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> NamedClient(CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClientFactoryNamedClientService.GetNamedClient(cancellationToken);

                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
