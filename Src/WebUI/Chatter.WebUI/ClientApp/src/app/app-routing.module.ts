import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ChatsComponent } from './chats/chats.component';
import { ChatComponent } from './chats/chat/chat.component';
import { CreateChatComponent } from './create-chat/create-chat.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';


const routes: Routes = [
  { path: '', component: ChatsComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'create-chat', component: CreateChatComponent },
  { 
    // empty component ("Choose a chat")
    path: 'chats', component: ChatsComponent,
    children: [
      { path: ':id', component: ChatComponent,  },
    ] 
  },
  { path: '**', redirectTo: '/chats' }
];

@NgModule({
  imports: [RouterModule, RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
