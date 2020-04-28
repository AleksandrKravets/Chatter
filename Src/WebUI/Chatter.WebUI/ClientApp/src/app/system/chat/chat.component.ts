import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import * as signalR from '@microsoft/signalr';

export interface Message {
  id: number,
  text: string,
  userName: string,
  isUserMessage: boolean
}

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {
  // connectionEstablished: boolean = false
  // id: number
  // name: string
  // messages: any[] = []
  // connectionId: string
  // hubConnection: signalR.HubConnection
  messages: Array<Message> = [
    {
      id: 1,
      text: 'Hi',
      userName: 'Alex',
      isUserMessage: true
    },
    {
      id: 1,
      text: 'Hello',
      userName: 'Nick',
      isUserMessage: false
    },
    {
      id: 1,
      text: 'How are you',
      userName: 'Alex',
      isUserMessage: true
    },
    {
      id: 1,
      text: 'I am ok',
      userName: 'Nick',
      isUserMessage: false
    }
  ];

  chatName: string = 'Friends chat';

  constructor(
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    console.log(this.route.snapshot.params.id);
  }

  // connect() {
  //   this.hubConnection.start()
  //     .then(() => {
  //       console.log('SignalR Connected!');
  //       this.hubConnection.invoke('GetConnectionId')
  //         .then(connectionId => {
  //             console.log("connection id " + connectionId)
  //             this.connectionId = connectionId

  //             this.route.params.subscribe((params: Params) => {
  //               if(this.connectionEstablished) {
  //                 this.leaveChat(this.id)
  //               }

  //               this.id = +params['id']

  //               this.joinChat(this.id)

  //               // this.chatService.getChat(this.id).subscribe((res: any) => {
  //               //   console.log("getChat")
  //               //   console.log(res)
  //               //   this.name = res.name
  //               //   //this.messages = res.messages
  //               // })
  //             })

  //         })
  //         .catch(err => {
  //           console.error("Err412")
  //         });
  //     })
  //     .catch(function (err) {
  //       // При потере соединения переподключаемся через 3 сек
  //       //setTimeout(function() { this.startConnection(); }, 3000)
  //       return console.error('Err0');
  //     })
  // }

  // joinChat(chatId: number) {
  //   // this.chatService.joinChat({connectionId : this.connectionId, chatId: this.id})
  //   //   .subscribe(res => {
  //   //     console.log('joined to chat')
  //   //   })

  //   // this.hubConnection.invoke('JoinGroup', chatId.toString())
  //   //   .then((res) => {

  //   //     console.log("Res")
  //   //   })
  //   //   .catch(err => {
  //   //     console.log("Err")
  //   //   })
  // }

  // leaveChat(chatId: number) {
  //   // this.chatService.leaveChat({connectionId : this.connectionId, chatId: this.id})
  //   //   .subscribe(res => {
  //   //     console.log('leave the chat')
  //   //   })


  //   // this.hubConnection.invoke('LeaveGroup', chatId.toString())
  //   //   .then((res) => {

  //   //     console.log("ResL")
  //   //   })
  //   //   .catch(err => {
  //   //     console.log("ErrL")
  //   //   })
  //   this.connectionEstablished = false
  // }

  // ngOnInit() {
  //   this.buildHubConnection()
  //   this.setUpConnection()
  //   this.connect()
  // }

  // sendMessage(message: string) {
  //   // this.messageService.createMessage(message, this.id).subscribe(res => {
  //   //   console.log('Messege sending')
  //   //   console.log(res)
  //   // })
  //   // this.hubConnection.invoke('SendMessageGroup', this.id.toString(), message)
  //   //   .then((res) => {

  //   //     console.log("Res1")
  //   //   })
  //   //   .catch(err => {
  //   //     console.log("Err1")
  //   //   })
  // }

  // buildHubConnection() {
  //   this.hubConnection = new signalR.HubConnectionBuilder()
  //     .configureLogging(signalR.LogLevel.Information)
  //     .withUrl("http://localhost:56650/chatHub")
  //     .build();
  // }

  // setUpConnection() {
  //   this.hubConnection.on("ReceivedMessage", (message) => {
  //     this.messages.push(message) // { id: 12, text: message.text, timestamp: '12:32'}
  //   });

  //   this.hubConnection.onclose(() => {
  //     console.log("oncloseeventdisconnected")
  //   })
  // }

  // ngOnDestroy() {
  //   console.log("destroyed")
  // }
}
