using Flunt.Notifications;
using System;

namespace FDProductManagement.Domain.Core.Entities
{
    public abstract class Entity<T> : Notifiable
    {
        protected Entity() => Id = Guid.NewGuid();
        public Guid Id { get; private set; }
    }
}
