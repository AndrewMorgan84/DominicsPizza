using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DominicsPizza.Entities
{
    public class Cart
    {
        public Cart()
        {
            Items = new List<CartItem>();
            CreatedDate = DateTime.Now;
            IsActive = true;
        }

        [Key]
        public Guid Id { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual List<CartItem> Items { get; set; }

        public bool IsActive { get; set; }
    }
}
