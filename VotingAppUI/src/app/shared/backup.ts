// import { Component } from '@angular/core';
// import { VoterModel } from './shared/models/voter.model';
// import { CandidateModel } from './shared/models/candidate.model';
// import { VotingService } from './service/voting.service';
// import { VoterBoothDataModel } from './shared/models/voter-booth-data';
// import { UserType } from './shared/enum-collections/user-type';
// import { Subscription } from 'rxjs';
// import { VotingNewService } from './service/voting-new.service';

// @Component({
//   selector: 'app-root',
//   templateUrl: './app.component.html',
//   styleUrls: ['./app.component.scss'],
// })
// export class AppComponent {
//   voterList: VoterModel[] = [];
//   candidateList: CandidateModel[] = [];
//   userType = UserType.voter;

//   votingObsSubscription:Subscription;
//   setUserTypeObsSubscription:Subscription;
//   errorMessage='';



//   constructor(public votingService: VotingNewService) {}

//   ngOnInit() {


//   voterList: VoterModel[] = [];
//   candidateList: CandidateModel[] = [];
//   userType = UserType.voter;

//   votingObsSubscription:Subscription;
//   // saveVoterObsSubscription:Subscription;
//   // saveCandidateObsSubscription:Subscription;
//   // saveMarkVotingObsSubscription:Subscription;
//   setUserTypeObsSubscription:Subscription;



//   constructor(private votingService: VotingNewService) {}

//   ngOnInit() {
//     this.votingObsSubscription= this.votingService.votingObs$.subscribe((result: VoterBoothDataModel) => {
//       this.voterList = result.votersData;
//       this.candidateList = result.candidatesData;
//     });

//     this.setUserTypeObsSubscription = this.votingService.setUserTypeSubj.subscribe((type: UserType) => {
//       this.userType = type;
//     });
//   }

//  ngOnInit() {
//     this.votingObsSubscription= this.votingService.votingObs$.subscribe((result: VoterBoothDataModel) => {
//       this.voterList = result.votersData;
//       this.candidateList = result.candidatesData;
//     });

//     this.saveVoterObsSubscription = this.votingService.saveVoterObs$.subscribe(() => {
//       this.votingService.reload();
//     });

//     this.saveCandidateObsSubscription = this.votingService.saveCandidateObs$.subscribe(() => {
//       this.votingService.reload();
//     });

//     this.saveMarkVotingObsSubscription = this.votingService.markVotingObs$.subscribe(() => {
//       this.votingService.reload();
//     });

//     this.setUserTypeObsSubscription = this.votingService.setUserTypeObs$.subscribe((type: UserType) => {
//       this.userType = type;
//     });
//   }

//   ngOnDestroy() {
//     this.votingObsSubscription.unsubscribe();
//     this.saveCandidateObsSubscription.unsubscribe();
//     this.saveMarkVotingObsSubscription.unsubscribe();
//     this.setUserTypeObsSubscription.unsubscribe();
//     this.saveVoterObsSubscription.unsubscribe();
//   }

//   getErrorMessage() {
//     return this.votingService.errorMessageObs$;
//   }

// }
