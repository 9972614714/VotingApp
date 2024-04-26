using VotingApp.Core.Models;

namespace VotingApp.Controllers.Voting
{
    public static class Mapper
    {
        public static List<VoterDto> ToVoterListDto(this List<Voter> voters, List<VotingResults> votingResults)
        {
            return voters.Select(v=> v.ToVoterDto(votingResults)).ToList();
        }

        public static VoterDto ToVoterDto(this Voter voter, List<VotingResults> votingResults)
        {
            return new VoterDto
            {
                Id = voter.Id,
                Name = voter.Name,
                HasVoted = votingResults != null && votingResults.Exists(v => v.VoterId == voter.Id)
            };
        }

        public static Voter ToVoterModel(this VoterDto voter)
        {
            return new Voter
            {
                Id = voter.Id,
                Name = voter.Name,
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow

            };
        }

        public static List<CandidateDto> ToCandidateListDto(this List<Candidate> candidates, List<VotingResults> votingResults)
        {
            return candidates.Select(c => c.ToCandidateDto(votingResults)).ToList();
        }

        public static CandidateDto ToCandidateDto(this Candidate candidate, List<VotingResults> votingResults)
        {
            return new CandidateDto
            {
                Id = candidate.Id,
                Name = candidate.Name,
                VotesGained =  votingResults.Count(v => v.CandidateId == candidate.Id)
            };
        }

        public static Candidate ToCandidateModel(this CandidateDto voter)
        {
            return new Candidate
            {
                Id = voter.Id,
                Name = voter.Name,
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow

            };
        }


        public static List<VotingResultDto> ToVotingResultListDto(this List<VotingResults> votingResults)
        {
            return votingResults.Select(v => v.ToVotingResultDto()).ToList();
        }
        public static VotingResultDto ToVotingResultDto(this VotingResults votingResults)
        {
            return new VotingResultDto
            {
                CandidateId = votingResults.CandidateId,
                VoterId = votingResults.VoterId
            };
        }

        public static VotingResults ToVotingResultsModel(this VotingResultDto votingResults)
        {
            return new VotingResults
            {
                CandidateId = votingResults.CandidateId,
                VoterId = votingResults.VoterId
            };
        }
    }
}
