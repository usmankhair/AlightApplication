namespace AlightApp.Infrastructure.Persistence.Entities
{
    public class UserRoles : BaseEntity
    {
        public int user_id { get; set; }
        public string role_id { get; set; }
    }
}
