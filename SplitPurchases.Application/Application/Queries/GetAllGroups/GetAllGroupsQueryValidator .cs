using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Queries.GetAllGroups
{
    public class GetAllGroupsQueryValidator:AbstractValidator<GetAllGroupsQuery>
    {
        public GetAllGroupsQueryValidator()
        {
            RuleFor(query => query.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID cannot be empty.");
        }
    }
}
