import { Component, OnInit } from '@angular/core';

enum ChatType {
  Private,
  Public,
  Open
}

interface Chat {
  id: number,
  name: string,
  type: ChatType,
  numberOfUsers: number
}


@Component({
  selector: 'app-chats',
  templateUrl: './chats.component.html',
  styleUrls: ['./chats.component.scss']
})
export class ChatsComponent implements OnInit {
  chatType = ChatType
  chats: Array<Chat>

  constructor() { }

  ngOnInit(): void {
    this.chats = [
      {
        id: 1,
        name: 'Woowownkvasknvasnklvasnklvnlaksvnlkaslknvalnksvnlkasnlkvxowo Hi',
        type: ChatType.Private,
        numberOfUsers: 3
      },
      {
        id: 2,
        name: 'Woowowowo Hi',
        type: ChatType.Private,
        numberOfUsers: 34
      },
      {
        id: 3,
        name: 'Woowowowo Hi',
        type: ChatType.Public,
        numberOfUsers: 60
      },
      {
        id: 4,
        name: 'Woowowowo Hi',
        type: ChatType.Private,
        numberOfUsers: 100
      },
      {
        id: 5,
        name: 'Woowowowo Hi',
        type: ChatType.Open,
        numberOfUsers: 12
      },
      {
        id: 1,
        name: 'Woowownkvasknvasnklvasnklvnlaksvnlkaslknvalnksvnlkasnlkvxowo Hi',
        type: ChatType.Private,
        numberOfUsers: 3
      },
      {
        id: 2,
        name: 'Woowowowo Hi',
        type: ChatType.Private,
        numberOfUsers: 34
      },
      {
        id: 3,
        name: 'Woowowowo Hi',
        type: ChatType.Public,
        numberOfUsers: 60
      },
      {
        id: 4,
        name: 'Woowowowo Hi',
        type: ChatType.Private,
        numberOfUsers: 100
      },
      {
        id: 5,
        name: 'Woowowowo Hi',
        type: ChatType.Open,
        numberOfUsers: 12
      }
    ]
  }
}
