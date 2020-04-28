import { NgModule } from "@angular/core";
import { RouterModule, Routes } from '@angular/router';
import { SystemComponent } from './system.component';
import { ChatComponent } from './chat/chat.component';
import { ChatsComponent } from './chats/chats.component';
import { CreateChatComponent } from './create-chat/create-chat.component';
import { ChatSettingsComponent } from './chat-settings/chat-settings.component';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [
  { path: 'content', component: SystemComponent, children: [
    { path: 'chats', component: ChatsComponent},
    { path: 'chats/:id', component: ChatComponent},
    { path: 'create-chat', component: CreateChatComponent},
    { path: 'chat-settings/:id', component: ChatSettingsComponent},
    { path: '**', component: NotFoundComponent }
  ]}
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SystemRoutingModule {

}
