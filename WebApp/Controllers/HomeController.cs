using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Предоставляет клинент для сервиса
        /// </summary>
        /// <returns>Представление главной страницы</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
