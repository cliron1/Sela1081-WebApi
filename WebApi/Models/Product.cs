using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required, MinLength(3),]
        public string Name { get; set; }

        [Required, Range(0, 50000)]
        public float Price { get; set; }

        public int SalesQty { get; set; }

        public Statuses StatusID { get; set; }
    }
    public enum Statuses
    {
        Inactive = 0,
        Active = 5,
        Deleted = 99
    }
}

