import { Component, Input } from '@angular/core';
import { CandidateModel } from '../../shared/models/candidate.model';
import { VoterModel } from '../../shared/models/voter.model';
import { VotingNewService } from '../../service/voting-new.service';

@Component({
  selector: 'app-voting',
  templateUrl: './voting.component.html',
  styleUrls: ['./voting.component.scss'],
})
export class VotingComponent {
  @Input() candidateList: CandidateModel[];
  @Input() voterList: VoterModel[];

  voterId: number = -1;
  candidateId: number = -1;

  constructor(private votingService: VotingNewService) {}

  onSubmit() {
    this.votingService.markVoting({
      voterId: this.voterId,
      candidateId: this.candidateId,
    });

    this.voterId = -1;
    this.candidateId = -1;
  }
}
