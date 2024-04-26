using VotingApp.Core.Interfaces.Repositories;
using VotingApp.Core.Interfaces.Services;
using VotingApp.Core.Models;

namespace VotingApp.Service.Voting
{
    public class VotingService : IVotingService
    {
        private readonly IVotingRepository _votingRepository;

        public VotingService(IVotingRepository votingRepository) {
            _votingRepository = votingRepository;
        }

        public void AddCandidate(Candidate candidate)
        {
            List<Candidate> candidates = GetCandidates();

            candidate.Id = candidates != null ? candidates.Count + 1 : 1;

            _votingRepository.AddCandidate(candidate);
            
        }

        public void AddVoter(Voter voter)
        {
            List<Voter> voters = GetVoters();
            voter.Id = voters != null ? voters.Count + 1 : 1;
            _votingRepository.AddVoter(voter);
        }

        public List<Candidate> GetCandidates()
        {
           return _votingRepository.GetCandidates();
        }

        public List<Voter> GetVoters()
        {
            return _votingRepository.GetVoters();
        }

        public List<VotingResults> GetVotingResults()
        {
            return _votingRepository.GetVotingResults();
        }

        public VotingBoothData GetVotingBoothDatas()
        {
            return new VotingBoothData
            {
                Voters = GetVoters(),
                Candidates = GetCandidates(),
                VotingResultData = GetVotingResults()
            };
        }

        public void MarkVoting(VotingResults votingResults)
        {
            _votingRepository.MarkVoting(votingResults);
        }
    }
}
