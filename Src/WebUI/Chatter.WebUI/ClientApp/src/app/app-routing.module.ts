import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotFoundComponent } from './system/not-found/not-found.component';
import { AuthComponent } from './auth/auth.component';
import { LoginComponent } from './auth/login/login.component';
import { RegistrationComponent } from './auth/registration/registration.component';
import { SystemComponent } from './system/system.component';
import { AuthGuard } from './auth/auth.quard';
import { ChatComponent } from './system/chat/chat.component';
import { CreateChatComponent } from './system/create-chat/create-chat.component';
import { ChatSettingsComponent } from './system/chat-settings/chat-settings.component';
import { ChatsComponent } from './system/chats/chats.component';


const routes: Routes = [
  { path: '', redirectTo: '/chats', pathMatch: 'full' },
  { path: '', component: AuthComponent, children: [
    { path: 'login', component: LoginComponent },
    { path: 'registration', component: RegistrationComponent }
  ]},
  { path: '', canActivate: [AuthGuard], component: SystemComponent, children: [
    { path: 'chats', component: ChatsComponent},
    { path: 'chats/:id', component: ChatComponent},
    { path: 'create-chat', component: CreateChatComponent},
    { path: 'chat-settings/:id', component: ChatSettingsComponent},
  ]},
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
