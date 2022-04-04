using AlightApp.Application.ViewModels;
using AutoFixture;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace AlightApp.Application.Queries.Users
{
    public class GetUserQuery : IRequest<ICollection<UserVM>>
    {
        public List<Domain.User.User> Users { get; set; }

    }
}
