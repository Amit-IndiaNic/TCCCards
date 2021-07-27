using FluentValidation;
using System;
using TCCCards.Service.Contact;
using TCCCards.ViewModels.Validators.CardDetail;

namespace TCCCards.Purchase.API.Validators
{
    public class AddEditCardDetailViewModelExtendedValidator : AddEditCardDetailViewModelValidator
    {
        public AddEditCardDetailViewModelExtendedValidator(ICardDetailService cardDetailService)
        {
            RuleFor(s => s.ValidThrough)
                .Must(BeAValidDate)
                .WithMessage("ValidThrough is required")
                .Must(BeActiveCard)
                .WithMessage("The Card has expired, Please use another payment method")
                ;

        }
        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
        private bool BeActiveCard(DateTime date)
        {
            return date > DateTime.Today.AddDays(-1);
        }
    }
}
