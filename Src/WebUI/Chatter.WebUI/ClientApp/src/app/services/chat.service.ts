import { Injectable } from '@angular/core';
import { WebRequestService } from './web-request.service';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  chats = [
  ]

  constructor(private webReqService: WebRequestService) { }

  getChat(id: number) {
    return this.webReqService.get(`api/chats/get/${id}`)
  }

  getChats() {
    return this.webReqService.get('api/chats/getall');
  }

  createChat(title: string) {
    return this.webReqService.post('api/chats/create', { title });
  }

  updateChat(id: number, title: string) {
    return this.webReqService.patch(`api/chats/update/${id}`, { title });
  }

  deleteChat(id: number) {
    return this.webReqService.delete(`api/chats/delete/${id}`);
  }
}
