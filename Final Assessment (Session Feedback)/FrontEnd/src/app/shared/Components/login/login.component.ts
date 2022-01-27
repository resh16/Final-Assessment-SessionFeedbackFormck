import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiServiceService } from '../../api-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public service:ApiServiceService, public router:Router) { }

  ngOnInit(): void {
  }

  formModel = {
    UserName:'',
    Password:''
  }


  OnSubmit(form:NgForm){
   
    debugger
    this.service.Login(form.value).subscribe(
      (res:any)=>{
      localStorage.setItem('token',res.token);
       var payLoad = JSON.parse(window.atob(localStorage.getItem('token')!.split('.')[1]));
       var userRole = payLoad["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
        alert("Successfully LoggedIn");
        this.router.navigateByUrl('/Home');
        
      },
      (err: { status: number; }) => {
        if(err.status == 400){
          alert("User name and Password Incorrect");
          console.log("user name, password required");
        }
      
    
        else
          alert("Invalid Email and Password");

          console.log(err);
     }
    )
  }
}


