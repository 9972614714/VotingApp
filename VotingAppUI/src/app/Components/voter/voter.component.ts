import { Component, Input } from '@angular/core';
import { VoterModel } from '../../shared/models/voter.model';
import { UserType } from '../../shared/enum-collections/user-type';
import { VotingNewService } from '../../service/voting-new.service';

@Component({
  selector: 'app-voter',
  templateUrl: './voter.component.html',
  styleUrls: ['./voter.component.scss'],
})
export class VoterComponent {
  @Input() voterList: VoterModel[];

  constructor(private votingService: VotingNewService) {}

  showVoterCreationSection() {
    this.votingService.setUserType(UserType.voter);
  }
}
