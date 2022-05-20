using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationsRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Blog başlık kısmı boş geçilemez.");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("En fazla 50 karakter giriniz.");
            RuleFor(x => x.Title).MinimumLength(2).WithMessage("En az 2 karakter giriniz.");


            RuleFor(x => x.Content).NotEmpty().WithMessage("Blog içerik kısmı boş geçilemez.");
            RuleFor(x => x.Content).MaximumLength(350).WithMessage("En fazla 350 karakter giriniz.");
            RuleFor(x => x.Content).MinimumLength(2).WithMessage("En az 2 karakter giriniz.");

            RuleFor(x => x.Image).NotEmpty().WithMessage("Blog görseli kısmı boş geçilemez.");
        }
    }
}
