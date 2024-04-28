

using VotingApp.Core.Models;

namespace VotingApp.Core.Interfaces.Services
{
    public interface IVotingService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="voter"></param>
        public void AddVoter(Voter voter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public void AddCandidate(Candidate candidate);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public VotingBoothData GetVotingBoothDatas();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="votingResults"></param>
        public void MarkVoting(VotingResults votingResults);
    }
}
