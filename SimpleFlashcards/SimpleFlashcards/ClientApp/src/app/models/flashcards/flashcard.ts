import { Word } from "../words/word";

export class Flashcard{
  constructor(){

  }
  id: string;
  value: string;
  topics: string[];
  words: Word[] = [];
}