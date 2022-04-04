namespace AlightApp.Application.Queries.Users
{
    using AlightApp.Application.Interfaces;
    using AlightApp.Application.ViewModels;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUserQueryHanlder : IRequestHandler<GetUserQuery, ICollection<UserVM>>
    {
        private readonly IUserAdapter _userAdapter;

        public GetUserQueryHanlder(IUserAdapter userAdapter)
        {
            _userAdapter = userAdapter;
        }

        public async Task<ICollection<UserVM>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userAdapter.GetWomenBelow25(request.Users, cancellationToken);
            ICollection<UserVM> result = users.Select(a =>
            new UserVM(a.UserId, a.FirstName, a.LastName, a.Gender, a.Age)
            ).ToList();
            return result;
        }
    }
}
