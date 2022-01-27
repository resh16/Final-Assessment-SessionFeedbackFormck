import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { ApiServiceService } from './api-service.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(public router:Router,public service:ApiServiceService){}

  canActivate(
    
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot):  boolean  {
      debugger
      if(localStorage.getItem('token') != null){
        //
        let roles = route.data['permittedRoles'] as Array<string>;
        if(roles){
         if(this.service.roleMatch(roles)) 
          return true;
          
         else{
           alert("Access Denied");
           return false;
         }
        } 
        /////
        return true;
      }
        

      else{
        alert("Invalid User");
        this.router.navigate(['/login']);
       
        return false;
      }
  }
  
}
