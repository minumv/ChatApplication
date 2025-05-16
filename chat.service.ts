import { EventEmitter, Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Message } from '../Model/Message';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  messageReceived = new EventEmitter<Message>();
  connectionEstablished = new EventEmitter<Boolean>();
  private connectionIsEstablished = false;
  private _hubConnection: signalR.HubConnection;
  constructor() {
    this._hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5245/messagehub',{ withCredentials: true})
      .configureLogging(signalR.LogLevel.Information) 
      .build();
    this.registerOnServerEvents();
    this.startConnection();
  }
  sendMessage(message: Message) {
    this._hubConnection.invoke('NewMessage', message);
  }
  
  private startConnection(): void {
    this._hubConnection
      .start()
      .then(() => {
        this.connectionIsEstablished = true;
        console.log('Hub connection started');
        this.connectionEstablished.emit(true);
      })
      .catch(err => {
        console.log('Error while establishing connection, retrying...');
        setTimeout(() => { this.startConnection(); }, 5000);
      });
  }
  private registerOnServerEvents(): void {
    this._hubConnection.on('MessageReceived', (data: any) => {
      this.messageReceived.emit(data);
    });
  }
}