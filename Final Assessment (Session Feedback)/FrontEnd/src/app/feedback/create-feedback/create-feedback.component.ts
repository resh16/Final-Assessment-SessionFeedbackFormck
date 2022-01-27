import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ApiServiceService } from 'src/app/shared/api-service.service';
import { feedback } from 'src/app/shared/Model/feedback.model';


@Component({
  selector: 'app-create-feedback',
  templateUrl: './create-feedback.component.html',
  styleUrls: ['./create-feedback.component.css']
})
export class CreateFeedbackComponent implements OnInit {

  FileToUpload:any = null;
  

  constructor(public service : ApiServiceService,@Inject(MAT_DIALOG_DATA) public data:any) { }

  ngOnInit(): void {
    this.service.formData = new feedback();
    this.resetForm();
  
  }

  resetForm(form ?:any){ //NgForm
    if(form != null)
    form.resetForm();
    this.service.formData = {
      
    Id!:null,
    Name!:'',
    GoodFeedback!:'',
    BadFeedback !: '',
    Image !: null,
    Rating! : null
    }

  }



  OnSubmit(form:any){
    debugger
    this.insertRecord(form);
  }

  insertRecord(form:any){
    debugger
    const fileData = new FormData();
    debugger
     fileData.append('Image',this.FileToUpload, this.FileToUpload.name)
     fileData.append('Name',form.value.Name)
     fileData.append('SessionId',this.data.id)
     fileData.append('GoodFeedback',form.value.GoodFeedback)
     fileData.append('BadFeedback',form.value.BadFeedback)
     fileData.append('Rating',form.value.Rating)
     
      

      this.service.AddFeedback(fileData).subscribe((res:any)=>{
      alert("Feedback Successfully added");
      this.resetForm(fileData)
    },
    (err: { status: number; }) => {
      debugger
      if(err.status == 400){
        alert("Feedback already submitted");
        console.log(err);
      }
    
      else
        alert("Somthing went wrong, Try again.");
        console.log(err);
   }
    
  )}
    
  

  
  handleFileInput(e:any){

   /*  var fileName = this.FileToUpload.name;
    var idxDot = fileName.lastIndexOf(".")+1;
    var extFile = fileName.substr(idxDot,fileName.length).toLowerCase();
    if (extFile=="jpg" || extFile=="jpeg" || extFile=="png")
    { */
      console.log(e);
    this.FileToUpload = <File>e.target.files[0];
   /*  }
    else {
      alert("Only jpg/jpeg and png files are allowed!");
    } */
  }
}
