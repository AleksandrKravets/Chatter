import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ChatsComponent } from './chats/chats.component';
import { ChatComponent } from './chats/chat/chat.component';
import { HttpClientModule } from '@angular/common/http';
import { MessageComponent } from './chats/chat/message/message.component';
import { CreateChatComponent } from './create-chat/create-chat.component';

@NgModule({
  declarations: [
    AppComponent,
    ChatsComponent,
    ChatComponent,
    MessageComponent,
    CreateChatComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
