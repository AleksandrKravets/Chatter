import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ChatsViewComponent } from './pages/chats-view/chats-view.component';
import { CreateChatComponent } from './pages/create-chat/create-chat.component';

const routes: Routes = [
  { path: '', redirectTo: '/chats', pathMatch: 'full' },
  { path: 'chats', component: ChatsViewComponent },
  { path: 'new-chat', component: CreateChatComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
