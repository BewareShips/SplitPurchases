﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitPurchases.Application.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }

        public CreateUserCommand(string userName, string email)
        {
            UserName = userName;
            Email = email;

        }
    }
}
