using LK_Searcher.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace LK_Searcher.Controllers
{
    public class PersonalAreaController : Controller
    {
        MyContext dbContext = new MyContext();
        public IActionResult Index()
        {
            return View();
        }
    
        
        

    }
}
