import { Component, OnInit } from '@angular/core';
import { ChatService } from 'src/app/services/chat.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-chat',
  templateUrl: './create-chat.component.html',
  styleUrls: ['./create-chat.component.scss']
})
export class CreateChatComponent implements OnInit {
  listId: string;

  constructor(
    private chatService: ChatService,
    private route: ActivatedRoute, 
    private router: Router) { }
  
  ngOnInit() {
  }

  createChat(title: string) {
    this.chatService.createChat(title).subscribe((obj) => {
      this.router.navigate(['../'], { relativeTo: this.route });
    })
  }

}
