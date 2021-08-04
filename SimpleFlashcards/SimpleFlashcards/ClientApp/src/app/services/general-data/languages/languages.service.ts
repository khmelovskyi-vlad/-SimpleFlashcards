import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Country } from '../../../models/maps/country';
import { ErrorHandlerService } from '../../error-handler/error-handler.service';
import { UrlCreatorService } from '../../url-creator/url-creator.service';


import * as languagePath from '../../../../assets/pathes/language-path.json';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LanguagesService {

  public languages: Country[] = [];
  constructor(private http: HttpClient, private errorHandler: ErrorHandlerService, private urlCreator: UrlCreatorService) {
    console.log('foo');
    console.log('foo');
    console.log('foo');
    console.log('foo');
    console.log('foo');
    this.getLanguages().subscribe(countries => console.log(countries));
   }
  
  getLanguages(): Observable<Country[]>{
    const country = new Country();
    country.id = 1;
    country.name = 'Ukraine';
    const country2 = new Country();
    country2.id = 2;
    country2.name = 'Eng';
    this.languages.push(country);
    this.languages.push(country2);

    const url = this.urlCreator.createMainApiUrl([languagePath.StartPath]);
    return this.http.get<Country[]>(url)
    .pipe(
      catchError(this.errorHandler.handleError<Country[]>('getLanguages'))
    );

  }
}
