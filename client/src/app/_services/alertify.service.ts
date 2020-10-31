import { Injectable } from '@angular/core';
import * as alertify from 'alertifyjs';

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

constructor() {
  this.setupNotify();
 }

setupNotify() {
  alertify.set('notifier', 'delay', 3);
  alertify.set('notifier', 'position', 'top-center');
}

confirm(message: string, okCallback: () => any) {
  alertify.confirm(message, (e: any) => {
    if (e) {
      okCallback();
    } else {}
  });
}

success(message: string) {
  alertify.success(message);
}

error(message: string) {
  alertify.error(message);
}

warning(message: string) {
  alertify.warning(message);
}
message(message: string) {
  alertify.message(message);
}

}
