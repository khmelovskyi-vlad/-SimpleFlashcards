import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-flashcards-header',
  templateUrl: './flashcards-header.component.html',
  styleUrls: ['./flashcards-header.component.scss']
})
export class FlashcardsHeaderComponent implements OnInit {

  @Input() topic: string = "";
  @Output() topicEvent = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }

  changeTopic(topic: string){
    this.topic = topic;
    this.topicEvent.emit(topic);
  }

}
