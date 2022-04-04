namespace AlightApp.Infrastructure.Services
{
    using System.Collections.Generic;
    using System.Threading;
    public interface IUserService
    {
        public IReadOnlyCollection<Persistence.Entities.User> GetWomenBelow25(List<Domain.User.User> request, CancellationToken cancellationToken);
    }
}
