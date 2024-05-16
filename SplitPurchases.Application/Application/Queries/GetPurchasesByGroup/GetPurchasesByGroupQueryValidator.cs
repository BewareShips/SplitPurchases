using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Queries.GetPurchasesByGroup
{
    public class GetPurchasesByGroupQueryValidator:AbstractValidator<GetPurchasesByGroupQuery>
    {
        public GetPurchasesByGroupQueryValidator()
        {
            RuleFor(query => query.GroupId)
            .NotEqual(Guid.Empty)
            .WithMessage("Group ID cannot be empty.");
        }
    }
}
