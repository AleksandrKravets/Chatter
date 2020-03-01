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
export class ChatComponent implements OnInit, OnDestroy{
  /* ДОБАВИТЬ БУЛЕВУЮ ПЕРЕМЕННУЮ ConnectionEstableshed
  и окрывать чат только когда она тру */
  id: Nullable<number> = null
  name: string
  messages: any[] = []
  connectionId: string
  hubConnection: signalR.HubConnection
  constructor(
    private route: ActivatedRoute, 
    private chatService: ChatService,
    private messageService: MessageService
  ) {}

  connect() {
    this.hubConnection.start()
      .then(() => {  
        console.log('SignalR Connected!');  
        this.hubConnection.invoke('GetConnectionId')
          .then(connectionId => {
              console.log("connection id " + connectionId)
              this.connectionId = connectionId

              this.route.params.subscribe((params: Params) => {
                if(this.id !== null) {
                  this.leaveChat(this.id)
                }
                this.id = +params['id']
          
                this.joinChat(this.id)

                this.chatService.getChat(this.id).subscribe((res: any) => {
                  console.log("getChat")
                  console.log(res)
                  this.name = res.name
                  this.messages = res.messages
                })
              })

          })
          .catch(err => {
            console.error("Err412")
          });
      })
      .catch(function (err) { 
        // При потере соединения переподключаемся через 3 сек
        //setTimeout(function() { this.startConnection(); }, 3000)
        return console.error('Err0');  
      })
  }

  joinChat(chatId: number) {
    this.chatService.joinChat({connectionId : this.connectionId, chatId: this.id})
      .subscribe(res => {
        console.log('joined to chat')
      })

    // this.hubConnection.invoke('JoinGroup', chatId.toString())
    //   .then((res) => {
        
    //     console.log("Res")
    //   })
    //   .catch(err => { 
    //     console.log("Err")
    //   })
  }

  leaveChat(chatId: number) {
    this.chatService.leaveChat({connectionId : this.connectionId, chatId: this.id})
      .subscribe(res => {
        console.log('leave the chat')
      })

    
    // this.hubConnection.invoke('LeaveGroup', chatId.toString())
    //   .then((res) => {
        
    //     console.log("ResL")
    //   })
    //   .catch(err => { 
    //     console.log("ErrL")
    //   })
  }

  ngOnInit() {
    this.buildHubConnection()
    this.setUpConnection()
    this.connect()
  }

  sendMessage(message: string) {
    this.hubConnection.invoke('SendMessageGroup', this.id.toString(), message)
      .then((res) => {
          
        console.log("Res1")
      })
      .catch(err => { 
        console.log("Err1")
      })
    // this.messageService.createMessage(message, this.id).subscribe((res) => {
    //   console.log("createMessage")
    // })
  }

  buildHubConnection() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Information)  
      .withUrl("http://localhost:56650/chatHub")  
      .build();
  }

  setUpConnection() {
    this.hubConnection.on("ReceivedMessage", (message) => {
      // this.messages.push({ id: 12, text: message, timestamp: '12:32'})
      //this.messages = this.messages.slice()
      console.log("new message ")
      console.log(message)
      
    });

    this.hubConnection.onclose(() => {
      console.log("oncloseeventdisconnected")
    })
  }

  ngOnDestroy() {
    console.log("destroyed")
  }
}
