import { Subtopic } from "./subtopic";

export class Topic{
  id: string;
  value: string = '';
  subtopics: Subtopic[] = [];
  creationDate: string;
  updateDate: string;
  isCreated: boolean = false;
}