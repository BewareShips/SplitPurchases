using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.UpdatePurchase
{
    public class UpdatePurchaseCommandValidator: AbstractValidator<UpdatePurchaseCommand>
    {
        public UpdatePurchaseCommandValidator()
        {
            RuleFor(command => command.PurchaseId)
                .NotEqual(Guid.Empty)
                .WithMessage("Purchase ID cannot be empty.");

            RuleFor(command => command.Amount)
                .GreaterThan(0)
                .WithMessage("Amount must be greater than zero.");

            RuleFor(command => command.Name)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Name must be at least 3 characters long.");

            RuleFor(command => command.Description)
                .NotEmpty()
                .MaximumLength(500)
                .WithMessage("Description must not exceed 500 characters.");
        }
    }
}
