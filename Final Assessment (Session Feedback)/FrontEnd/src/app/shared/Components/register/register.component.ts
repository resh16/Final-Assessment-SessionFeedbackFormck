import { Component, OnInit } from '@angular/core';
import { ApiServiceService } from '../../api-service.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(public service:ApiServiceService) { }

  ngOnInit(): void {
    this.service.formsModel.reset();
  }

  OnSubmit(){
    debugger
    this.service.register().subscribe(
      (res:any) => {
        if (res.status='Success'){
          alert('Registration successfull');
          this.service.formsModel.reset();
          

        } else{
          res.errors.forEach((element:any )=> {
            switch (element.code){
              case 'DuplicateUserName':
                alert('UserName already taken');
                break;
              default :
                  alert('Registration failed');
                  break;           
                 }
          });
          
        }
      },
      (err: any) => {
        console.log(err);
      });
  }

}
