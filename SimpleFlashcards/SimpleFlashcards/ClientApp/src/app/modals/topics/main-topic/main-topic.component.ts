import { Component, Input, OnInit } from '@angular/core';
import { GeneralDataService } from '../../../services/general-data/general-data.service';

@Component({
  selector: 'app-main-topic',
  templateUrl: './main-topic.component.html',
  styleUrls: ['./main-topic.component.scss']
})
export class MainTopicComponent implements OnInit {

  @Input() showButton = true;
  
  constructor(public generalData: GeneralDataService) { }

  ngOnInit(): void {
  }

}
