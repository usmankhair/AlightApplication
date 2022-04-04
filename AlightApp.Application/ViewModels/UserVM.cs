namespace AlightApp.Application.ViewModels
{
    public class UserVM
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public ushort Age { get; set; }

        public UserVM(int userId, string firstName, string lastName, string gender, ushort age)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Age = age;
        }
    }
}
