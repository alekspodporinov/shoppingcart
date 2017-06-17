using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.BLL.Interfaces;
using ShoppingCart.BLL.ViewModels;

namespace ShoppingCart.WEB.Areas.Admin.Controllers
{
    public class CharacteristicController : Controller
    {
        readonly ICharacteristicService _characteristicService;
        public CharacteristicController(ICharacteristicService characteristicService)
        {
            _characteristicService = characteristicService;
        }

        public ActionResult PartialCharacteristicList(long parentCategoryId)
        {
            ViewBag.parentCategoryId = parentCategoryId;
            var model = _characteristicService.GetAll(parentCategoryId).ToList();
            return View(model);
        }

        public ActionResult Details(long id)
        {
            var model = _characteristicService.GetById(id);
            return View(model);
        }

        [HttpGet]
        public JsonResult CheckCategoryName(string Name, long Id = 0)
        {
            return Json(_characteristicService.CheckCharacteristicName(Name, Id), JsonRequestBehavior.AllowGet);
        }
        //TODO:---> Переделать все "public ActionResult Delete" на Post <---
        public ActionResult Delete(long id,long parentCategoryId)
        {
            _characteristicService.Delete(id);
            return RedirectToAction("Details", "Category", new { parentCategoryId });
        }

        public ActionResult Create(long parentCategoryId)
        {
            var model = new CharacteristicViewModel
            {
                ParentCategoryId = parentCategoryId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CharacteristicViewModel newCharacteristic)
        {
            var res = await _characteristicService.Create(newCharacteristic);

            if(res.Succedeed)
                return RedirectToAction("Details", "Category", new { parentCategoryId = newCharacteristic.ParentCategoryId});

            ViewBag.Error = res.Message + $"  {res.Property}";
            return View(newCharacteristic);
        }

        public ActionResult Edit(long id)
        {
            var model = _characteristicService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CharacteristicViewModel newCharacteristic)
        {
            var res = await _characteristicService.Update(newCharacteristic);

            if(res.Succedeed)
                return RedirectToAction("Details", "Category", new { parentCategoryId = newCharacteristic.ParentCategoryId });

            ViewBag.Error = res.Message + $"  {res.Property}";
            return View(newCharacteristic);
        }
    }
}