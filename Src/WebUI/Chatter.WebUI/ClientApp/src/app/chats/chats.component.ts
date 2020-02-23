import { Component, OnInit } from '@angular/core';
import { ChatService } from '../services/chat.service';

@Component({
  selector: 'app-chats',
  templateUrl: './chats.component.html',
  styleUrls: ['./chats.component.scss']
})
export class ChatsComponent implements OnInit {
  chats = []

  constructor(private chatSevice: ChatService) { }

  ngOnInit(): void {
    this.chatSevice.getChats().subscribe((res: any[]) => {
      this.chats = res;
    })
  }

}
