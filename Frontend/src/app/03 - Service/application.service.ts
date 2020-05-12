import { Injectable, EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {

  public userEmmitter: EventEmitter<string> = new EventEmitter(null);

  constructor() { }

  notifyUser(user: any) {
    if (user === null) {
      this.userEmmitter.emit(null);
      return;
    }
    this.userEmmitter.emit(user.User.Username);
  }

}
