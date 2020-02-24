import { Injectable } from '@angular/core';
import { WebRequestService } from './web-request.service';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  constructor(private webReqService: WebRequestService) { }

  getChat(id: number) {
    return this.webReqService.get(`api/chat/get/${id}`)
  }

  getChats() {
    return this.webReqService.get('api/chat/getall');
  }

  createChat(title: string) {
    return this.webReqService.post('api/chat/create', { name: title });
  }

  updateChat(id: number, title: string) {
    // `api/chats/update/${id}`, { title }
    return this.webReqService.patch(`api/chat/update`, { id: id, name: title });
  }

  deleteChat(id: number) {
    return this.webReqService.delete(`api/chat/delete/${id}`);
  }

  joinChat(payload: { connectionId: string, chatId: number}) {
    return this.webReqService.post('api/chat/join', payload);
  }

  leaveChat(payload: { connectionId: string, chatId: number}) {
    return this.webReqService.post('api/chat/leave', payload);
  }
}
