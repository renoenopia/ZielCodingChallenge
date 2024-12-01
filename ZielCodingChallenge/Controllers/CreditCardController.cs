using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ZielCodingChallenge.Business;

namespace ZielCodingChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditCardController : Controller
    {
        private readonly CreditCardHelper _creditCardHelper;

        public CreditCardController()
        {
            _creditCardHelper = new CreditCardHelper();
        }

        [HttpGet(Name = "GetCreditCardInfoValid")]
        public bool Get(string creditCardNumber)
        {
            return _creditCardHelper.ValidCreditCard(creditCardNumber);
        }

        [Route("/error-development")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return Problem(
                detail: exceptionHandlerFeature?.Error.StackTrace,
                title: exceptionHandlerFeature?.Error.Message);
        }
    }
}