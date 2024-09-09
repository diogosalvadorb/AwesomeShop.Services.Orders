using System;

namespace AwesomeShop.Services.Core.Entities
{
    public class Customer : IEntityBase
    {
        public Customer(Guid id, string fullName, string email)
        {
            Id = id;
            FullName = fullName;
            Email = email;
        }

        public Guid Id { get; protected set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
