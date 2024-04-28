import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {VotingComponent} from './Components/voting/voting.component';
import { VoterComponent } from './Components/voter/voter.component';
import { CandidateListComponent } from './Components/candidate-list/candidate-list.component';
import { AddUserComponent } from './Components/add-user/add-user.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    VoterComponent,
    CandidateListComponent,
    VotingComponent,
    AddUserComponent,
    VotingComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


