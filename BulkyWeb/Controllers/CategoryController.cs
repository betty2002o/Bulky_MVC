using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
		// uses Dependency Injection to give controller access to the database
		// creates an ApplicationDbContext object  (because it is registered it in Program.cs with AddDbContext).
		// Then it injects that object into the controller’s constructor.
		private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
			// ASP.NET Core creates a new instance of the controller each time an HTTP request is made to a route handled by that controller.
			_db = db;
			// _db gives  access to the database inside all controller actions.
		}
		public IActionResult Index()
        {
			List<Category> objCategoriesList = _db.Categories.ToList();
			// If don’t use .ToList(), _db.Categories remains an IQueryable<Category> , executions in the sql
			return View(objCategoriesList);
        }

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Category obj)
		{
			if (obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("Name", "The Display Order and Name cannot be the same");
			}
			if (ModelState.IsValid)
			{
			_db.Categories.Add(obj);
			_db.SaveChanges();
			//return RedirectToAction("Index", "Category");
			return RedirectToAction("Index");
			}
			return View();
		}
    }
}
