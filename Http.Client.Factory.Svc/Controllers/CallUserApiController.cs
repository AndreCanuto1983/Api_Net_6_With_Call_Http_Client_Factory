using Http.Client.Factory.Application.Converter.HttpContent;
using Http.Client.Factory.Application.Domains;
using Http.Client.Factory.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace http_client_factory.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CallUserApiController : ControllerBase
    {
        private readonly IIdentificationService _identificationService;
        private readonly ILogger<CallUserApiController> _logger;

        public CallUserApiController(
            IIdentificationService identificationService,
            ILogger<CallUserApiController> logger)
        {
            _identificationService = identificationService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(LoginContractOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Identification(LoginContractInput loginContractInput)
        {
            if (!loginContractInput.IsValid())
                return BadRequest();

            try
            {
                var response = await _identificationService.CallUserApi(loginContractInput.LoginInputToHttpContent());

                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error");

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}