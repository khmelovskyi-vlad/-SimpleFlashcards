import { Injectable, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CloseModalsService {

  constructor(private modalService: BsModalService) { }
  
  config : ModalOptions = {
    backdrop: true,
    class: 'modal-lg',
  };
  
  openModal(template: TemplateRef<any>, subscriptions: Subscription[], modalRef: BsModalRef, modalId: number,
    closeModalId?: number, config?: ModalOptions): void
  {
    const needConfig = this.getConfig(modalId, config);
    subscriptions.push(
      this.modalService.onHidden.subscribe((reason: string | any) => {
        if (closeModalId == reason.id) {
          modalRef = this.modalService.show(template, needConfig );
        }
        else{
          this.unsubscribe(subscriptions); 
        }
      })
    );
    if (closeModalId) {
      this.modalService.hide(closeModalId);
    }
    else {
      modalRef = this.modalService.show(template, needConfig );
    }
  }

  getConfig(modalId: number, config?: ModalOptions): ModalOptions{
    if (config) {
      return config;
    }
    else {
      const needConfig = this.config;
      needConfig['modalId'] = modalId;
      return needConfig;
    }
  }

  unsubscribe(subscriptions: Subscription[]): void {
    subscriptions.forEach((subscription: Subscription) => {
      subscription.unsubscribe();
    });
    subscriptions = [];
  }
}
