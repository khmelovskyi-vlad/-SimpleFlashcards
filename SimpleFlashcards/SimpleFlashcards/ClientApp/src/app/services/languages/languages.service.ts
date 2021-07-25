import { Injectable } from '@angular/core';
import { Country } from '../../models/country';

@Injectable({
  providedIn: 'root'
})
export class LanguagesService {

  public languages: Country[] = [];
  constructor() {
    this.getLanguages();
   }
  
  getLanguages(): void{
    const country = new Country();
    country.id = '1';
    country.name = 'Ukraine';
    const country2 = new Country();
    country2.id = '2';
    country2.name = 'Eng';
    this.languages.push(country);
    this.languages.push(country2);
  }
}
