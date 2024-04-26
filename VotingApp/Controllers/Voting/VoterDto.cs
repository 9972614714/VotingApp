namespace VotingApp.Controllers.Voting
{
    public class VoterDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool HasVoted { get; set; }

    }
}
