import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Topic } from '../../../models/topics/topic';
import { SubtopicsService } from '../subtopics/subtopics.service';

@Injectable({
  providedIn: 'root'
})
export class TopicsService {

  private key = "topic";

  selectedTopics = new BehaviorSubject(this.topics);
  constructor(private subtopicsService: SubtopicsService) { }
  
  set topics(value: Topic[]) {
    localStorage.setItem(this.key, JSON.stringify(value));
    if (value != undefined) {
      const subtopics = [];
      value.forEach(topic => {
        subtopics.push.apply(subtopics, topic.subtopics);
      });
      this.subtopicsService.subtopics = subtopics;
    }
    this.selectedTopics.next(value);
  }
 
  get topics(): Topic[] {
    const json = localStorage.getItem(this.key);
    if (json != undefined) {
      return JSON.parse(json) as Topic[];
    }
    else{
      return undefined;
    }
  }
}
