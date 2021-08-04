import { Injectable } from '@angular/core';
import { Subtopic } from '../../models/topics/subtopic';
import { Country } from '../../models/maps/country';
import { Topic } from '../../models/topics/topic';
import { ColorTheme } from '../../value-objects/color-theme';
import { ColorThemeService } from './color-theme/color-theme.service';
import { LanguagesService } from './languages/languages.service';
import { SubtopicsService } from './subtopics/subtopics.service';
import { TopicsService } from './topics/topics.service';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GeneralDataService {

  constructor(public colorThem: ColorThemeService,
    public languages: LanguagesService,
    public topics: TopicsService,
    public subtopics: SubtopicsService) { }

    // get colorTheme(): ColorTheme {
    //   return this.colorThemeService.colorTheme;
    // }

    // set colorTheme(value: ColorTheme) {
    //   this.colorThemeService.colorTheme = value;
    // }

    // get topic(): BehaviorSubject<Topic> {
    //   return this.topicsService.selectedTopic;
    // }

    // set topic(value: BehaviorSubject<Topic>) {
    //   this.topicsService.selectedTopic = value;
    // }

    // get subtopics(): Subtopic[] {
    //   return this.subtopicsService.subtopics;
    // }

    // set subtopics(value: Subtopic[]) {
    //   this.subtopicsService.subtopics = value;
    // }

    // removeSubtopic(subtopic: Subtopic): void {
    //   this.subtopicsService.removeSubtopic(subtopic);
    // }

    // addSubtopic(subtopic: Subtopic) {
    //   this.subtopicsService.addSubtopic(subtopic);
    // }

    // get languages(): Country[] {
    //   return this.languagesService.languages;
    // }
}
