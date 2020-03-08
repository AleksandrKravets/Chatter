import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  constructor(
    private accountService: AccountService, 
    private router: Router) { }

  
  ngOnInit() {
  }

  register(nickname:string, email: string, password: string) {
    this.accountService.register(email, password, nickname).subscribe((res : any) => {
      console.log("register")
      console.log(res.token)
      this.router.navigate(['/']);
    })
  }
}
