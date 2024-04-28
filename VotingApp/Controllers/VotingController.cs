using Microsoft.AspNetCore.Mvc;
using VotingApp.Controllers.Voting;
using VotingApp.Core.Interfaces.Services;

namespace VotingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VotingController : ControllerBase
    {
        private readonly IVotingService _votingService;
        private const string _voterNameInValid = "Voter Name is empty or null";
        private const string _candidateNameInValid = "Candidate is empty or null";

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
            if (checkVoterDataInvalid(voter))
            {
                return BadRequest(_voterNameInValid);
            }

            try
            {
                var dataToSave = voter.ToVoterModel();

                _votingService.AddVoter(dataToSave);

                return Ok(voter);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveCandidate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VotingDto> SaveCandidate([FromBody] CandidateDto candidate)
        {
            if (checkCandidateDataInvalid(candidate))
            {
                return BadRequest(_candidateNameInValid);
            }
            try
            {
                var dataToSave = candidate.ToCandidateModel();

                _votingService.AddCandidate(dataToSave);

                return Ok(candidate);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
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

            try
            {
                var dataToSave = votingResult.ToVotingResultsModel();

                _votingService.MarkVoting(dataToSave);

                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
            
          
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

    }
}