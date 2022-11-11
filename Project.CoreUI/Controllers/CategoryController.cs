using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.CoreUI.Models.PageVM;
using Project.ENTITIES.Models;

namespace Project.CoreUI.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        ICategoryManager _icm;
        public CategoryController(ICategoryManager icm)
        {
            _icm = icm;
        }
       
        public IActionResult CategoryList()
        {
            CategoryPageVM cpvm = new CategoryPageVM
            {
                Categories = _icm.GetAll()
            };
            return View(cpvm);
        }
        public IActionResult AddCategory()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            TempData["mesaj"] = _icm.Add(category);
            return RedirectToAction("AddCategory");
        }
    }
}
