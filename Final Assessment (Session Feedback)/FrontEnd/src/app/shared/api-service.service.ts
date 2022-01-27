import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import{HttpClient, HttpHeaders} from "@angular/common/http";
import { feedback } from './Model/feedback.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {

  baseURL = "https://localhost:44379/";
  formData!: feedback;

  constructor(private fb : FormBuilder, public http:HttpClient) { }


  formsModel = this.fb.group({
    UserName:['',Validators.required],
    Name:['',Validators.required],
    Age:[0,Validators.required],
    Gender:['',Validators.required],
    Email:['',[Validators.required,Validators.email]],
    Password:['',[Validators.required,Validators.minLength(5)]],
    ConformPassword:['',[Validators.required,Validators.minLength(5)]],
   


  })

  comparePasswords(fb:FormGroup){
    let ConformPasswordCtrl = fb.get('ConformPassword');

    if(ConformPasswordCtrl.errors == null || 'passwordMismatch' in ConformPasswordCtrl.errors){
      if(fb.get('Password').value != ConformPasswordCtrl.value)
       ConformPasswordCtrl.setErrors({ passwordMismatch:true});

      else
       ConformPasswordCtrl.setErrors(null);
    }
  }


   roleMatch(allowedRoles: any): boolean {
    debugger
    var isMatch = false;
    var payLoad = JSON.parse(window.atob(localStorage.getItem('token')!.split('.')[1]));
    var userRole = payLoad["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    debugger;
    allowedRoles.forEach( (element: any) => {
      if (userRole == element){
        isMatch = true;
        return false;
      }
      return null
    });
  
    return isMatch;
  } 


register(){

  var body = {
    userName: this.formsModel.value.UserName,
    name : this.formsModel.value.Name,
    age : this.formsModel.value.Age,
    gender: this.formsModel.value.Gender,
    email: this.formsModel.value.Email,
    password: this.formsModel.value.Password,
    conform_Pwd : this.formsModel.value.ConformPassword,
   
  };
  return this.http.post(this.baseURL + 'Register',body);

}

Login(formData:any){
  return this.http.post(this.baseURL + 'Login',formData);
}


  GetSession(){
    debugger
    return this.http.get<any>(this.baseURL + "api/SessionFeedback/GetSession")
    .pipe(map((res:any)=>{
      return res;
    }))
  }

  AddFeedback(formData:any){
    debugger
    var tokenHeader = new HttpHeaders({'Authorization':'Bearer '+ localStorage.getItem('token')})
   return  this.http.post(this.baseURL + "api/SessionFeedback/CreatFeedback",formData,{headers:tokenHeader});
  }




}
