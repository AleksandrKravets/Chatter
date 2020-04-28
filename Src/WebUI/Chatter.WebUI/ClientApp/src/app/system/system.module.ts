import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { SystemRoutingModule } from './system-routing.module';
import { SystemComponent } from './system.component';
import { HeaderComponent } from './shared/components/header/header.component';
import { ChatsComponent } from './chats/chats.component';
import { ChatComponent } from './chat/chat.component';
import { CreateChatComponent } from './create-chat/create-chat.component';
import { ChatSettingsComponent } from './chat-settings/chat-settings.component';
import { NotFoundComponent } from './not-found/not-found.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    SystemRoutingModule
  ],
  declarations: [
    SystemComponent,
    HeaderComponent,
    ChatsComponent,
    ChatComponent,
    CreateChatComponent,
    ChatSettingsComponent,
    NotFoundComponent,
  ]
})
export class SystemModule {

}
