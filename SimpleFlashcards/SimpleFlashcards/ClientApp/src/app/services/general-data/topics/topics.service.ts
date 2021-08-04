import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Topic } from '../../../models/topics/topic';
import { SubtopicsService } from '../subtopics/subtopics.service';

@Injectable({
  providedIn: 'root'
})
export class TopicsService {

  private key = "topic";

  selectedTopic = new BehaviorSubject(this.topic);
  constructor(private subtopicsService: SubtopicsService) { }
  
  set topic(value: Topic) {
    localStorage.setItem(this.key, JSON.stringify(value));
    this.subtopicsService.subtopics = value.subtopics;
    this.selectedTopic.next(value);
  }
 
  get topic(): Topic {
    const json = localStorage.getItem(this.key);
    if (json != undefined) {
      return JSON.parse(json) as Topic;
    }
    else{
      return undefined;
    }
  }
}
