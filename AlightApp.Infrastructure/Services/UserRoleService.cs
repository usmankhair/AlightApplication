namespace AlightApp.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    public class UserRoleService : IUserRoleService
    {
        public IReadOnlyCollection<Persistence.Entities.UserRoles> Get(int userId, List<Domain.User.User> request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException();

            
            var query = request.FirstOrDefault(m => m.UserId == userId).Roles.Select(
                k => new Persistence.Entities.UserRoles()
                {
                    user_id = userId,
                    role_id = k.RoleId
                }
            );

            return query?.ToList() ?? null;
        }
    }
}
