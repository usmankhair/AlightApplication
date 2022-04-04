namespace AlightApp.Application.Interfaces
{
    using AlightApp.Domain.User;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IUserAdapter
    {
        Task<IReadOnlyCollection<User>>
           GetWomenBelow25(
           List<User> request,
           CancellationToken cancellationToken
           );

        // Assume other tasks like GetYoungestMan, GetMenAbove40 etc

        //Task<IReadOnlyCollection<User>>
        //  GetYoungestMan(
        //  List<User> request,
        //  CancellationToken cancellationToken
        //  );

        Task<bool>
           CreateFile(
           List<User> request,
           CancellationToken cancellationToken
           );

    }
}
