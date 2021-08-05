import { PartOfSpeech } from "../../value-objects/part-of-speech";
import { Language } from "../maps/language";

export class Word{
  id: string;
  value: string;
  transcription: string;
  partOfSpeech: PartOfSpeech = PartOfSpeech.no;
  languageId: number;
  language: Language;
  flashcardId: string;
  pronunciationIds: string[];
  imageIds: string[];
  isMain: boolean;
}