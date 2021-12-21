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

        public HttpClientFactoryDirectlyController(
            IHttpClientFactoryDirectlyService httpClientFactoryDirectlyService)
        {
            _httpClientFactoryDirectlyService = httpClientFactoryDirectlyService;            
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
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
