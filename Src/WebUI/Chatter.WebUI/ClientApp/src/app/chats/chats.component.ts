import { Component, OnInit } from '@angular/core';
import { ChatService } from '../services/chat.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-chats',
  templateUrl: './chats.component.html',
  styleUrls: ['./chats.component.scss']
})
export class ChatsComponent implements OnInit {
  chats = []
  /*this.router.navigateByUrl('/RefrshComponent', {skipLocationChange: true}).then(()=>
this.router.navigate(["Your actualComponent"]));  */
  constructor(private chatSevice: ChatService, private router:Router) { }

  ngOnInit(): void {
    this.chatSevice.getChats().subscribe((res: any[]) => {
      console.log("getChats")
      console.log(res)
      this.chats = res;
    })
  }
}
