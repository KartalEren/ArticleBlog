using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results; //foreach deki result.Error  daki Error altı çizili hatasını alır.

namespace ArticleBlog.BLL.Extensions
{
    public static class FluentValidationExtensions
    {

        //Başarısız işlemde verilecek mesajı içerir.
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }

        //public static void AddToIdentityModelState(this IdentityResult result, ModelStateDictionary modelState)
        //{
        //    foreach (var error in result.Errors)
        //    {
        //        modelState.AddModelError("", error.Description);
        //    }
        //}
    }
}
