using System.ComponentModel.DataAnnotations.Schema;
namespace WEBPROJECT2.Models
{
    public class Tokens
    {
        public int ID { get; set; }

        public int userID { get; set; }

        public string? Token { get; set; }

        public DateTime ExpiryTime { get; set; }
    }
}