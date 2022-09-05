using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entities
{
    public abstract class Entity: IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            DateRegistration = DateTime.Now;
        }
        [Key()]
        public Guid Id { get; private set; }

        public DateTime DateRegistration { get; private set; }
        public DateTime DateAlteration { get; private set; }

        public void setDateAlteration()
        {
            DateAlteration = DateTime.Now;
        }

        public bool Equals(Entity? other)
        {
            return Id == other.Id;
        }
    }
}
