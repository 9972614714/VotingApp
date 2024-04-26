import { Component, Input } from '@angular/core';
import { VoterModel } from '../shared/voter.model';
import { VotingService } from '../service/voting.service';
import { UserType } from '../shared/EnumCollection/user-type';

@Component({
  selector: 'app-voter',
  templateUrl: './voter.component.html',
  styleUrls: ['./voter.component.scss'],
})
export class VoterComponent {
  @Input() voterList: VoterModel[];

  constructor(private votingService: VotingService) {}

  showVoterCreationSection() {
    this.votingService.setUserType(UserType.voter);
  }
}
