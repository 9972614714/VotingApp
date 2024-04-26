import { CandidateModel } from './candidate.model';
import { VoterModel } from './voter.model';
import { VotingResultModel } from './voting-result.model';

export interface VoterBoothDataModel {
  votersData: VoterModel[];
  candidatesData: CandidateModel[];
  resultsData: VotingResultModel[];
}
