import { Injectable } from '@angular/core';
import { WebRequestService } from './web-request.service';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  constructor(private webReqService: WebRequestService) { }

  getMessage(id: number) {
    return this.webReqService.get(`api/message/get/${id}`)
  }

  getMessages(chatId: number) {
    return this.webReqService.get(`api/message/GetByChatId/${chatId}`);
  }

  createMessage(text: string, chatId: number) {
    return this.webReqService.post('api/message/create', { text: text, chatId: chatId });
  }

  deleteMessage(id: number) {
    return this.webReqService.delete(`api/message/delete/${id}`);
  }
}
