import { Injectable, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { MainModalData } from '../../../models/modals/main-modal-data';
import { OpenMainTopicModalService } from '../open-main-topic-modal/open-main-topic-modal.service';

@Injectable({
  providedIn: 'root'
})
export class OpenTopicModalsService {
  
  constructor(private modalService: BsModalService,
    private openMainTopicModalService: OpenMainTopicModalService) { }
  
  config : ModalOptions = {
    animated: false,
    keyboard: true,
    backdrop: true,
    class: 'modal-lg',
  };

  open2Modal(template: TemplateRef<any>, subscriptions: Subscription[], modalRef: BsModalRef, modalId: number,
    closeModalId?: number, config?: ModalOptions): void
  {
    const needConfig = this.getConfig(modalId, config);
    modalRef = this.modalService.show(template, needConfig );
    subscriptions.push(
      this.modalService.onHidden.subscribe((reason: string | any) => {
        if (closeModalId != reason.id) {
          this.unsubscribe(subscriptions); 
          this.openMainTopicModalService.open = true;
        }
      })
    );
  }
  openModal(template: TemplateRef<any>, mainModalData: MainModalData, closeModalId?: number, config?: ModalOptions): void
  {
    const needConfig = this.getConfig(mainModalData.modalId, config);
    mainModalData.modalRef = this.modalService.show(template, needConfig );
    mainModalData.subscriptions.push(
      this.modalService.onHidden.subscribe((reason: string | any) => {
        if (closeModalId != reason.id) {
          this.unsubscribe(mainModalData.subscriptions); 
          this.openMainTopicModalService.open = true;
        }
      })
    );
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
