using LK_Searcher.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LK_Searcher.Controllers
{
    public class AllPublishController : Controller
    {
        MyContext dbContext = new MyContext();
        public IActionResult Index()
        {
            
            var publishes = dbContext.Publishes.Include(a => a.Authors).ToList();

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
                List<Author> authors = new List<Author>();
                var rawValue = ModelState["Authors"].RawValue;
                if (rawValue is string authorId)
                {
                    // Обработка случая, когда у статьи только один автор
                    int authorIdInt = int.Parse(authorId);
                    var author = dbContext.Authors.FirstOrDefault(a => a.Id == authorIdInt);
                    if (author != null)
                    {
                        authors.Add(author);
                    }
                }
                else if (rawValue is string[] authorIdStrings)
                {
                    authorIdStrings = (string[])ModelState["Authors"].RawValue;
                    int[] authorIds = authorIdStrings.Select(int.Parse).ToArray();
                    authors = dbContext.Authors.Where(a => authorIds.Contains(a.Id)).ToList();
                }

                publish.Authors = authors;
                dbContext.Publishes.Add(publish);
                dbContext.SaveChanges();
            }
            var publishes = dbContext.Publishes.ToList();
            return View("Index", publishes);
        }
    }
}
