import { Injectable, Pipe } from '@angular/core';
import { VoterModel } from '../shared/voter.model';
import { CandidateModel } from '../shared/candidate.model';
import { VotingResultModel } from '../shared/voting-result.model';
import { UserType } from '../shared/EnumCollection/user-type';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { switchMap, tap } from 'rxjs/operators';

import { VotingWebService } from '../web-service/voting-web.service';
import { VoterBoothDataModel } from '../shared/voter-booth-data';

@Injectable({
  providedIn: 'root',
})
export class VotingService {
  private setUserTypeSubj = new Subject<UserType>();
  setUserTypeObs = this.setUserTypeSubj.asObservable();

  private refetchDataSubj = new BehaviorSubject(null);
  private saveVoterSubj = new Subject<VoterModel>();
  private saveCandidateSubj = new Subject<CandidateModel>();
  private markVotingSubj = new Subject<VotingResultModel>();

  constructor(private votingWebService: VotingWebService) {}

  votingObs$: Observable<VoterBoothDataModel> = this.refetchDataSubj.pipe(
    switchMap(() => {
      return this.votingWebService.getAllVotingData();
    })
  );

  saveVoterObs$: Observable<void> = this.saveVoterSubj.pipe(
    switchMap((data: VoterModel) => {
      return this.votingWebService.addVoter(data);
    })
  );

  saveCandidateObs$: Observable<void> = this.saveCandidateSubj.pipe(
    switchMap((data: CandidateModel) => {
      return this.votingWebService.addCandidate(data);
    })
  );

  markVotingObs$: Observable<void> = this.markVotingSubj.pipe(
    switchMap((data: VotingResultModel) => {
      return this.votingWebService.markVoting(data);
    })
  );

  setUserType = (userType: UserType) => {
    this.setUserTypeSubj.next(userType);
  };

  addUser = (name: string, type: UserType) => {
    if (type === UserType.voter) {
      this.saveVoterSubj.next({ id: 0, name: name, hasVoted: false });
    } else {
      this.saveCandidateSubj.next({ id: 0, name: name, votesGained: 0 });
    }
  };

  markVoting = (votingResult: VotingResultModel) => {
    this.markVotingSubj.next(votingResult);
  };

  reload() {
    this.refetchDataSubj.next(null);
  }
}
