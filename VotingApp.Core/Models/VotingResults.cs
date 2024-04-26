
namespace VotingApp.Core.Models
{
    public class VotingResults
    {
        public int ResultId { get; set; }

        public int VoterId { get; set; }

        public int CandidateId { get; set; }

        public DateTime VotedDate { get; set; }
    }
}
