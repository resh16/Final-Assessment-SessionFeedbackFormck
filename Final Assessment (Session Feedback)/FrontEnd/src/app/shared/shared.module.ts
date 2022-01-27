import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './Components/register/register.component';
import { LoginComponent } from './Components/login/login.component';
import { ReactiveFormsModule,FormsModule } from '@angular/forms';
import { AuthHomeComponent } from './Components/auth-home/auth-home.component';
import { NavBarComponent } from './Components/nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';




@NgModule({
  declarations: [
    RegisterComponent,
    LoginComponent,
    AuthHomeComponent,
    NavBarComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    
    
  ]
})
export class SharedModule { }
