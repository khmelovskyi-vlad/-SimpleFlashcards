import { Component, OnInit } from '@angular/core';
import { Subtopic } from '../../../models/topics/subtopic';
import { Topic } from '../../../models/topics/topic';
import { TopicsApiService } from '../../../services/api/topics/topics-api.service';

@Component({
  selector: 'app-add-topic',
  templateUrl: './add-topic.component.html',
  styleUrls: ['./add-topic.component.scss']
})
export class AddTopicComponent implements OnInit {

  topic: Topic;
  constructor(private topicsApiService: TopicsApiService) { }

  ngOnInit(): void {
    this.topic = new Topic();
  }

  addSubtopic(){
    this.topic.subtopics.push(new Subtopic());
  }

  addTopic(){
    this.topicsApiService.addTopic(this.topic).subscribe(topic => this.topic = topic);
  }

}
