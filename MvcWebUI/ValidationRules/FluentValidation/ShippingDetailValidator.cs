using FluentValidation;
using MvcWebUI.Models;

namespace MvcWebUI.ValidationRules.FluentValidation;

public class ShippingDetailValidator  :AbstractValidator<ShippingDetail>
{
    public ShippingDetailValidator()
    {
        RuleFor(s => s.FirstName)
           
            .NotEmpty()
            .MinimumLength(2)
            .WithMessage("Adı Gereklidir.");
        RuleFor(s => s.LastName)
            .NotEmpty()
            .MinimumLength(2);
        RuleFor(s => s.Email)
            .EmailAddress()
            .WithMessage("Mail adresini girin");
        RuleFor(s => s.City)
            .NotEmpty().When(s => s.Age < 18);
        //RuleFor(s=>s.FirstName).Must(StartWithA).WithMessage("Ad A ile başlamalıdır");

    }

    private bool StartWithA(string arg)
    {
        return arg.StartsWith("A");
    }
}