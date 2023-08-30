using ArticleBlog.Entitiy.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.FluentValidations
{
    public class CategoryValidator : AbstractValidator<Category> //Category için Validation oluştururlur.Yani şartları belirtiriz.
    {
        public CategoryValidator() //Data annotaion tarzı gibi fakat bu ctor da belirtilen Validationdur.
        {
            RuleFor(c => c.CategoryName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(1000);
        }
    }
}
