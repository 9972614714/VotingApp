import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject, BehaviorSubject, Observable } from 'rxjs';
import { switchMap, catchError, take } from 'rxjs/operators';
import { UserType } from '../shared/enum-collections/user-type';
import { VoterBoothDataModel } from '../shared/models/voter-booth-data';
import { VotingResultModel } from '../shared/models/voting-result.model';
import { VotingWebService } from '../web-service/voting-web.service';

@Injectable({
  providedIn: 'root',
})
export class VotingNewService {
  setUserTypeSubj = new Subject<UserType>();
  private refetchDataSubj = new BehaviorSubject(null);
  private errorMessageSubj = new Subject<string>();

  constructor(private votingWebService: VotingWebService) {}

  errorMessageObs$: Observable<string> = this.errorMessageSubj.asObservable();

  votingObs$: Observable<VoterBoothDataModel> = this.refetchDataSubj.pipe(
    switchMap(() => {
      return this.votingWebService.getAllVotingData();
    })
  );

  setUserType = (userType: UserType) => {
    this.errorMessageSubj.next('');
    this.setUserTypeSubj.next(userType);
  };

  addUser = (name: string, type: UserType) => {
    this.errorMessageSubj.next('');
    let action$: Observable<any>;

    if (type === UserType.voter) {
      action$ = this.votingWebService.addVoter({
        id: 0,
        name: name,
        hasVoted: false,
      });
    } else {
      action$ = this.votingWebService.addCandidate({
        id: 0,
        name: name,
        votesGained: 0,
      });
    }
    action$
      .pipe(take(1), catchError(this.handleError))
      .subscribe((next) => this.reloadOnSuccess());
  };

  markVoting = (votingResult: VotingResultModel) => {
    this.errorMessageSubj.next('');
    this.votingWebService
      .markVoting(votingResult)
      .pipe(take(1), catchError(this.handleError))
      .subscribe((next) => this.reloadOnSuccess());
  };

  handleError = (error: HttpErrorResponse) => {
    this.errorMessageSubj.next(error.error);
    return [];
  };

  reloadOnSuccess() {
    this.refetchDataSubj.next(null);
  }
}
