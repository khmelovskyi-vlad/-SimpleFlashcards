import { BsModalRef } from "ngx-bootstrap/modal";
import { Subscription } from "rxjs";

export class MainModalData{
  modalRef: BsModalRef;
  subscriptions: Subscription[] = [];
  constructor(public modalId: number){
  }
}