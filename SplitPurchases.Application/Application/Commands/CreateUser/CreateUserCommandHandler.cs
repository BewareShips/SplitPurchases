using MediatR;
using SplitPurchases.Application.Application.Services.Balance;
using SplitPurchases.Application.Interfaces;
using SplitPurchases.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Name = request.UserName,
                Email = request.Email,
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            await _bala
            return user.UserId;
        }
    }
}
