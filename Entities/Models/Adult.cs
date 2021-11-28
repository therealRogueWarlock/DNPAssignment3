using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Adult : Person
    {
        
        [Required]
        public Job Job { get; set; }


        public Adult()
        {
            Job = new();
        }
        
    }
}