namespace AlightApp.Infrastructure.Adapters
{
    using AlightApp.Application.Interfaces;
    using AlightApp.Domain.User;
    using AlightApp.Infrastructure.External.Files;
    using AlightApp.Infrastructure.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class UserAdapter : IUserAdapter
    {
        private readonly IUserService _userService;
        private readonly IFileHandlerService _fileHanlderService;
        private readonly IUserRoleService _userRoleService;
        public UserAdapter(IUserService userService, IUserRoleService userRoleService, IFileHandlerService fileHanlderService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _fileHanlderService = fileHanlderService;
        }

        public async Task<IReadOnlyCollection<User>> GetWomenBelow25(List<User> request, CancellationToken cancellationToken)
        {
            var result = _userService.GetWomenBelow25(request, cancellationToken);

            return result.Select(a =>
            new User(
                a.user_id,
                a.first_name,
                a.last_name,
                a.gender,
                a.age,
                request.FirstOrDefault(m => m.UserId == a.user_id).Roles // TODO (_userRoleService) : We can get the Roles collection from Role Service as per design UserRoleService based on the user id and then get the Roles
                )
            ).ToList();
        }

        public async Task<bool> CreateFile(List<User> request, CancellationToken cancellationToken)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var user in request)
            {
                sb.Append(
                    $"{user.FirstName} {user.LastName} is {user.Age} old. It is a {user.Gender}. He has the following roles ({string.Join(',', user.Roles.Select(m => m.Name).ToArray())}){Environment.NewLine}"
                    );
            }

            return await _fileHanlderService.CreateFile(sb.ToString());
        }
    }
}
