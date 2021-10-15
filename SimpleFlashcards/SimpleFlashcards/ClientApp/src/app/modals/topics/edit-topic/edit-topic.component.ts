import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { TopicsApiService } from '../../../services/api/topics/topics-api.service';
import { Subtopic } from '../../../models/topics/subtopic';
import { Topic } from '../../../models/topics/topic';

import * as conformityModal from '../../../../assets/conformities/conformity-modal.json';
import { OpenTopicModalsService } from '../../../services/modals/open-topic-modals/open-topic-modals.service';
import { MainModalData } from '../../../models/modals/main-modal-data';
import { ParentModalData } from '../../../models/modals/parent-modal-data';

@Component({
  selector: 'app-edit-topic',
  templateUrl: './edit-topic.component.html',
  styleUrls: ['./edit-topic.component.scss']
})
export class EditTopicComponent implements OnInit {

  @Input() topic: Topic;
  @Input() openModalEvent: ParentModalData;
  mainModalData =  new MainModalData(conformityModal.EditTopicComponent);

  message: string = '';
  isError = false;
  constructor(private topicsApiService: TopicsApiService, 
    private openTopicModalsService: OpenTopicModalsService) { }

  ngOnInit(): void {
  }

  edit(){
    this.topicsApiService.editTopic(this.topic).subscribe(topic => {
      if (topic == undefined) {
        this.isError = true;
        this.message = 'Something crashed, sorry';
      }
      else{
        this.topic = topic;
        this.message = 'Topic changed successfully';
      }
    });
  }
  
  addSubtopic(){
    this.topic.subtopics.push(new Subtopic());
  }

  openModal(template: TemplateRef<any>) {
    this.openTopicModalsService.openModal(template, this.mainModalData, this.openModalEvent, undefined, false);
  }

}
