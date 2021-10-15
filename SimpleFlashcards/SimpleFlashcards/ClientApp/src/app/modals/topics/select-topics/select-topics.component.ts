import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { GeneralDataService } from '../../../services/general-data/general-data.service';
import { Topic } from '../../../models/topics/topic';
import { TopicsApiService } from '../../../services/api/topics/topics-api.service';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { Subject } from 'rxjs';

import * as conformityModal from '../../../../assets/conformities/conformity-modal.json';
import { OpenTopicModalsService } from '../../../services/modals/open-topic-modals/open-topic-modals.service';
import { MainModalData } from '../../../models/modals/main-modal-data';
import { ParentModalData } from '../../../models/modals/parent-modal-data';

@Component({
  selector: 'app-select-topics',
  templateUrl: './select-topics.component.html',
  styleUrls: ['./select-topics.component.scss']
})
export class SelectTopicsComponent implements OnInit {

  @Input() openModalEvent: ParentModalData;
  mainModalData =  new MainModalData(conformityModal.SelectTopicsComponent);

  private searchTopics = new Subject<string>();
  topics: Topic[];
  receivedTopics: Topic[];
  
  constructor(public generalData: GeneralDataService, 
    private topicsApiService: TopicsApiService, 
    private openTopicModalsService: OpenTopicModalsService) { }

  ngOnInit(): void {
    this.generalData.topics.selectedTopics.subscribe(topics => {
      if (topics) {
        this.topics = topics;
      }
      else {
        this.topics = [];
      }
    });
    
    this.searchTopics.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      switchMap((part: string) => this.topicsApiService.getTopics(part)),
    ).subscribe(topics => this.receivedTopics = topics);
  }
  
  selectTopic(topic: Topic): void{
    // this.generalData.topics.topics = topic;
  }
  
  onSearchTopics(part: string): void {
    this.searchTopics.next(part);
  }
  
  openModal(template: TemplateRef<any>) {
    this.openTopicModalsService.openModal(template, this.mainModalData, this.openModalEvent);
  }
}
