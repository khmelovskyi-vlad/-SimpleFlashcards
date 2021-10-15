import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { MainModalData } from 'src/app/models/modals/main-modal-data';
import { Subtopic } from '../../../models/topics/subtopic';
import { Topic } from '../../../models/topics/topic';
import { TopicsApiService } from '../../../services/api/topics/topics-api.service';

import * as conformityModal from '../../../../assets/conformities/conformity-modal.json';
import { OpenTopicModalsService } from '../../../services/modals/open-topic-modals/open-topic-modals.service';
import { ParentModalData } from '../../../models/modals/parent-modal-data';

@Component({
  selector: 'app-add-topic',
  templateUrl: './add-topic.component.html',
  styleUrls: ['./add-topic.component.scss']
})
export class AddTopicComponent implements OnInit {

  @Input() openModalEvent: ParentModalData;
  mainModalData =  new MainModalData(conformityModal.AddTopicComponent);
  
  topic: Topic;
  message: string = '';
  isError = false;
  constructor(private topicsApiService: TopicsApiService, 
    private openTopicModalsService: OpenTopicModalsService) { }

  ngOnInit(): void {
    this.topic = new Topic();
  }

  addSubtopic(){
    this.topic.subtopics.push(new Subtopic());
  }

  addTopic(){
    this.topicsApiService.addTopic(this.topic).subscribe(topic => {
      if (topic == undefined) {
        this.isError = true;
        this.message = 'Something crashed, sorry';
      }
      else{
        this.topic = topic;
        this.message = 'Topic added successfully';
      }
    });
  }
  
  openModal(template: TemplateRef<any>) {
    this.openTopicModalsService.openModal(template, this.mainModalData, this.openModalEvent);
  }

}
