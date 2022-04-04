namespace AlightApp.Infrastructure.Persistence.Entities
{
    using System;
    public abstract class BaseEntity
    {
        public bool active { get; set; }
        public DateTime created_at { get; set; }
        public string created_by { get; set; }
        public DateTime updated_at { get; set; }
        public string updated_by { get; set; }

    }
}
