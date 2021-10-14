import { BsModalRef } from "ngx-bootstrap/modal";
import { Subscription } from "rxjs";

export class MainModalData{
  modalRef: BsModalRef;
  modalId: number;
  subscriptions: Subscription[] = [];
  constructor(modalId: number){
    this.modalId = modalId;
  }
}