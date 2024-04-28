using System.Runtime.CompilerServices;
using VotingApp.Core.Interfaces.Repositories;
using VotingApp.Core.Interfaces.Services;
using VotingApp.Core.Models;

[assembly: InternalsVisibleTo("VotingApp.Test")]
namespace VotingApp.Service.Voting
{
    public class VotingService : IVotingService
    {
        private readonly IVotingRepository _votingRepository;
        private const string _voterExists = "Voter Name already exists";
        private const string _candidateExists = "Candidate Name already exists";
        private const string _votedAlready = "Voter voted already";

        public VotingService(IVotingRepository votingRepository) {
            _votingRepository = votingRepository;
        }

        public void AddCandidate(Candidate candidate)
        {
            try
            {
                if (checkCandidateDataAlreadyExists(candidate.Name))
                {
                    throw new InvalidOperationException(_candidateExists);
                }
                List<Candidate> candidates = GetCandidates();

                candidate.Id = candidates != null ? candidates.Count + 1 : 1;

                _votingRepository.AddCandidate(candidate);

            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void AddVoter(Voter voter)
        {
            try
            {
                if (checkVoterDataAlreadyExists(voter.Name))
                {
                    throw new InvalidOperationException(_voterExists);
                }

                List<Voter> voters = GetVoters();
                voter.Id = voters != null ? voters.Count + 1 : 1;
                _votingRepository.AddVoter(voter);

            }
            catch (Exception)
            {
                throw;
            }

        }
        public void MarkVoting(VotingResults votingResults)
        {
            try
            {
                if (checkVotingDataAlreadyExists(votingResults.VoterId))
                {
                    throw new InvalidOperationException(_votedAlready);
                }
                _votingRepository.MarkVoting(votingResults);

            }
            catch (Exception)
            {

                throw;
            }
            
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

        internal List<Candidate> GetCandidates()
        {
           return _votingRepository.GetCandidates();
        }

        internal List<Voter> GetVoters()
        {
            return _votingRepository.GetVoters();
        }

        internal List<VotingResults> GetVotingResults()
        {
            return _votingRepository.GetVotingResults();
        }

       

        

        #region Private_Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="voterId"></param>
        /// <returns></returns>
        private bool checkVotingDataAlreadyExists(int voterId)
        {
            List<VotingResults> votingResults = GetVotingResults();

            return votingResults.Exists(v => v.VoterId == voterId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool checkVoterDataAlreadyExists(string name)
        {
            List<Voter> voters = GetVoters();

            return voters.Exists(v => v.Name.ToLower() == name.ToLower());

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool checkCandidateDataAlreadyExists(string name)
        {
            List<Candidate> candidates = GetCandidates();

            return candidates.Exists(v => v.Name.ToLower() == name.ToLower());
        }
        #endregion
    }
}
