import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { ChatService } from 'src/app/services/chat.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {

  id: number
  name: string
  messages: string[] = []

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private chatService: ChatService
  ) { }

  ngOnInit(): void {
    console.log("1")
    //this.id = +this.route.snapshot.params['id']
    //this.name = this.route.snapshot.params['name']

    // реактивное получение роутов
    this.route.params.subscribe((params: Params) => {
      this.id = +params['id']
      this.chatService.getChat(this.id).subscribe((res: any) => {
        this.name = res.name
        this.messages = res.messages
      })
    })
  }
}
