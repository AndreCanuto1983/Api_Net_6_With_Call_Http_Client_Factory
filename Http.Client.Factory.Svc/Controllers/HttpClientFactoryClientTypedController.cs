using Http.Client.Factory.Application.Converter.HttpContent;
using Http.Client.Factory.Application.Domains.Requests;
using Http.Client.Factory.Application.Domains.Responses;
using Http.Client.Factory.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace http_client_factory.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HttpClientFactoryClientTypedController : ControllerBase
    {
        private readonly IHttpClientFactoryTypedClientService _httpClientFactoryTypedClientService;        

        public HttpClientFactoryClientTypedController(
            IHttpClientFactoryTypedClientService identificationService)
        {
            _httpClientFactoryTypedClientService = identificationService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(LoginContractOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Identification(LoginContractInput loginContractInput, CancellationToken cancellationToken)
        {
            if (!loginContractInput.IsValid())
                return BadRequest();

            try
            {
                var response = await _httpClientFactoryTypedClientService.CallLoginApi(
                    loginContractInput.LoginInputToHttpContent(), cancellationToken);

                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}