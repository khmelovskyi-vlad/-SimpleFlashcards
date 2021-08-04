import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AudioRecorderComponent } from './audio-recorder/audio-recorder.component';


@NgModule({
  declarations: [
    AudioRecorderComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    AudioRecorderComponent
  ]
})
export class AudiosModule { }
