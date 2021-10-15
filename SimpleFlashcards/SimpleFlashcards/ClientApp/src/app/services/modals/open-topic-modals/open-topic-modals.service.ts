import { Injectable, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { ParentModalData } from '../../../models/modals/parent-modal-data';
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

  needOpenModal = true

  openModal(template: TemplateRef<any>, mainModalData: MainModalData, parentModalData: ParentModalData, config?: ModalOptions,
    needOpenModal = true): void
  {
    this.needOpenModal = needOpenModal;
    const needConfig = this.getConfig(mainModalData.modalId, config);
    mainModalData.modalRef = this.modalService.show(template, needConfig );
    mainModalData.subscriptions.push(
      this.modalService.onHidden.subscribe((reason: string | any) => {
        if (parentModalData.closeModalId != reason.id) {
          if (this.needOpenModal || needOpenModal == false) {
            this.unsubscribe(mainModalData.subscriptions);
            parentModalData.open();
          }
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
      needConfig['id'] = modalId;
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
