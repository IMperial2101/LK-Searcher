using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LK_Searcher.Controllers
{
    public class AllPublishController : Controller
    {
        MyContext dbContext = new MyContext();
        public IActionResult Index()
        {
            var publishes = dbContext.Publishes.ToList();

            return View(publishes);
        }
    }
}
