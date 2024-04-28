import { Component, Input, OnInit } from '@angular/core';
import { UserType } from '../../shared/enum-collections/user-type';
import { VotingNewService } from '../../service/voting-new.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.scss'],
})
export class AddUserComponent implements OnInit {
  UserTypeEnum: typeof UserType = UserType;
  @Input() userType: UserType = UserType.voter;
  name: string = '';

  constructor(private votingService: VotingNewService) {}

  ngOnInit(): void {}

  onSave = (name: string) => {
    this.votingService.addUser(name, this.userType);
    this.name = '';
  };
}
