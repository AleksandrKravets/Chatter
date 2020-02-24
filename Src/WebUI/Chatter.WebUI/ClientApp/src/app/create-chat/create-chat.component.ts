import { Component, OnInit } from '@angular/core';
import { ChatService } from '../services/chat.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-chat',
  templateUrl: './create-chat.component.html',
  styleUrls: ['./create-chat.component.scss']
})
export class CreateChatComponent implements OnInit {

  constructor(
    private chatService: ChatService, 
    private router: Router) { }

  
  ngOnInit() {
  }

  createChat(title: string) {
    this.chatService.createChat(title).subscribe((res) => {
      console.log("createChat")
      console.log(res)
      // переходить в комнату нового чата
      this.router.navigate(['/']);
    })
  }

}
