import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Topic } from '../../../models/topics/topic';
import { SubtopicsService } from '../subtopics/subtopics.service';

@Injectable({
  providedIn: 'root'
})
export class TopicsService {

  private key = "topics";

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

  addTopic(topic: Topic): void {
    if (topic) {
      let topics = this.topics;
      if (!topics) {
        topics = [];
      }
      for (let i = 0; i < topics.length; i++) {
        if (topic.id == topics[i].id) {
          return;
        }
      }
      topics.push(topic);
      this.topics = topics;
    }
  }

  removeTopic(topic: Topic): void {
    if (topic) {
      let topics = this.topics;
      if (!topics) {
        topics = [];
      }
      for (let i = 0; i < topics.length; i++) {
        if (topic.id == topics[i].id) {
          topics.splice(i, 1);
          this.topics = topics;
          return;
        }
      }
    }
  }
}
