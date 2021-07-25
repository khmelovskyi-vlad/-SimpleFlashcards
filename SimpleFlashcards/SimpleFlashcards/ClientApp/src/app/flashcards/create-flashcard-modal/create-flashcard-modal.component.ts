import { Component, Input, OnInit } from '@angular/core';
import { LanguagesService } from '../../services/languages/languages.service';
import { Flashcard } from '../../models/flashcard';
import { Word } from '../../models/word';

@Component({
  selector: 'app-create-flashcard-modal',
  templateUrl: './create-flashcard-modal.component.html',
  styleUrls: ['./create-flashcard-modal.component.scss']
})
export class CreateFlashcardModalComponent implements OnInit {

  @Input() showButton = true;
  newFlashcard = new Flashcard();
  
  constructor(public languagesService: LanguagesService) { }

  ngOnInit(): void {
    const word = new Word();
    this.newFlashcard.words.push(word);
  }

}
