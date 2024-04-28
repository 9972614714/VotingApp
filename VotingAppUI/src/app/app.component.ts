import { Component } from '@angular/core';
import { VoterModel } from './shared/models/voter.model';
import { CandidateModel } from './shared/models/candidate.model';
import { VoterBoothDataModel } from './shared/models/voter-booth-data';
import { UserType } from './shared/enum-collections/user-type';
import { Subscription } from 'rxjs';
import { VotingNewService } from './service/voting-new.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  voterList: VoterModel[] = [];
  candidateList: CandidateModel[] = [];
  userType = UserType.voter;

  votingObsSubscription: Subscription;
  setUserTypeObsSubscription: Subscription;
  errorSubscription: Subscription;
  errorMessage = '';

  constructor(public votingService: VotingNewService) {}

  ngOnInit() {
    this.votingObsSubscription = this.votingService.votingObs$.subscribe(
      (result: VoterBoothDataModel) => {
        this.voterList = result.votersData;
        this.candidateList = result.candidatesData;
      }
    );

    this.setUserTypeObsSubscription =
      this.votingService.setUserTypeSubj.subscribe((type: UserType) => {
        this.userType = type;
      });

    this.errorSubscription = this.votingService.errorMessageObs$.subscribe(
      (ex: string) => {
        this.errorMessage = ex;
      }
    );
  }

  ngOnDestroy() {
    this.votingObsSubscription.unsubscribe();
    this.setUserTypeObsSubscription.unsubscribe();
    this.errorSubscription.unsubscribe();
  }
}
