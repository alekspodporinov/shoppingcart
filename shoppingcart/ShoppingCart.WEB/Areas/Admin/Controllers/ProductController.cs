using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.BLL.Interfaces;
using ShoppingCart.BLL.ViewModels;

namespace ShoppingCart.WEB.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult PartialListOfProduct(long parentCategoryId)
        {
            ViewBag.ParentCategoryId = parentCategoryId;
           var model = _productService.GetAll(parentCategoryId);
            return View(model);
        }
        //TODO:всплывающий тайтл если удалить нельзя

        #region Create region
        public ActionResult Create(long parentCategoryId)
        {
            ViewBag.ParentCategoryId = parentCategoryId;
            //var characteristics = _productService.GetAllCharacteristic(parentCategoryId).ToList();
            //var model = new ProductViewModel {Characteristics = characteristics, ParentCategoryId = parentCategoryId};
            return View();
        }

        public ActionResult PartialProductCreate(long parentCategoryId)
        {
            var model = new ProductCreateViewModel {  ParentCategoryId = parentCategoryId };
            return View(model);
        }

        public ActionResult PartialCreatePhoto(long parentCategoryId)
        {
            return View();
        }

        public ActionResult PartialCreateCharecteristic(long parentCategoryId)
        {
            var characteristics = _productService.GetAllCharacteristic(parentCategoryId).ToList();
            return View(characteristics);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(ProductCreateViewModel product, HttpPostedFileBase[] uploadImage, List<CharacteristicValueViewModel> listCharacteristicValue, string[] aspectRatio)
        {
            var photoes = uploadImage.Where(pic => pic != null).Select((pic, r) => new PhotoViewModel
            {
                OriginalPhoto = pic,
                AspectRatio = aspectRatio[r]
            }).ToList();

            await _productService.Create(product, photoes, listCharacteristicValue ?? new List<CharacteristicValueViewModel>());
            return RedirectToAction("Details", "Category", new { parentCategoryId = product.ParentCategoryId });

        }
        #endregion

        #region Edit
        public ActionResult Edit(long id, long parentCategoryId)
        {
            ViewBag.ProductId = id;
            ViewBag.ParentCategoryId = parentCategoryId;
        
            var viewModel = new ProductUpdateViewModel
            {
                EditProduct = _productService.GetByIdForUpdate(id, parentCategoryId),
                Characteristics = _productService.GetCharacteristicForProduct(id, parentCategoryId).ToList(),
                OldPhotoes = _productService.GetPhotoForProduct(id).ToList()
            };

            return View(viewModel);
        }

        public ActionResult PartialEditProduct(ProductCreateViewModel viewModelProduct)
        {
            return View(viewModelProduct);
        }

        public ActionResult PartialEditCharecteristic(List<CharacteristicValueViewModel> viewModelCharecteristic)
        {
            return View(viewModelCharecteristic);
        }

        public ActionResult PartialEditPhotoes(List<PhotoProductViewModel> viewModelPhotoes)
        {
            return View(viewModelPhotoes);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit(ProductCreateViewModel editProduct, List<CharacteristicValueViewModel> characteristics, List<PhotoProductViewModel> oldPhotoes, HttpPostedFileBase[] newPhotoes, string[] aspectRatioNewPhotoes)
        {
            var photoes = newPhotoes.Where(pic => pic != null).Select((pic, r) => new PhotoViewModel
            {
                OriginalPhoto = pic,
                AspectRatio = aspectRatioNewPhotoes[r]
            }).ToList();

            var viewModel = new ProductUpdateViewModel
            {
                OldPhotoes = oldPhotoes,
                Characteristics = characteristics,
                EditProduct = editProduct,
                NewPhotoes = photoes
            };

            await _productService.Update(viewModel);

            return RedirectToAction("Details", "Category", new { parentCategoryId = editProduct.ParentCategoryId });
        }
        #endregion

        public async Task<ActionResult> Delete(long id, long parentCategoryId)
        {
            await _productService.Delete(id);
            return RedirectToAction("Details", "Category", new { parentCategoryId = parentCategoryId });
        }
		public ActionResult Details(long id, long parentCategoryId)
		{
			var viewMdoel = _productService.GetById(id, parentCategoryId);
			return View(viewMdoel);
		}

	}
}
//TODO:Сделать пагинацию для таблиц