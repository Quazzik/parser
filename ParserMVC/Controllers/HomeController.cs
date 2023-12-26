using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using parser.Models.Entities;
using parser.Services;
using parser.Services.Parsers;
using ParserMVC.DataModels;
using ParserMVC.Models;
using System.Diagnostics;
using UI.Server.Services;

namespace ParserMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FixenParserService _fixenService;
        private readonly NeptunParserService _netpunService;
        private readonly MyApplicationContext _context;
        private readonly SupportService _supportService;
        public HomeController(FixenParserService fixenService, NeptunParserService neptunService, ILogger<HomeController> logger, MyApplicationContext context, SupportService supportService)
        {
            _logger = logger;
            _fixenService = fixenService;
            _netpunService = neptunService;
            _context = context;
            _supportService = supportService;
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

        public async Task<IActionResult> Index()
        {
            await UpdatePrices();
            var transferModel = await _supportService.GetDataModelsAsync();
            var model = new PageData
            {
                RowData = transferModel,
                Categories = await _supportService.GetCategoriesAsync(),
                Shops = await _supportService.GetShopsAsync()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddProduct([FromForm] string name, [FromForm] string shop, [FromForm] string category, [FromForm] string url)
        {
            if (int.TryParse(shop, out int shopId) && int.TryParse(category, out int categoryId))
            {
                var newProduct = new Product
                {
                    ShopID = shopId,
                    CategoryID = categoryId,
                    Name = name,
                    Url = url
                };
                _context.Add(newProduct);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Ошибка при получении ID магазина или категории.";
                return RedirectToAction("Index");
            }
        }

            public async Task<IActionResult> UpdatePrices()
        {
            var success = await _fixenService.UpdatePrices();
            if (success) success = await _netpunService.UpdatePrices();
                return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
