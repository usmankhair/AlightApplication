using AutoFixture;
using System.Collections.Generic;

namespace AlightApp.Application.Tests
{
    /// <summary>
    /// To setup the mock objects
    /// </summary>
    public abstract class BaseTest
    {
        protected List<Domain.User.User> _Request = new List<Domain.User.User>();
        public BaseTest()
        {
            var fixture = new Fixture();

            _Request.AddRange(fixture.Build<Domain.User.User>()
             .With(m => m.Age, 10)
             .CreateMany(5)
             );

            _Request.AddRange(fixture.Build<Domain.User.User>()
            .With(m => m.Age, 69)
            .CreateMany(2)
            );

            _Request.AddRange(fixture.Build<Domain.User.User>()
           .With(m => m.Roles, new List<Domain.User.Roles>()
                    {
                     new Domain.User.Roles() {  RoleId = "manager", Name = "Manager"},
                    new Domain.User.Roles() {  RoleId = "admin", Name = "Admin"}

                    })
           .With(m => m.FirstName, "John")
            .CreateMany(6)
            );

            _Request.Add(fixture.Build<Domain.User.User>()
                    .With(m => m.Roles, new List<Domain.User.Roles>()
                    {
                    new Domain.User.Roles() {  RoleId = "employee", Name = "Employee"},
                    new Domain.User.Roles() {  RoleId = "admin", Name = "Admin"}

                    })
                    .With(m => m.Age, 21)
                    .With(m => m.Gender, "female")
                    .Create()
                );

            _Request.Add(fixture.Build<Domain.User.User>()
                    .With(m => m.Roles, new List<Domain.User.Roles>()
                    {
                   new Domain.User.Roles() {  RoleId = "manager", Name = "Manager"},
                    new Domain.User.Roles() {  RoleId = "employee", Name = "Employee"},
                    new Domain.User.Roles() {  RoleId = "admin", Name = "Admin"}

                    })
                    .With(m => m.Age, 34)
                    .With(m => m.Gender, "female")
                    .Create()
                );

            _Request.Add(fixture.Build<Domain.User.User>()
                    .With(m => m.Roles, new List<Domain.User.Roles>()
                    {
                   new Domain.User.Roles() {  RoleId = "manager", Name = "Manager"},
                    new Domain.User.Roles() {  RoleId = "admin", Name = "Admin"}

                    })
                    .With(m => m.Age, 41)
                    .With(m => m.Gender, "female")
                    .Create()
                );

            _Request.Add(fixture.Build<Domain.User.User>()
             .With(m => m.Roles, new List<Domain.User.Roles>()
             {
                new Domain.User.Roles() {  RoleId = "admin", Name = "Admin"},

             })
             .With(m => m.Age, 55)
             .With(m => m.Gender, "male")
             .Create()
             );

            _Request.Add(fixture.Build<Domain.User.User>()
           .With(m => m.Roles, new List<Domain.User.Roles>()
           {
                new Domain.User.Roles() {  RoleId = "admin", Name = "Admin"},

           })
           .With(m => m.Age, 54)
           .With(m => m.Gender, "male")
           .Create());
        }
    }
}
