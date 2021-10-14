import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OpenMainTopicModalService {
  
  openMainTopicModal = new BehaviorSubject(false);
  constructor() { }
  
  set open(value: boolean) {
    this.openMainTopicModal.next(value);
  }
}
