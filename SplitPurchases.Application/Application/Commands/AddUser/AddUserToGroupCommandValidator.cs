using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.AddUser
{
    public class AddUserToGroupCommandValidator:AbstractValidator<AddUserToGroupCommand>
    {
        public AddUserToGroupCommandValidator()
        {
            RuleFor(command => command.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("UserId cannot be empty.");

            RuleFor(command => command.GroupId)
                .NotEqual(Guid.Empty)
                .WithMessage("GroupId cannot be empty.");
        }
    }
}
