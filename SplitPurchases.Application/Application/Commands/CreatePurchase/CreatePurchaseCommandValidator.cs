using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.CreatePurchase
{
    public class CreatePurchaseCommandValidator: AbstractValidator<CreatePurchaseCommand>
    {
        public CreatePurchaseCommandValidator()
        {
            RuleFor(command => command.GroupId)
                .NotEqual(Guid.Empty)
                .WithMessage("Group ID cannot be empty.");

            RuleFor(command => command.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID cannot be empty.");

            RuleFor(command => command.Amount)
                .GreaterThan(0)
                .WithMessage("Amount must be greater than zero.");

            RuleFor(command => command.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty.")
                .MinimumLength(3)
                .WithMessage("Name must be at least 3 characters long.");

            // Optional if necessary
            RuleFor(command => command.Description)
                .MaximumLength(500) 
                .WithMessage("Description must not exceed 500 characters.");
        }
    }
}
