import { Component, Input, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { GeneralDataService } from '../../../services/general-data/general-data.service';

import * as conformityModal from '../../../../assets/conformities/conformity-modal.json';
import { OpenMainTopicModalService } from '../../../services/modals/open-main-topic-modal/open-main-topic-modal.service';
import { ParentModalData } from '../../../models/modals/parent-modal-data';

@Component({
  selector: 'app-main-topic',
  templateUrl: './main-topic.component.html',
  styleUrls: ['./main-topic.component.scss']
})
export class MainTopicComponent implements OnInit {

  @Input() showButton = true;
  modalRef: BsModalRef;
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

  getOpenModalEvent(template: TemplateRef<any>): ParentModalData{
    return new ParentModalData(() => this.openModal(template), conformityModal.MainTopicComponent);
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { id: conformityModal.MainTopicComponent });
  }

}
