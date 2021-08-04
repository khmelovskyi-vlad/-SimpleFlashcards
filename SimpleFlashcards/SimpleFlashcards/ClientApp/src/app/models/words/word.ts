import { PartOfSpeech } from "../../value-objects/part-of-speech";
import { Country } from "../maps/country";

export class Word{
  id: string;
  value: string;
  transcription: string;
  partOfSpeech: PartOfSpeech = PartOfSpeech.no;
  countryId: number;
  country: Country;
  flashcardId: string;
  pronunciationIds: string[];
  imageIds: string[];
  isMain: boolean;
}