namespace AlightApp.Infrastructure.Services
{
    using System.Collections.Generic;
    using System.Threading;
    public interface IUserRoleService
    {
        public IReadOnlyCollection<Persistence.Entities.UserRoles> Get(int userId, List<Domain.User.User> request, CancellationToken cancellationToken);
    }
}
