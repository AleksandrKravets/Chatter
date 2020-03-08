import { Component, OnInit } from '@angular/core';
import { ChatService } from '../services/chat.service';
import { Router } from '@angular/router';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(
    private accountService: AccountService, 
    private router: Router) { }

  
  ngOnInit() {
  }

  login(email: string, password: string) {
    this.accountService.login(email, password).subscribe((res : any) => {
      console.log('access_token: ' + res.access_token)
      localStorage.setItem('access_token', res.access_token);
      this.router.navigate(['/']);
    }, err => {
      if (err.status == 400)
          console.log('Incorrect username or password. Authentication failed.')
        else
          console.log(err);
    })
  }

}
