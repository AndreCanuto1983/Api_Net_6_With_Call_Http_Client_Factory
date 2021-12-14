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
        private readonly IHttpClientFactoryTypedClientService _identificationService;
        private readonly ILogger<HttpClientFactoryClientTypedController> _logger;

        public HttpClientFactoryClientTypedController(
            IHttpClientFactoryTypedClientService identificationService,
            ILogger<HttpClientFactoryClientTypedController> logger)
        {
            _identificationService = identificationService;
            _logger = logger;
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
                var response = await _identificationService.CallLoginApi(loginContractInput.LoginInputToHttpContent(), cancellationToken);

                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "[HttpClientFactoryClientTypedController][Identification]");

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}