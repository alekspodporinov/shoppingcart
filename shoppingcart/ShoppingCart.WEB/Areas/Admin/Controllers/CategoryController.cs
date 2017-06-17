using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ShoppingCart.BLL.Interfaces;
using ShoppingCart.BLL.ViewModels;

namespace ShoppingCart.WEB.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult ListCategories(long? parentCategoryId)
        {
            ViewBag.parentCategoryId = parentCategoryId;
            var model = _categoryService.GetAll(parentCategoryId);

            if (!model.Any() && parentCategoryId != null)
                return RedirectToAction("Details", new {parentCategoryId});

            return View(model);
        }

        public ActionResult PartialListChildrenCategory(long? parentCategoryId)
        {
            ViewBag.parentCategoryId = parentCategoryId;
            return PartialView(_categoryService.GetAll(parentCategoryId));
        }

        [HttpGet]
        public async Task<JsonResult> CheckCategoryName(string Name ,long? id)
        {
            if (id == null)//TODO:Это костыль если что!
                id = 0;
            var result = await _categoryService.CheckCategoryName(id.Value,Name);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(long? parentCategoryId, string redirectStr)
        {
            ViewBag.parentCategoryId = parentCategoryId;
            ViewBag.RedirectStr = redirectStr;
            return View(new CategoryViewModel {ParentCategoryId = parentCategoryId});
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(FormCollection a, CategoryViewModel newCategory, string redirectStr)
        {
            var  res = await _categoryService.Create(newCategory);

            if (res.Succedeed)
                return RedirectToAction(redirectStr, new {parentCategoryId = newCategory.ParentCategoryId});

            ViewBag.RedirectStr = redirectStr;
            ViewBag.Error = res.Message + $"  {res.Property}";
            return View(newCategory);
        }

        public ActionResult Edit(long id, string redirectStr)
        {
            ViewBag.RedirectStr = redirectStr;
            var model = _categoryService.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit(CategoryViewModel category, string redirectStr)
        {
            var res = await _categoryService.Update(category);

            if (res.Succedeed)
                return RedirectToAction(redirectStr, new { parentCategoryId = category.ParentCategoryId });

            ViewBag.RedirectStr = redirectStr;
            ViewBag.Error = res.Message + $"  {res.Property}";
            return View(category);
        }

        public ActionResult Details(long? parentCategoryId, string nameCategory)
        {
            if (parentCategoryId == null)
                parentCategoryId = 0;

            ViewBag.NameCategory = _categoryService.GetById(parentCategoryId.Value).Name;

            return View(parentCategoryId);
        }

        public async Task<ActionResult> Delete(long id)
        {
            await _categoryService.Delete(id);
            return View();
        }
    }
}