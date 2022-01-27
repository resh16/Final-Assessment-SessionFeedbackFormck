import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateFeedbackComponent } from './create-feedback/create-feedback.component';
import { HomeComponent } from './home/home.component';
import { SessionListComponent } from './session-list/session-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { Ng2OrderModule } from 'ng2-order-pipe';
import { NgxPaginationModule } from 'ngx-pagination';
import { Ng2SearchPipeModule } from 'ng2-search-filter';



@NgModule({
  declarations: [
    CreateFeedbackComponent,
    HomeComponent,
    SessionListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule,
    Ng2OrderModule,
    NgxPaginationModule,
    Ng2SearchPipeModule
    
  ]
})
export class FeedbackModule { }
