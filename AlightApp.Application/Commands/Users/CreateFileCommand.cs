using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlightApp.Application.Commands.Users
{
    public class CreateFileCommand : IRequest<bool>
    {
        public List<Domain.User.User> Users { get; set; }

    }
}
