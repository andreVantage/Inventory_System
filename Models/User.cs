using System.ComponentModel.DataAnnotations;

namespace Inventory_System.Models
{
    public class User : Audit
    {
        public int Id { get; set; }
        public required string UserName { get; set; } = "admin";
        public string? Email { get; set; }
        public required string Password { get; set; } = "admin";
        public  bool IsAdmin { get; set; } 


        
    }
}
