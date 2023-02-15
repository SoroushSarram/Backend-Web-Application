using System.ComponentModel.DataAnnotations;

namespace Soroush_Sarram_2031004_WebServer2.Models
{
    public class User
    {
        [Key]
        public string UId 
        {
            get; set; 
        }

        [Required]
        public string Name 
        { 
            get; set;
        }

        [Required]
        public string Email 
        {
            get; set;
        }

        [Required]
        public string Password 
        { 
            get; set;
        }

        public User()
        {
            UId = Guid.NewGuid().ToString();
        }
    }
}
