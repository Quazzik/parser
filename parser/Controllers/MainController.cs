using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using parser.Services;
using WebParser.Controllers;

namespace parser.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : DefaultController
    {
        private readonly FixenParserService _fixenService;

        public MainController(FixenParserService fixenService)
        {
            _fixenService = fixenService;
        }
        [HttpGet]
        public async Task<JsonResult> UpdateFixenPricesit()
        {
            return Json(await _fixenService.UpdatePrices());
        }
        [HttpGet]
        public async Task<JsonResult> GetFixenProducts()
        {
            return Json(await _fixenService.GetProductAsync());
        }
    }
}