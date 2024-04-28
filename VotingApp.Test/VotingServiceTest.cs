using VotingApp.Core.Models;
using VotingApp.DataAccess.Repositories;
using VotingApp.Service.Voting;

namespace VotingApp.Test
{
    public class Tests
    {
        private const string _voterExists = "Voter Name already exists";
        private const string _candidateExists = "Candidate Name already exists";
        private const string _votedAlready = "Voter voted already";

        private VotingService _votingService { get; set; } = null!;
        [SetUp]
        public void Setup()
        {
            _votingService = new VotingService(new VotingRepository());
        }

        [Test]
        public void AddVoter_SuccessTest()
        {
            //Assign
            Voter dataToSave = new Voter { Id = 0, Name = "Arun", CreatedBy = "admin", CreatedDate = DateTime.UtcNow };
            //Act
            _votingService.AddVoter(dataToSave);
            //Assert
            Assert.That(_votingService.GetVoters().Count, Is.EqualTo(1));
        }

        [Test]
        public void AddVoter_FaliureTest_VoterAlreadyExists()
        {
            //Assign
            Voter dataToSave = new Voter { Id = 0, Name = "Kumar", CreatedBy = "admin", CreatedDate = DateTime.UtcNow, };
            //Act
            _votingService.AddVoter(dataToSave);

            //Assert
            Exception ex = Assert.Throws<InvalidOperationException>(
              () => _votingService.AddVoter(dataToSave));

            Assert.That(ex.Message, Is.EqualTo(_voterExists));
        }

        [Test]
        public void AddCandidate_SuccessTest()
        {
            //Assign
            Candidate dataToSave = new Candidate { Id = 0, Name = "Kumar", CreatedBy = "admin", CreatedDate = DateTime.UtcNow, };
            //Act
            _votingService.AddCandidate(dataToSave);
            //Assert
            Assert.That(_votingService.GetCandidates().Count, Is.EqualTo(1));
        }

        [Test]
        public void AddCandidate_FaliureTest_CandidateAlreadyExists()
        {
            //Assign
            Candidate dataToSave = new Candidate { Id = 0, Name = "Kumar", CreatedBy = "admin", CreatedDate = DateTime.UtcNow, };

            //Act
            _votingService.AddCandidate(dataToSave);

            //Assert
            Exception ex = Assert.Throws<InvalidOperationException>(
              () => _votingService.AddCandidate(dataToSave));

            Assert.That(ex.Message, Is.EqualTo(_candidateExists));
        }

        [Test]
        public void MarkVoting_SuccessTest()
        {
            //Assign
            Voter voterDataToSave = new Voter { Id = 0, Name = "Kumar", CreatedBy = "admin", CreatedDate = DateTime.UtcNow, };
            Candidate candidateToSave = new Candidate { Id = 0, Name = "Arun", CreatedBy = "admin", CreatedDate = DateTime.UtcNow, };

            VotingResults dataToSave = new VotingResults { CandidateId = 1, VoterId = 1, VotedDate = DateTime.Now };

            //Act
            _votingService.AddVoter(voterDataToSave);
            _votingService.AddCandidate(candidateToSave);

            _votingService.MarkVoting(dataToSave);

            //Assert
            Assert.That(_votingService.GetVotingResults().Count, Is.EqualTo(1));
        }

        [Test]
        public void MarkVoting_FailureTest_VotingAlreadyExist()
        {
            //Assign
            Voter voterDataToSave = new Voter { Id = 0, Name = "Kumar", CreatedBy = "admin", CreatedDate = DateTime.UtcNow, };
            Candidate candidateToSave = new Candidate { Id = 0, Name = "Arun", CreatedBy = "admin", CreatedDate = DateTime.UtcNow, };

            VotingResults dataToSave = new VotingResults { CandidateId = 1, VoterId = 1, VotedDate = DateTime.Now };

            //Act
            _votingService.AddVoter(voterDataToSave);
            _votingService.AddCandidate(candidateToSave);
            _votingService.MarkVoting(dataToSave);


            Exception ex = Assert.Throws<InvalidOperationException>(
            () => _votingService.MarkVoting(dataToSave));

            //Assert

            Assert.That(ex.Message, Is.EqualTo(_votedAlready));
        }


    }
}