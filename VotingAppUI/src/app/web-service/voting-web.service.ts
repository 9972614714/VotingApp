import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { VoterBoothDataModel } from '../shared/models/voter-booth-data';
import { VoterModel } from '../shared/models/voter.model';
import { CandidateModel } from '../shared/models/candidate.model';
import { VotingResultModel } from '../shared/models/voting-result.model';

@Injectable({
  providedIn: 'root',
})
export class VotingWebService {

  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) {}

  getAllVotingData(): Observable<VoterBoothDataModel> {
    return this.http.get<VoterBoothDataModel>(this.baseUrl + '/voting');
  }

  addVoter(voterData: VoterModel): Observable<any> {
    return this.http.post(this.baseUrl + '/voting/SaveVoter', voterData);
  }

  addCandidate(candidateData: CandidateModel): Observable<any> {
    return this.http.post(
      this.baseUrl + '/voting/SaveCandidate',
      candidateData
    );
  }

  markVoting(votingResult: VotingResultModel): Observable<any> {
    return this.http.post(this.baseUrl + '/voting/MarkVoting', votingResult);
  }
}
