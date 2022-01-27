import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ApiServiceService } from 'src/app/shared/api-service.service';
import { CreateFeedbackComponent } from '../create-feedback/create-feedback.component';


@Component({
  selector: 'app-session-list',
  templateUrl: './session-list.component.html',
  styleUrls: ['./session-list.component.css']
})
export class SessionListComponent implements OnInit {

  constructor(public service : ApiServiceService,public dialog : MatDialog) { }
p:number = 1;
session:any;
filterTerm: string;
key:string = 'name';
reverse:boolean = false;

  ngOnInit(): void {
    debugger;
    this.service.GetSession().subscribe(res => {
      this.session = res;
    });

  }
    openDialog(Id:number){
      console.log(Id);
      const dialogRef = this.dialog.open(CreateFeedbackComponent,{data:{id:Id}
      });
  
      dialogRef.afterClosed().subscribe(result => {
      debugger
      console.log('Dialog box closed');
      });
    }

    Search(){
      if(this.filterTerm == ""){
        this.ngOnInit();
      }else{
        this.session = this.session.filter((res:any) =>{
          return res.filterTerm.ToLowerCase().match(this.filterTerm.toLowerCase());
        });
      }
      
    }

    sort(key:string){
this.key = key;
this.reverse = !this.reverse;
    }

 

}
