using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationsRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar adı-soyadı kısmı boş geçilemez.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz.");
            RuleFor(x => x.Name).MaximumLength(80).WithMessage("Lütfen en fazla 80 karakter giriniz.");

            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail adresi boş geçilemez.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez.");
        }
    }
}
