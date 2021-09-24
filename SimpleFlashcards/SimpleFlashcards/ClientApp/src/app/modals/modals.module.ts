import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EditTopicComponent } from './topics/edit-topic/edit-topic.component';
import { MainTopicComponent } from './topics/main-topic/main-topic.component';
import { AddTopicComponent } from './topics/add-topic/add-topic.component';
import { FormsModule } from '@angular/forms';
import { SelectTopicComponent } from './topics/select-topic/select-topic.component';
import { EditTopicsComponent } from './topics/edit-topics/edit-topics.component';
import { SelectTopicsComponent } from './topics/select-topics/select-topics.component';


@NgModule({
  declarations: [
    EditTopicComponent,
    MainTopicComponent,
    AddTopicComponent,
    SelectTopicComponent,
    EditTopicsComponent,
    SelectTopicsComponent,
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports:[
    MainTopicComponent
  ]
})
export class ModalsModule { }
