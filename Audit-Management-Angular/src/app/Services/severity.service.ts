import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { SeverityURL } from '../Models/tokens';

import { GetQuestionsList } from './getQuestionList.service';
import { Security } from './security.service';

@Injectable({ providedIn: 'root' })
export class Severity {
  private token = localStorage.getItem('auditToken');

  headers = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${this.token}`,
    }),
  };

  constructor(
    private http: HttpClient,
    private route: Router,
    private qList: GetQuestionsList,
    private security: Security,
    @Inject(SeverityURL) private severityUrl: string
  ) {
    console.log(qList.sendResponse());
  }

  requestData1 = {
    projectName: '',
    projectManagerName: '',
    applicationOwnerName: '',
    auditdetails: {
      Type:' ',
      date: ' ',
      questions:
      {question1:true,
        question2:true,
        question3:true,
        question4:true,
        question5:true}
    }
  };

  setDetails() {
    (this.requestData1.projectName = this.qList.getProjectName()),
      (this.requestData1.projectManagerName = this.security.getUserName()),
      (this.requestData1.applicationOwnerName = 'Cognizant');
      (this.requestData1.auditdetails.Type = this.qList.getAuditType());
    this.requestData1.auditdetails.date = '2022-06-27';
    this.requestData1.auditdetails.questions = this.getResponses(
      this.qList.sendResponse()
    );
  }

  getResponses(res: { questionval:string }[]) {
    console.log(res);
    var temp:{questionval:boolean} [] = [];

    for (var result of res) {
      if (result.questionval === 'YES')
        temp.push({questionval:true} );
      else temp.push( {questionval:false} );
    }
    return {
      question1:temp[0].questionval,
      question2:temp[1].questionval,
      question3:temp[2].questionval,
      question4:temp[3].questionval,
      question5:temp[4].questionval
      
    };
  }

  getTokFromlocal() {
    return this.token;
  }

  public executionStatus() {
    this.setDetails();
    console.log(this.requestData1);
    return this.http.post(this.severityUrl, this.requestData1, this.headers);
  }
}
