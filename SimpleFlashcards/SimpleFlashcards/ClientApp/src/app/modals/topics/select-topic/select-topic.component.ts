import { Component, OnInit } from '@angular/core';
import { GeneralDataService } from '../../../services/general-data/general-data.service';
import { Topic } from '../../../models/topics/topic';
import { TopicsApiService } from '../../../services/api/topics/topics-api.service';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-select-topic',
  templateUrl: './select-topic.component.html',
  styleUrls: ['./select-topic.component.scss']
})
export class SelectTopicComponent implements OnInit {


  private searchTopics = new Subject<string>();
  topic: Topic;
  receivedTopics: Topic[];
  
  constructor(public generalData: GeneralDataService, private topicsApiService: TopicsApiService) { }

  ngOnInit(): void {
    this.generalData.topics.selectedTopic.subscribe(topic => {
      if (topic) {
        this.topic = topic;
      }
      else {
        this.topic = new Topic();
      }
    });
    
    this.searchTopics.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      switchMap((part: string) => this.topicsApiService.getTopics(part)),
    ).subscribe(topics => this.receivedTopics = topics);
  }
  
  selectTopic(topic: Topic): void{
    this.generalData.topics.topic = topic;
  }
  
  onSearchTopics(part: string): void {
    this.searchTopics.next(part);
  }
}
