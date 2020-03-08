import { Injectable } from '@angular/core';
import { WebRequestService } from './web-request.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private webReqService: WebRequestService) { }

  login(email: string, password: string) {
    return this.webReqService.post('api/account/login', { email: email, password: password })
  }

  register(email: string, password: string, nickname: string) {
    return this.webReqService.post(
      'api/account/register', 
      { email: email, password: password, nickname: nickname 
    })
  }

  logout() {
    localStorage.removeItem("jwt")
  }
}
