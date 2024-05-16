using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.DeletePurchase
{
    public class DeletePurchaseCommandValidator: AbstractValidator<DeletePurchaseCommand>
    {
        public DeletePurchaseCommandValidator() {
            RuleFor(command => command.PurchaseId)
                   .NotEqual(Guid.Empty)
                   .WithMessage("Purchase ID cannot be empty.");
        }
    }
}
