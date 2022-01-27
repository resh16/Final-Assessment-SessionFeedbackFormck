import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateFeedbackComponent } from './feedback/create-feedback/create-feedback.component';
import { HomeComponent } from './feedback/home/home.component';
import { AuthGuard } from './shared/auth.guard';
import { AuthHomeComponent } from './shared/Components/auth-home/auth-home.component';
import { LoginComponent } from './shared/Components/login/login.component';
import { RegisterComponent } from './shared/Components/register/register.component';

const routes: Routes = [

  {path:'Home',component:HomeComponent,canActivate:[AuthGuard]},
  {path:'auth',component:AuthHomeComponent},
  {path:'register',component:RegisterComponent},
  {path:'login',component:LoginComponent},
  {path:'',component:LoginComponent},
  {path:'feedback',component:CreateFeedbackComponent,canActivate:[AuthGuard]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
