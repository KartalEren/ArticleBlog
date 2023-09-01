using ArticleBlog.Entitiy.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleBlog.BLL.FluentValidations
{
    public class ArticleValidator : AbstractValidator<Article> //Article için Validation oluştururlur.Yani şartları belirtiriz.
    {
        public ArticleValidator()//Data annotaion tarzı gibi fakat bu ctor da belirtilen Validationdur.
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(1000);

            RuleFor(x => x.Content)
               .NotEmpty()
               .NotNull()
               .MinimumLength(3)
               .MaximumLength(1000);



        }
    }
}
