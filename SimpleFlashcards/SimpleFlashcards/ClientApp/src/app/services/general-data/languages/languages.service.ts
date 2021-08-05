import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Language } from '../../../models/maps/language';
import { ErrorHandlerService } from '../../error-handler/error-handler.service';
import { UrlCreatorService } from '../../url-creator/url-creator.service';


import * as languagePath from '../../../../assets/pathes/language-path.json';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LanguagesService {

  public languages: Language[] = [];
  constructor(private http: HttpClient, private errorHandler: ErrorHandlerService, private urlCreator: UrlCreatorService) {
    this.getLanguages().subscribe(languages => this.languages = languages);
   }
  
  getLanguages(): Observable<Language[]>{
    const url = this.urlCreator.createMainApiUrl([languagePath.StartPath]);
    return this.http.get<Language[]>(url)
            .pipe(
              catchError(this.errorHandler.handleError<Language[]>('getLanguages'))
            );
  }
}
