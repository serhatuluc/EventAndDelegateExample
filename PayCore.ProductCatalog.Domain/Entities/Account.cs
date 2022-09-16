﻿using System;


namespace PayCore.ProductCatalog.Domain.Entities
{
    public class Account
    {
        public virtual Guid Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Role { get; set; } = "User";
        public virtual DateTime LastActivity { get; set; } = DateTime.Now;
    }
}
