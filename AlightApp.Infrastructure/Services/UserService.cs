namespace AlightApp.Infrastructure.Services
{
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using static Services.Common.AppConstant;
    public class UserService : IUserService
    {
        private readonly ILogger _logger;
        public UserService(ILogger logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Return all women having age < 25
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public IReadOnlyCollection<Persistence.Entities.User> GetWomenBelow25(List<Domain.User.User> request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var lstEntity = Map(request);   // It's required to follow the standards for service implementation

                var query = from u in lstEntity where u.gender == Female && u.age < 25 select u;

                return query.ToList() ?? null;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to retireve the user information: {ex.Message}");

                return null;
            }
        }

        /// <summary>
        /// Return the joungest man 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private Persistence.Entities.User GetYoungestMan(List<Domain.User.User> request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var lstEntity = Map(request);   // It's required to follow the standards for service implementation

                return lstEntity.OrderByDescending(m => m.age).FirstOrDefault() ?? null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to retireve the user information: {ex.Message}");

                return null;
            }
        }


        /// <summary>
        /// Return all men having age  > 40
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private IReadOnlyCollection<Persistence.Entities.User> GetMenAbove40(List<Domain.User.User> request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var lstEntity = Map(request);   // It's required to follow the standards for service implementation

                return lstEntity.Where(m => m.age > 40).ToList() ?? null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to retireve the user information: {ex.Message}");

                return null;
            }
        }

        /// <summary>
        /// Return all women having the Manager and Admin role
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private IReadOnlyCollection<Persistence.Entities.User> GetWomenHavingRoles(List<Domain.User.User> request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var lstEntity = Map(request);   // It's required to follow the standards for service implementation
                var query = (from u in lstEntity
                             where u.Roles.Any(m => m.role_id.Contains(Manager))
                             &&
                             u.Roles.Any(m => m.role_id.Contains(Admin))
                             select u);

                return query.ToList() ?? null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to retireve the user information: {ex.Message}");

                return null;
            }
        }

        private IReadOnlyCollection<Persistence.Entities.User> GetJoNameManagers(List<Domain.User.User> request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var lstEntity = Map(request);   // It's required to follow the standards for service implementation
                var query = (from u in lstEntity
                             where u.Roles.Any(m => m.role_id.Contains(Manager))
                             &&
                             u.first_name.ToLower().StartsWith("jo")
                             select u);

                return query.ToList() ?? null;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to retireve the user information: {ex.Message}");

                return null;
            }
        }

        private List<Persistence.Entities.User> Map(List<Domain.User.User> request)
        {
            // TODO : Map from List<Domain.User.User> to Persistence.Entities.User USING AUTOMAPPER 

            var lstEntity = new List<Persistence.Entities.User>();
            try
            {
                foreach (var item in request)
                {
                    lstEntity.Add(
                        new Persistence.Entities.User()
                        {
                            user_id = item.UserId,
                            first_name = item.FirstName,
                            last_name = item.LastName,
                            age = item.Age,
                            gender = item.Gender
                        }
                        );
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to map the user information: {ex.Message}");
            }
            return lstEntity;
        }
    }
}
