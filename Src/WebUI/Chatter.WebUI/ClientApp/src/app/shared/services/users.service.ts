import { HttpClient } from '@angular/common/http';
import { User } from '../models/user.model';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class UsersService {

  constructor(private http: HttpClient) {

  }

  getUserByEmail(email: string): Observable<User[]> {
    return this.http.get<User[]>(`http://localhost:3000/users?email=${email}`)
  }

  createNewUser(user: User): Observable<any> {
    return this.http.post(`http://localhost:3000/users`, user)
  }
}
