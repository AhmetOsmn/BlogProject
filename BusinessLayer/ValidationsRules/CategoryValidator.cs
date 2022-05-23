using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationsRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor( x=> x.Name).NotEmpty().WithMessage("Kategori adı boş olamaz.");
            RuleFor( x=> x.Name).MaximumLength(50).WithMessage("En fazla 50 karakter giriniz.");
            RuleFor( x=> x.Name).MinimumLength(2).WithMessage("En az 2 karakter giriniz.");
            
            RuleFor( x=> x.Description).NotEmpty().WithMessage("Açıklama kısmı boş olamaz.");

        }
    }
}
