
using System.ComponentModel.DataAnnotations;

namespace VotingApp.Core.Models
{
    public class Voter
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        
        public string CreatedBy { get; set;} = string.Empty;

        public DateTime CreatedDate { get; set; }

    }
}
