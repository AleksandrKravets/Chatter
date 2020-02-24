import { Component, OnInit, OnChanges, DoCheck, AfterContentInit, AfterContentChecked, AfterViewInit, AfterViewChecked, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { ChatService } from 'src/app/services/chat.service';
import { MessageService } from 'src/app/services/message.service';
import * as signalR from '@aspnet/signalr';  


type Nullable<T> = T | null;


@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit{
  id: Nullable<number> = null
  name: string
  messages: string[] = []
  connectionId: string

  constructor(
    private route: ActivatedRoute, 
    private chatService: ChatService,
    private messageService: MessageService
  ) {}


  connect() {
    const hubConnection = new signalR.HubConnectionBuilder()  
      .configureLogging(signalR.LogLevel.Information)  
      .withUrl("http://localhost:56650/chatHub")  
      .build();  
  
    hubConnection.on("ReceivedMessage", (message) => {
      this.messages.push(message.text)
      console.log(this.messages)  
      console.log("Message received312")
      console.log("new message " + message.toString())
      
    });

    hubConnection.start()
      .then(() => {  
        console.log('SignalR Connected!');  
        hubConnection.invoke('GetConnectionId')
          .then(connectionId => {
              console.log("connection id " + connectionId)
              this.connectionId = connectionId
              
              this.joinChat(this.id)
          })
          .catch(err => {
            console.error(err.toString())
          });
      })
      .catch(function (err) { 
        // При потере соединения переподключаемся через 3 сек
        //setTimeout(function() { this.startConnection(); }, 3000)
        return console.error(err.toString());  
      })
  }

  joinChat(chatId: number) {
    this.chatService.joinChat({connectionId : this.connectionId, chatId: this.id})
      .subscribe(res => {
        console.log('joined to chat')
      })
  }

  leaveChat(chatId: number) {
    this.chatService.leaveChat({connectionId : this.connectionId, chatId: this.id})
      .subscribe(res => {
        console.log('leave the chat')
      })
  }

  ngOnInit() {
    this.connect()

    if(this.id !== null) {
      // Отписатся от прошлой группы
      console.log('leave 1')
      this.leaveChat(this.id)
    }

    this.route.params.subscribe((params: Params) => {

      // изменить ид текущей группы
      this.id = +params['id'] // chatId

      this.chatService.getChat(this.id).subscribe((res: any) => {
        console.log("getChat")
        this.name = res.name
        this.messages = res.messages
      })
    })
  }

  sendMessage(message: string) {
    // при создании чата будет приходить его ид 
    // и нужно будет перейти в этот чат
    this.messageService.createMessage(message, this.id).subscribe((res) => {
      console.log("createMessage")
      console.log(res)
    })
    //this.hubConnection.invoke('NewMessage', "object or data");  
  }
}
