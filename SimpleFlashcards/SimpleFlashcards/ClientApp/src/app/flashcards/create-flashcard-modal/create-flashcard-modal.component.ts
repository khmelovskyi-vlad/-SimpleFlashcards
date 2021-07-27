import { Component, Input, OnChanges, OnInit, SimpleChange } from '@angular/core';
import { LanguagesService } from '../../services/languages/languages.service';
import { Flashcard } from '../../models/flashcard';
import { Word } from '../../models/word';

@Component({
  selector: 'app-create-flashcard-modal',
  templateUrl: './create-flashcard-modal.component.html',
  styleUrls: ['./create-flashcard-modal.component.scss']
})
export class CreateFlashcardModalComponent implements OnInit, OnChanges {

  @Input() showButton = true;
  newFlashcard = new Flashcard();
  images: File[] = [];
  
  constructor(public languagesService: LanguagesService) { }

  ngOnInit(): void {
    const word = new Word();
    this.newFlashcard.words.push(word);
  }

  uploadImage(files: FileList) {
    if (files) {
      for (var i = 0; i < files.length; i++) {
        this.images.push(files[i]);
      }
    }
    console.log(this.images);
  }
  ngOnChanges(changes: any){
    console.log('okey');
    console.log('okey');
    console.log('okey');
    console.log('okey');
    console.log('okey');
    console.log('okey');
    console.log('okey');
    for (let propName in changes) {
      console.log(propName);
    }
  }

  getImageUrl(image: File): string {
    const url = URL.createObjectURL(image);
    console.log(url);
    
    // const files = event.target.files;
    // if (files.length === 0)
    //     return;

    const mimeType = image.type;
    if (mimeType.match(/image\/*/) == null) {
        // this.message = "Only images are supported.";
        return '';
    }

    const reader = new FileReader();
    reader.readAsDataURL(image); 
    reader.onload = (_event) => { 
        return reader.result; 
    }
    return url;
  };

}
