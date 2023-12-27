using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using parser.Models.Entities;
using parser.Services;
using parser.Services.Parsers;
using ParserMVC.DataModels;
using ParserMVC.Models;
using ParserMVC.Services;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UI.Server.Services;

namespace ParserMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly FixenParserService _fixenService;
        private readonly NeptunParserService _netpunService;
        private readonly MyApplicationContext _context;
        private readonly SupportService _supportService;
        private readonly ParserLoggerService _logger;
        public HomeController(
            FixenParserService fixenService,
            NeptunParserService neptunService,
            MyApplicationContext context,
            SupportService supportService,
            ParserLoggerService logger)
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
            await MakeLog("Обновлены цены Fixen");
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
            await MakeLog("Обновлены цены Neptun");
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
            await MakeLog("Открыта страница сайта");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(
            [FromForm] string name,
            [FromForm] string shop,
            [FromForm] string category,
            [FromForm] string url)
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
                await MakeLog($"Добавлен товар {name}");
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Ошибка при получении ID магазина или категории.";
                await MakeLog($"Ошибка добавления товара, name = {name}, shop = {shop}, category = {category}, url = {url}");
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> UpdatePrices()
        {
            var success = await _fixenService.UpdatePrices();
            if (success) await _netpunService.UpdatePrices();
            var products = _context.Products;
            foreach (var product in products)
            {
                await MakeLog($"Проверена цена товара {product.Name}, текущая цена - {product.Price}");
            }
            return Ok();
        }

        public async Task MakeLog(string message)
        {
            await _logger.Log(message);
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
