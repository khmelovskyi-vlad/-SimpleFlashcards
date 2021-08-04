import { Component, Input, OnInit } from '@angular/core';
import { TopicsApiService } from '../../../services/api/topics/topics-api.service';
import { Subtopic } from '../../../models/topics/subtopic';
import { Topic } from '../../../models/topics/topic';

@Component({
  selector: 'app-edit-topic',
  templateUrl: './edit-topic.component.html',
  styleUrls: ['./edit-topic.component.scss']
})
export class EditTopicComponent implements OnInit {

  @Input() topic: Topic;
  constructor(private topicsApiService: TopicsApiService) { }

  ngOnInit(): void {
  }

  edit(){
    this.topicsApiService.editTopic(this.topic).subscribe(topic => this.topic = topic);
  }
  
  addSubtopic(){
    this.topic.subtopics.push(new Subtopic());
  }

}
