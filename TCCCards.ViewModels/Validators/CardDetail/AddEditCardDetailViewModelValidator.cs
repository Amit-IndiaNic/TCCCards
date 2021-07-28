using FluentValidation;
using TCCCards.ViewModels.Card;

namespace TCCCards.ViewModels.Validators.CardDetail
{
    public class AddEditCardDetailViewModelValidator : AbstractValidator<AddEditCardDetailViewModel>
    {
        public AddEditCardDetailViewModelValidator()
        {
            RuleFor(s => s.CardNumber)
                .NotEmpty()
                .WithMessage("CardNumber is required")
                .MinimumLength(15)
                .WithMessage("Card number must be atleasr 15 digit long");
            

            RuleFor(s => s.NameOnCard)
                .NotEmpty()
                .WithMessage("Name on Card is required");

            RuleFor(s => s.ValidThrough)
                .NotEmpty()
                .WithMessage("Please Select ValidThrough");

            RuleFor(s => s.CVV)
                .NotEmpty()
                .WithMessage("CVV is required, It's a 3 digit number on back of your card");
        }
    }
}
