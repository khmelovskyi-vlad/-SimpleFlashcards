import { PartOfSpeech } from "../../value-objects/part-of-speech";
import { Country } from "../country";

export class Word{
  id: string;
  value: string;
  transcription: string;
  partOfSpeech: PartOfSpeech = PartOfSpeech.no;
  countryId: string;
  country: Country;
  flashcardId: string;
  pronunciationIds: string[];
  imageIds: string[];
  isMain: boolean;
}