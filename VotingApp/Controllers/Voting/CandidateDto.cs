namespace VotingApp.Controllers.Voting
{
    public class CandidateDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int VotesGained { get;set; }
    }
}
