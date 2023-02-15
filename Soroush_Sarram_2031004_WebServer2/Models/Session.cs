using System.ComponentModel.DataAnnotations;

namespace Soroush_Sarram_2031004_WebServer2.Models
{
    public class Session
    {
        [Key]
        public string Token 
        { 
            get; set; 
        }

        [Required]
        public string Email 
        { 
            get; set; 
        }

        public Session()
        {
            Token = Guid.NewGuid().ToString();
        }
    }
}
