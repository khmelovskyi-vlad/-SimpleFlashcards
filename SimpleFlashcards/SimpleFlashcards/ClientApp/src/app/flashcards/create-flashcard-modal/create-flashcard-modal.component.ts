import { Component, Input, OnChanges, OnInit, SimpleChange } from '@angular/core';
import { LanguagesService } from '../../services/languages/languages.service';
import { Flashcard } from '../../models/flashcard';
import { Word } from '../../models/word';
import { ImgInfo } from '../../models/images/img-info';

@Component({
  selector: 'app-create-flashcard-modal',
  templateUrl: './create-flashcard-modal.component.html',
  styleUrls: ['./create-flashcard-modal.component.scss']
})
export class CreateFlashcardModalComponent implements OnInit {

  @Input() showButton = true;
  newFlashcard = new Flashcard();
  images: File[][] = [];
  imgInfo: ImgInfo[][] = [];
  
  constructor(public languagesService: LanguagesService) { }

  ngOnInit(): void {
    this.addWord(true);
  }

  uploadImage(files: FileList, index: number): void {
    if (files) {
      for (var i = 0; i < files.length; i++) {
        this.getImageUrl(files[i], index);
        this.images[index].push(files[i]);
      }
    }
  }

  getImageUrl(image: File, index: number): void {
    const mimeType = image.type;
    if (mimeType.match(/image\/*/) == null) {
        return;
    }
    const reader = new FileReader();
    reader.readAsDataURL(image); 
    reader.onload = (_event) => { 
      this.imgInfo[index].push(new ImgInfo(image, reader.result.toString()));
    }
  };

  removeImage(image: File, index: number): void{
    this.images[index] = this.images[index].filter(el => el != image);
    this.imgInfo[index] = this.imgInfo[index].filter(el => el.image != image);
  }

  addWord(isMain: boolean): void{
    const word = new Word();
    word.isMain = isMain;
    this.newFlashcard.words.push(word);
    this.images.push([]);
    this.imgInfo.push([]);
  }
  // foo(): string[]{
  //   const res: string[] = [];
  //   for (let i = 0; i < this.images.length; i++) {
  //     this.imageUrls.push(URL.createObjectURL(this.images[i]));
  //     res.push(URL.createObjectURL(this.images[i]));
      
  //   }
  //   return res;
  // }

}
