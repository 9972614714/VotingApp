import { Component, Input } from '@angular/core';
import { CandidateModel } from '../../shared/models/candidate.model';
import { UserType } from '../../shared/enum-collections/user-type';
import { VotingNewService } from '../../service/voting-new.service';

@Component({
  selector: 'app-candidate-list',
  templateUrl: './candidate-list.component.html',
  styleUrls: ['./candidate-list.component.scss'],
})
export class CandidateListComponent {
  @Input() candidateList: CandidateModel[];

  constructor(private votingService: VotingNewService) {}

  showCandidateCreationSection() {
    this.votingService.setUserType(UserType.candidate);
  }
}
