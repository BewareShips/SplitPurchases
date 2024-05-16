using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.CreateUser
{
    public class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(command => command.UserName)
                .NotEmpty()
                .WithMessage("User name cannot be empty.")
                .MinimumLength(3)
                .WithMessage("User name must be at least 3 characters long.");

            RuleFor(command => command.Email)
                .NotEmpty()
                .WithMessage("Email cannot be empty.")
                .EmailAddress()
                .WithMessage("Invalid email format.");
        }
    }
}
