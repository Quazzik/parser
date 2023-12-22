using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using parser.Services;
using parser.Services.Parsers;
using WebParser.Controllers;

namespace parser.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : DefaultController
    {
        private readonly FixenParserService _fixenService;
        private readonly NeptunParserService _netpunService;

        public MainController(FixenParserService fixenService, NeptunParserService neptunService)
        {
            _fixenService = fixenService;
            _netpunService = neptunService;
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
        [HttpGet]
        public async Task<JsonResult> UpdateNeptunPricesit()
        {
            return Json(await _netpunService.UpdatePrices());
        }
        [HttpGet]
        public async Task<JsonResult> GetNeptunProducts()
        {
            return Json(await _netpunService.GetProductAsync());
        }
    }
}