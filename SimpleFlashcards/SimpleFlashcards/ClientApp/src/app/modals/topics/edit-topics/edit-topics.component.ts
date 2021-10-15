import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { Subject} from 'rxjs';
import { TopicsApiService } from '../../../services/api/topics/topics-api.service';
import { GeneralDataService } from '../../../services/general-data/general-data.service';
import { Topic } from '../../../models/topics/topic';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';

import * as conformityModal from '../../../../assets/conformities/conformity-modal.json';
import { OpenTopicModalsService } from '../../../services/modals/open-topic-modals/open-topic-modals.service';
import { MainModalData } from '../../../models/modals/main-modal-data';
import { ParentModalData } from '../../../models/modals/parent-modal-data';

@Component({
  selector: 'app-edit-topics',
  templateUrl: './edit-topics.component.html',
  styleUrls: ['./edit-topics.component.scss']
})
export class EditTopicsComponent implements OnInit  {

  @Input() openModalEvent: ParentModalData;
  mainModalData =  new MainModalData(conformityModal.EditTopicsComponent);

  private searchTopics = new Subject<string>();
  searchEditTopic: string = '';
  receivedTopics: Topic[];

  constructor(private generalData: GeneralDataService, 
    private topicsApiService: TopicsApiService, 
    private openTopicModalsService: OpenTopicModalsService) { }

  ngOnInit(): void {
    this.generalData.topics.selectedTopics.subscribe(topics => {
      if (topics && topics.length > 0) {
        this.searchEditTopic = topics[0].value;
      }
    });
    
    this.searchTopics.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      switchMap((part: string) => this.topicsApiService.getTopics(part)),
    ).subscribe(topics => this.receivedTopics = topics);
  }
  
  onSearchTopics(part: string): void {
    this.searchTopics.next(part);
  }

  openModal(template: TemplateRef<any>) {
    this.openTopicModalsService.openModal(template, this.mainModalData, this.openModalEvent);
  }
  
  getOpenModalEvent(template: TemplateRef<any>): ParentModalData{
    return new ParentModalData(() => this.openModal(template), conformityModal.EditTopicsComponent);
  }
}
