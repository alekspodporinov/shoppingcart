using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ShoppingCart.BLL.ViewModels;

namespace ShoppingCart.WEB.Binders
{
    public class ListOfPhotoesModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProvider = bindingContext.ValueProvider;

            var list = new List<PhotoProductViewModel>();
            var count = (int)valueProvider.GetValue("photoes.Count").ConvertTo(typeof(int));

            for (var i = 0; i < count; i++)
            {
                if (valueProvider.GetValue("photoes[" + i + "].Name") == null)
                    continue;

                list.Add(new PhotoProductViewModel
                {
                    Name = (string) valueProvider.GetValue("photoes[" + i + "].Name").ConvertTo(typeof (string)),
                    Id = (int) valueProvider.GetValue("photoes[" + i + "].Id").ConvertTo(typeof (int)),
                    UrlFotoNormal =
                        (string) valueProvider.GetValue("photoes[" + i + "].UrlFotoNormal").ConvertTo(typeof (string)),
                    AspectRatio = (string) valueProvider.GetValue("photoes[" + i + "].AspectRatio").ConvertTo(typeof (string)),
                    Size = (string) valueProvider.GetValue("photoes[" + i + "].Size").ConvertTo(typeof (string))
                });
            }

            return list;
        }
    }
}