import { Injectable } from '@angular/core';
import { WebRequestService } from './web-request.service';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  constructor(private service: WebRequestService) { }

  getChats() {
    return this.service.get('api/chat/getall')
  }

  getChat(id: number) {
    return this.service.get(`api/chat/get/${id}`)
  }

  createChat(chatName: string) {
    return this.service.post('api/chat/create', { name: chatName })
  }

  deleteChat(id: number) {
    return this.service.delete(`api/chat/delete/${id}`)
  }

  updateChat(id: string, title: string) {
    return this.service.patch(`api/chat/update`, { id, title })
  }
}
