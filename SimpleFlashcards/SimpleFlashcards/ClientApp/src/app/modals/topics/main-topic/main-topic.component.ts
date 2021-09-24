import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { GeneralDataService } from '../../../services/general-data/general-data.service';

import * as conformityModal from '../../../../assets/conformities/conformity-modal.json';

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
  
  constructor(public generalData: GeneralDataService,
    private modalService: BsModalService) { }

  ngOnInit(): void {
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { id: this.modalId });
  }

}
