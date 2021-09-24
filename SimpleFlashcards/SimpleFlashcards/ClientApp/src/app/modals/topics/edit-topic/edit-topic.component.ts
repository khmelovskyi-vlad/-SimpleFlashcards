import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { TopicsApiService } from '../../../services/api/topics/topics-api.service';
import { Subtopic } from '../../../models/topics/subtopic';
import { Topic } from '../../../models/topics/topic';
import { Subscription } from 'rxjs';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

import * as conformityModal from '../../../../assets/conformities/conformity-modal.json';

@Component({
  selector: 'app-edit-topic',
  templateUrl: './edit-topic.component.html',
  styleUrls: ['./edit-topic.component.scss']
})
export class EditTopicComponent implements OnInit {

  @Input() topic: Topic;
  @Input() closeModalId?: number;

  modalRef: BsModalRef;
  modalId = conformityModal.EditTopicComponent;
  subscriptions: Subscription[] = [];
  
  config = {
    backdrop: true,
    class: 'modal-lg',
    id: this.modalId
  };

  constructor(private topicsApiService: TopicsApiService, 
    private modalService: BsModalService) { }

  ngOnInit(): void {
  }

  edit(){
    this.topicsApiService.editTopic(this.topic).subscribe(topic => this.topic = topic);
  }
  
  addSubtopic(){
    this.topic.subtopics.push(new Subtopic());
  }

  openModal(template: TemplateRef<any>) {
    this.subscriptions.push(
      this.modalService.onHidden.subscribe((reason: string | any) => {
        if (this.closeModalId == reason.id) {
          this.modalRef = this.modalService.show(template, this.config );
        }
        else{
          this.unsubscribe(); 
        }
      })
    );
    if (this.closeModalId) {
      this.modalService.hide(this.closeModalId);
    }
    else {
      this.modalRef = this.modalService.show(template, this.config );
    }
  }

  unsubscribe() {
    this.subscriptions.forEach((subscription: Subscription) => {
      subscription.unsubscribe();
    });
    this.subscriptions = [];
  }

}
