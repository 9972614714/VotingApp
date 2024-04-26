using VotingApp.Core.Interfaces.Repositories;
using VotingApp.Core.Models;

namespace VotingApp.DataAccess.Repositories
{
    public class VotingRepository : IVotingRepository
    {
        public  List<Voter>  VoterList { get; set; } = new List<Voter>();
        public  List<Candidate> CandidateList { get; set; } = new List<Candidate> ();

        public  List<VotingResults> VotingResults { get; set; } = new List<VotingResults>();


        public void AddCandidate(Candidate candidate)
        {
            CandidateList.Add(candidate);

        }

        public void AddVoter(Voter voter)
        {
            VoterList.Add(voter);
        }

        public List<Candidate> GetCandidates()
        {
            return CandidateList;
        }

        public List<Voter> GetVoters()
        {
            return VoterList;
        }

        public List<VotingResults> GetVotingResults()
        {
            return VotingResults;
        }

        public void MarkVoting(VotingResults votingResults)
        {
            VotingResults.Add(votingResults);
        }
    }
}
