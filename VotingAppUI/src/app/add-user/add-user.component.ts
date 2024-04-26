import { Component, Input, OnInit } from '@angular/core';
import { VotingService } from '../service/voting.service';
import { UserType } from '../shared/EnumCollection/user-type';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.scss'],
})
export class AddUserComponent implements OnInit {
  UserTypeEnum: typeof UserType = UserType;
  @Input() userType: UserType = UserType.voter;
  name: string = '';

  constructor(private votingService: VotingService) {}

  ngOnInit(): void {}

  onSave = (name: string) => {
    this.votingService.addUser(name, this.userType);
    this.name = '';
  };
}
