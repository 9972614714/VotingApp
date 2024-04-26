namespace VotingApp.Controllers.Voting
{
    public class VotingDto
    {
        public List<VoterDto> VotersData { get; set; } = new List<VoterDto>();

        public List<CandidateDto> CandidatesData { get; set; } = new List<CandidateDto> { };

        public List<VotingResultDto> ResultsData { get; set; } = new List<VotingResultDto> { };
    }
}
