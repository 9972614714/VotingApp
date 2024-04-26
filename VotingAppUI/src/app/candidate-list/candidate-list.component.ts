import { Component, Input } from '@angular/core';
import { CandidateModel } from '../shared/candidate.model';
import { VotingService } from '../service/voting.service';
import { UserType } from '../shared/EnumCollection/user-type';

@Component({
  selector: 'app-candidate-list',
  templateUrl: './candidate-list.component.html',
  styleUrls: ['./candidate-list.component.scss'],
})
export class CandidateListComponent {
  @Input() candidateList: CandidateModel[];

  constructor(private votingService: VotingService) {}

  showCandidateCreationSection() {
    this.votingService.setUserType(UserType.candidate);
  }
}
