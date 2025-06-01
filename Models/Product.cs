using System.ComponentModel.DataAnnotations;

namespace Inventory_System.Models
{
    public class Product : Audit
    {
        public int Id { get; set; }
     
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? Category { get; set; }
        public bool IsActive { get; set; }


    }
}
