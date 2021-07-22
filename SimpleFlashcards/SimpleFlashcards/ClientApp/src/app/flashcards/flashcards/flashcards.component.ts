import { Component, OnInit } from '@angular/core';
import { Country } from 'src/app/models/country';
import { Word } from 'src/app/models/word';
import { Flashcard } from '../../models/flashcard';

@Component({
  selector: 'app-flashcards',
  templateUrl: './flashcards.component.html',
  styleUrls: ['./flashcards.component.scss']
})
export class FlashcardsComponent implements OnInit {

  flashcards: Flashcard[] = [];
  country: Country;
  topic = "";

  constructor() { }

  ngOnInit(): void {
    const firstCountry = new Country();
    firstCountry.id = '100';
    firstCountry.name = 'eng';
    const secondCountry = new Country();
    secondCountry.id = '101';
    secondCountry.name = 'ukr';
    this.country = firstCountry;

    const flashcard1 = new Flashcard();
    flashcard1.id = '1';
    flashcard1.words = [];

    const word1 = new Word();
    word1.id = '11';
    word1.flashcardId = flashcard1.id;
    word1.transcription = 'some tr';
    word1.value = 'some word';
    word1.countryId = firstCountry.id;
    word1.country = firstCountry;
    flashcard1.words.push(word1);

    const word2 = new Word();
    word2.id = '12';
    word2.flashcardId = flashcard1.id;
    word2.transcription = 'some tr2';
    word2.value = 'some word2';
    word2.countryId = firstCountry.id;
    word2.country = firstCountry;
    flashcard1.words.push(word2);

    const flashcard2 = new Flashcard();
    flashcard2.id = '1';
    flashcard2.words = [];

    const word3 = new Word();
    word3.id = '13';
    word3.flashcardId = flashcard2.id;
    word3.transcription = 'some tr3';
    word3.value = 'some word3';
    word3.countryId = firstCountry.id;
    word3.country = firstCountry;
    flashcard2.words.push(word3);

    const word4 = new Word();
    word4.id = '14';
    word4.flashcardId = flashcard2.id;
    word4.transcription = 'some tr4';
    word4.value = 'some word4';
    word4.countryId = firstCountry.id;
    word4.country = firstCountry;
    flashcard2.words.push(word4);

    this.flashcards.push(flashcard1);
    this.flashcards.push(flashcard2);
    console.log(this.flashcards);
  }
  
  changeTopic(topic: string): void{
    this.topic = topic;
  }
  getWords(): Word[]{
    const words: Word[] = [];
    if(this.flashcards && this.flashcards){
      for (let i = 0; i < this.flashcards.length; i++) {
        const word = this.flashcards[i].words.find(w => w.countryId == this.country.id);
        if (word) {
          words.push(word);
        }
      }
    }
    return words;
  }
  getWord(flashcard: Flashcard): Word{
    if(flashcard && flashcard.words){
      return flashcard.words.find(w => w.countryId == this.country.id);
    }
    return undefined;
  }

}
