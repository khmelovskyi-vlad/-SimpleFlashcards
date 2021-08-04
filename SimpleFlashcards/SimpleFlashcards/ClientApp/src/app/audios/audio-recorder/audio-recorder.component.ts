import { Component, OnInit } from '@angular/core';

import * as RecordRTC from 'recordrtc';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-audio-recorder',
  templateUrl: './audio-recorder.component.html',
  styleUrls: ['./audio-recorder.component.scss']
})
export class AudioRecorderComponent implements OnInit {

  url: string;
  error: string;
  record: RecordRTC.StereoAudioRecorder;
  recording = false;
  
  sanitize(url: string) {
    return this.domSanitizer.bypassSecurityTrustUrl(url);
  }

  constructor(private domSanitizer: DomSanitizer) { }

  ngOnInit(): void {
  }

  
  /**
* Start recording.
*/
  initiateRecording(): void {
      this.recording = true;
      let mediaConstraints = {
        video: false,
        audio: true
      };
      navigator.mediaDevices.getUserMedia(mediaConstraints)
        .then(this.successCallback.bind(this), this.errorCallback.bind(this) );
  }

  successCallback(stream: MediaStream): void {
    const options = {
      mimeType: "audio/wav",
      numberOfAudioChannels: 1,
      sampleRate: 16000,
    };
    const StereoAudioRecorder = RecordRTC.StereoAudioRecorder;
    this.record = new StereoAudioRecorder(stream, options);
    this.record.record();
  }

  stopRecording(): void {
    this.recording = false;
    this.record.stop(this.processRecording.bind(this));
  }
  
  processRecording(blob: Blob): void {
    this.url = URL.createObjectURL(blob);
    console.log("blob", blob);
    console.log("url", this.url);
  }
  
  errorCallback(error: string): void {
    this.error = 'Can not play audio in your browser';
  }

}
