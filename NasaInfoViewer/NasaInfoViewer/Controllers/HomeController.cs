using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using NasaInfoViewer.Helpers;
using NasaInfoViewer.Models;

namespace NasaInfoViewer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<HomeController> _logger;
        ApiHelper imagenApi = new ApiHelper();
        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            Task<List<imageDaily.MyArray>> imagenes;
            string fechaHoy = DateTime.Now.ToString("yyyy-MM-dd");
            var cacheKey ="";
            cacheKey = fechaHoy;
           
            List<imageDaily.MyArray> list = new List<imageDaily.MyArray>();
            if (!_memoryCache.TryGetValue(cacheKey, out imagenes))
            {
                var cacheExpirationsOptions =
                    new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddHours(1),
                        Priority = CacheItemPriority.Normal,
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    };
                if (imagenes == null)
                {
                    imagenes = imagenApi.getImages4LastDays(fechaHoy, 3);
                    _memoryCache.Set(cacheKey, imagenes, cacheExpirationsOptions);
                }
               
            }
           
            list = imagenes.Result;
            return View(list);

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
