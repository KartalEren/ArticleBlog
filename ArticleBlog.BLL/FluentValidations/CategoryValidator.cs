using ArticleBlog.Entitiy.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.FluentValidations
{
    public class CategoryValidator : AbstractValidator<Category> 
    {
        public CategoryValidator() 
        {
            RuleFor(c => c.CategoryName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(1000);
        }
    }
}
