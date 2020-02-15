import { Component, OnInit } from '@angular/core';
import { ChatService } from 'src/app/services/chat.service';
import { ActivatedRoute, Router, Params } from '@angular/router';

@Component({
  selector: 'app-chats-view',
  templateUrl: './chats-view.component.html',
  styleUrls: ['./chats-view.component.scss']
})
export class ChatsViewComponent implements OnInit {
  chats: Object[] = [];
  messages: Object[] = [];
  selectedChatId: string;
  constructor(
    private chatService: ChatService, 
    private route: ActivatedRoute, 
    private router: Router) { }

  ngOnInit() {
    /*
    this.route.params.subscribe(
      (params: Params) => {
        if (params.chatId) {
          this.selectedChatId = params.chatId;
          this.chatService.getChat(params.chatId).subscribe((tasks: Task[]) => {
            this.tasks = tasks;
          })
        } else {
          this.tasks = undefined;
        }
      }
    )
      */
    this.chatService.getChats().subscribe((chats: Object[]) => {
      this.chats = chats
      console.log(chats)
    })
  }

}
