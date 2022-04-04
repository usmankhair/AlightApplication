namespace AlightApp.Infrastructure.Persistence.Entities
{
    using System.Collections.Generic;
    public class User : BaseEntity
    {
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }
        public ushort age { get; set; }
        public IReadOnlyCollection<Roles> Roles { get; set; }
    }
}
