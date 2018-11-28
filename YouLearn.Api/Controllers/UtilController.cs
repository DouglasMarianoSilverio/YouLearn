using Microsoft.AspNetCore.Mvc;

namespace YouLearn.Api.Controllers
{
    public class UtilController
    {
        [HttpGet]
        [Route("versao")]
        public object Versao()
        {
            return new { Desenvolvedor = "Douglas Silverio", VersaoAPi = "0.0.1" };
        }
    }
}
