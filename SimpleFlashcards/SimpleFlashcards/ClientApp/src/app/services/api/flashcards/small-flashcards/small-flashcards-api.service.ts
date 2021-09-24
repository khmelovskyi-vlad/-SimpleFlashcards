import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { SmallFlashcard } from '../../../../models/flashcards/small-flashcard';
import { ErrorHandlerService } from '../../../error-handler/error-handler.service';
import { UrlCreatorService } from '../../../url-creator/url-creator.service';


import * as flashcardPath from '../../../../../assets/pathes/flashcard-path.json';

@Injectable({
  providedIn: 'root'
})
export class SmallFlashcardsApiService {

  constructor(private http: HttpClient, private errorHandler: ErrorHandlerService, private urlCreator: UrlCreatorService) { }

  getFlashcards(countryId: number, topics: string[] = undefined): Observable<SmallFlashcard[]>{
    const pathParts = [flashcardPath.StartPath, countryId.toString()];
    const url = this.urlCreator.createMainApiUrl(pathParts);
    return this.http.post<SmallFlashcard[]>(url, topics)
    .pipe(
      catchError(this.errorHandler.handleError<SmallFlashcard[]>('getFlashcards'))
    );
  }
}
