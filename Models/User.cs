using System.ComponentModel.DataAnnotations;
namespace WEBPROJECT2.Models
{
    public class User{
        public int ID { get; set; }
        public string? UserName { get; set; } 
        public string? Password { get; set; }
    }
}