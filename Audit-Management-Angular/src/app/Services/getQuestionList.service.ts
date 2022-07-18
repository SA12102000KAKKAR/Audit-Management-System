import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { ChecklistComponent } from '../checklist/checklist.component';


@Injectable({providedIn: 'root'})
export class GetQuestionsList{

  private projectName="";
  private auditType:number=2;
  private response:{questionval:string}[]=[
    {"questionval":" "},
    {"questionval":" "},
    {"questionval":" "},
    {"questionval":" "},
    {"questionval":" "},
  ];

  constructor(private http:HttpClient){}
 

    sendResponse(){
      return this.response;
    }

    getResponse(res:{questionval:string}[]){
      this.response=res;
      console.log(this.response);
    }
    
    validateResponse(res:{questionval:string}[])
    {
      for(var str of res){
        if(str.questionval==" ")
        return false;
      }
      return true;
    }
    setDetails(name:string,type:number){
      this.projectName=name;
      this.auditType=type;
    }
    
    getProjectName(){
      return this.projectName;
    }
    // getAuditType(){
    //   return this.auditType;
    // }
    getAuditType(){
      if(this.auditType==0)return "Internal";
      return "SOX"
    }


}
