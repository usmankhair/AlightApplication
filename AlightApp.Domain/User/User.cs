using System.Collections.Generic;

namespace AlightApp.Domain.User
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public ushort Age { get; set; }
        public IReadOnlyCollection<Roles> Roles { get; set; }


        public User(int userId, string firstName, string lastName, string gender, ushort age, IReadOnlyCollection<Roles> roles)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Age = age;
            Roles = roles;
        }
    }

    public class Roles
    {
        public string RoleId { get; set; }
        public string Name { get; set; }
    }
}
