import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Subtopic } from '../../../models/topics/subtopic';

@Injectable({
  providedIn: 'root'
})
export class SubtopicsService {

  private key = "subtopics";

  private selectedSubtopics = new BehaviorSubject(this.subtopics);
  constructor() { }

  addSubtopic(value: Subtopic){
    const currentSubtopics = this.subtopics;
    currentSubtopics.push(value);
    this.subtopics = currentSubtopics;
  }

  removeSubtopic(value: Subtopic){
    let currentSubtopics = this.subtopics;
    currentSubtopics = currentSubtopics.filter(el => el.id != value.id);
    this.subtopics = currentSubtopics;
  }
  
  set subtopics(value: Subtopic[]) {
    localStorage.setItem(this.key, JSON.stringify(value));
    this.selectedSubtopics.next(value);
  }
 
  get subtopics(): Subtopic[] {
    const json = localStorage.getItem(this.key);
    if (json != undefined) {
      return JSON.parse(json) as Subtopic[];
    }
    else{
      return [];
    }
  }
}
