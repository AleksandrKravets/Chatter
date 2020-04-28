import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UsersService } from 'src/app/shared/services/users.service';
import { User } from 'src/app/shared/models/user.model';
import { Message } from '../../shared/models/message.model';
import { AuthService } from 'src/app/shared/services/auth.service';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  message: Message;

  constructor(
    private usersService: UsersService,
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.message = new Message('danger', '')

    this.route.queryParams
      .subscribe((params: Params) => {
        if(params['nowCanLogin']) {
          this.showMessage({ text: 'Теперь вы можете зайти в систему' , type: 'success'})
        }
      })

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
            this.message.text = ''
            window.localStorage.setItem('user', JSON.stringify(user))
            this.authService.login()
            this.router.navigate(['/system', 'bill'])
          } else {
            this.showMessage({ text: 'Пароль неверный', type: 'dander'})
          }
        } else {
          this.showMessage({ text: 'Такого пользователя не существует', type: 'dander'})
        }
      })
  }

  private showMessage(message: Message) {
    this.message = message;
    window.setTimeout(() => {
      this.message.text = ''
    }, 5000)
  }
}
