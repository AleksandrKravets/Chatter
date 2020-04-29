import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UsersService } from 'src/app/shared/services/users.service';
import { User } from 'src/app/shared/models/user.model';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  form: FormGroup;

  constructor(
    private usersService: UsersService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      'email': new FormControl(null, [Validators.required, Validators.email], this.forbiddenEmails.bind(this)),
      'password': new FormControl(null, [Validators.required, Validators.minLength(6)]),
      'name': new FormControl(null, [Validators.required])
    })
  }

  onSubmit() {
    // const { email, password, name } = this.form.value;
    // const user = new User(email, password, name)

    // this.usersService.createNewUser(user)
    //   .subscribe(() => {
    //     this.router.navigate(['/login'], {
    //       queryParams: {
    //         nowCanLogin: true
    //       }
    //     })
    //   })

    // console.log(this.form)
  }

  forbiddenEmails(control: FormControl): Promise<any> {
    return new Promise((resolve, reject) => {
      this.usersService.getUserByEmail(control.value)
        .subscribe((users: User[]) => {
          if(users.length > 0) {
            resolve({forbiddenEmail: true})
          } else {
            resolve(null)
          }
        })
    })
  }
}
