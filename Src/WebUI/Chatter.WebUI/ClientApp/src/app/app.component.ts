import { Component, OnInit } from '@angular/core';
import * as signalR from '@aspnet/signalr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  public message: string = '';
  public messages: string[] = [];
  public hubConnection: signalR.HubConnection;
  ngOnInit() : void {
    /*
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:56650/chatHub')
      .build()

      // ReceiveMessage
    this.hubConnection.on('Send', data => {
      console.log(data)
      this.messages.push(data)
    })

    this.hubConnection.start()
      .then(() => { console.log("Connection started") })
      .catch(err => console.log("Error: " + err))
      */
  }

  echo() {
    this.hubConnection.invoke("Echo", this.message)
  }
}
