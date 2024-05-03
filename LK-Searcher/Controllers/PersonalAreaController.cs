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
        public IActionResult ShowAllPublish()
        {
            var publishes = dbContext.Publishes.ToList();

            return View(publishes);
        }
        public IActionResult AddNewPublish()
        {
            var authors = dbContext.Authors.ToList();

            return View(authors);
        }
        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                dbContext.Authors.Add(author);
                dbContext.SaveChanges();
            }
            var authors = dbContext.Authors.ToList();
            return View("AddNewPublish", authors);
        }
        public IActionResult AddPublish(Publish publish)
        {//Authors
            if (ModelState.IsValid)
            {
                string[] authorIdStrings = (string[])ModelState["Authors"].RawValue;
                int[] authorIds = authorIdStrings.Select(int.Parse).ToArray();
                var authors = dbContext.Authors.Where(a => authorIds.Contains(a.Id)).ToList();
                publish.Authors = authors;
                dbContext.Publishes.Add(publish);
                dbContext.SaveChanges();
            }
            var publishes = dbContext.Publishes.ToList();
            return View("ShowAllPublish", publishes);
        }

    }
}
