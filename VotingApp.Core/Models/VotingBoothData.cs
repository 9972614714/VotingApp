
namespace VotingApp.Core.Models
{
    public class VotingBoothData
    {
        public List<Voter> Voters { get; set; } =   new List<Voter>();

        public List<Candidate> Candidates { get; set; } =  new List<Candidate> { };

        public List<VotingResults> VotingResultData{ get; set; } = new List<VotingResults> { };

    }
}
