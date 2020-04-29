import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UsersService } from 'src/app/shared/services/users.service';
import { User } from 'src/app/shared/models/user.model';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form: FormGroup;

  constructor(
    private usersService: UsersService,
    private authService: AuthService
  ) { }

  ngOnInit(): void {

    this.form = new FormGroup({
      'email': new FormControl(null, [Validators.required, Validators.email]),
      'password': new FormControl(null, [Validators.required, Validators.minLength(6)])
    });
  }

  onSubmit() {
    const formData = this.form.value;

    this.usersService.getUserByEmail(formData.email)
      .subscribe((users: User[]) => {
        var user = users[0] ? users[0] : undefined
        console.log(users);
        console.log(user);
        if(user) {
          if(user.password === formData.password) {
            window.localStorage.setItem('user', JSON.stringify(user))
            this.authService.login()
          }
        }
      })
  }
}
