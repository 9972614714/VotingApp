using Microsoft.AspNetCore.Mvc;
using VotingApp.Controllers.Voting;
using VotingApp.Core.Interfaces.Services;
using VotingApp.Core.Models;

namespace VotingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VotingController : ControllerBase
    {
        private readonly IVotingService _votingService;

        public VotingController(IVotingService votingService)
        {
            _votingService = votingService;
        }

        [HttpGet(Name = "GetVotingData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<VotingDto> GetVotingData()
        {
            var result = new VotingDto();
            var votingBoothData = _votingService.GetVotingBoothDatas();

            result.ResultsData = votingBoothData.VotingResultData.ToVotingResultListDto();
            result.VotersData = votingBoothData.Voters.ToVoterListDto(votingBoothData.VotingResultData);
            result.CandidatesData = votingBoothData.Candidates.ToCandidateListDto(votingBoothData.VotingResultData);

            return Ok(result);
        }

        [HttpPost("SaveVoter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public ActionResult<VotingDto> SaveVoter([FromBody] VoterDto voter)
        {
            if(checkVoterDataInvalid(voter))
            {
                return BadRequest();
            }

            if(checkVoterDataAlreadyExists(voter.Name))
            {
                return BadRequest();
            }
            var dataToSave = voter.ToVoterModel();

            _votingService.AddVoter(dataToSave);

            return Ok(voter);
        }

        [HttpPost("SaveCandidate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VotingDto> SaveCandidate([FromBody] CandidateDto candidate)
        {
            if (checkCandidateDataInvalid(candidate))
            {
                return BadRequest();
            }

            if (checkCandidateDataAlreadyExists(candidate.Name))
            {
                return BadRequest();
            }
            var dataToSave = candidate.ToCandidateModel();

            _votingService.AddCandidate(dataToSave);

            return Ok(candidate);
        }

        [HttpPost("MarkVoting")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VotingDto> MarkVoting([FromBody] VotingResultDto votingResult)
        {
            if(checkVotingDataInvalid(votingResult))
            {
                return BadRequest();
            }
            
            if (checkVotingDataAlreadyExists(votingResult.VoterId))
            {
                return BadRequest();
            }
            var dataToSave = votingResult.ToVotingResultsModel();

            _votingService.MarkVoting(dataToSave);

            return Ok();
        }

        #region Private_Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="voterId"></param>
        /// <returns></returns>
        private bool checkVotingDataAlreadyExists(int voterId)
        {
            List<VotingResults> votingResults = _votingService.GetVotingResults();

            return votingResults.Exists(v => v.VoterId == voterId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool checkVoterDataAlreadyExists(string name)
        {
            List<Voter> voters = _votingService.GetVoters();

            return voters.Exists(v => v.Name.ToLower() == name.ToLower());
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool checkCandidateDataAlreadyExists(string name)
        {
            List<Candidate> candidates = _votingService.GetCandidates();

            return candidates.Exists(v => v.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="votingResult"></param>
        /// <returns></returns>
        private bool checkVotingDataInvalid(VotingResultDto votingResult)
        {
            if (votingResult == null || votingResult.CandidateId == 0 || votingResult.VoterId == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="voter"></param>
        /// <returns></returns>
        private bool checkVoterDataInvalid(VoterDto voter)
        {
            if (voter == null || voter.Name == null || voter.Name.Trim().Length == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        private bool checkCandidateDataInvalid(CandidateDto candidate)
        {
            if (candidate == null || candidate.Name == null || candidate.Name.Trim().Length == 0)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}