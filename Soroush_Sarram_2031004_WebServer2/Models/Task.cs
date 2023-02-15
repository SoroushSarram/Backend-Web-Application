using System.ComponentModel.DataAnnotations;

namespace Soroush_Sarram_2031004_WebServer2.Models
{
    public class Task
    {
        [Key]
        public string TaskUId 
        { 
            get; set;
        }

        [Required]
        public string CreatedByUid 
        { 
            get; set; 
        }

        [Required]
        public string CreatedByName 
        { 
            get; set; 
        }

        [Required]
        public string AssignedToUid 
        { 
            get; set; 
        }

        [Required]
        public string AssignedToName 
        { 
            get; set;
        }

        [Required]
        public string Description
        { 
            get; set; 
        }

        [Required]
        public bool Done 
        { 
            get; set; 
        }
        public Task()
        {
            TaskUId = Guid.NewGuid().ToString();
            Done = false;
        }
    }
}
