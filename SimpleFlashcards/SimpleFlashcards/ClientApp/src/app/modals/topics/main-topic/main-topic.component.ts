import { Component, Input, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { GeneralDataService } from '../../../services/general-data/general-data.service';

import * as conformityModal from '../../../../assets/conformities/conformity-modal.json';
import { OpenMainTopicModalService } from '../../../services/modals/open-main-topic-modal/open-main-topic-modal.service';

@Component({
  selector: 'app-main-topic',
  templateUrl: './main-topic.component.html',
  styleUrls: ['./main-topic.component.scss']
})
export class MainTopicComponent implements OnInit {

  @Input() showButton = true;
  @Input() closeModalId?: number;
  modalRef: BsModalRef;
  modalId = conformityModal.MainTopicComponent;
  @ViewChild('template') public templateRef: TemplateRef<any>;
  
  constructor(public generalData: GeneralDataService,
    private modalService: BsModalService,
    private openMainTopicModalService: OpenMainTopicModalService) { }

  ngOnInit(): void {
    this.openMainTopicModalService.openMainTopicModal.subscribe((value: boolean) => {
      if (value == true) {
        this.openModal(this.templateRef);
      }
    });
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { id: this.modalId });
  }

}
