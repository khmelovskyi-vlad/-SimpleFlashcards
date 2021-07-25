import { Word } from "./word";

export class Flashcard{
  constructor(){

  }
  id: string;
  value: string;
  topic: string;
  words: Word[] = [];
}