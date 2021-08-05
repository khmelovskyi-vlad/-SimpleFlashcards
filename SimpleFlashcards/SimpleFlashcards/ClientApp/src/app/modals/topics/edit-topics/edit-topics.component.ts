import { Component, OnInit, TemplateRef } from '@angular/core';
import { Subject } from 'rxjs';
import { TopicsApiService } from '../../../services/api/topics/topics-api.service';
import { GeneralDataService } from '../../../services/general-data/general-data.service';
import { Topic } from '../../../models/topics/topic';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-edit-topics',
  templateUrl: './edit-topics.component.html',
  styleUrls: ['./edit-topics.component.scss']
})
export class EditTopicsComponent implements OnInit {

  private searchTopics = new Subject<string>();
  searchEditTopic: string = '';
  receivedTopics: Topic[];

  modalRef: BsModalRef;
  constructor(private generalData: GeneralDataService, 
    private topicsApiService: TopicsApiService, 
    private modalService: BsModalService) { }

  ngOnInit(): void {
    this.generalData.topics.selectedTopic.subscribe(topic => {
      if (topic) {
        this.searchEditTopic = topic.value;
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
    this.modalRef = this.modalService.show(template);
  }
  
  selectTopic(topic: Topic): void{
    
  }

}
