using Http.Client.Factory.Application.Domains.Responses;
using Http.Client.Factory.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Http.Client.Factory.Svc.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HttpClientFactoryDirectlyController : Controller
    {
        private readonly IHttpClientFactoryDirectlyService _httpClientFactoryDirectlyService;
        private readonly ILogger<HttpClientFactoryDirectlyController> _logger;

        public HttpClientFactoryDirectlyController(
            IHttpClientFactoryDirectlyService httpClientFactoryDirectlyService,
            ILogger<HttpClientFactoryDirectlyController> logger)
        {
            _httpClientFactoryDirectlyService = httpClientFactoryDirectlyService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<UserContractOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status204NoContent)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Directly(CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClientFactoryDirectlyService.GetDirectly(cancellationToken);

                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "[HttpClientFactoryDirectlyController][Directly]");

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
