import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Subtopic } from '../../../models/topics/subtopic';
import { ErrorHandlerService } from '../../error-handler/error-handler.service';
import { UrlCreatorService } from '../../url-creator/url-creator.service';

import * as subtopicPath from '../../../../assets/pathes/subtopic-path.json';

@Injectable({
  providedIn: 'root'
})
export class SubtopicsApiService {

  constructor(private http: HttpClient, private errorHandler: ErrorHandlerService, private urlCreator: UrlCreatorService) { }

  addSubtopic(subtopic: Subtopic): Observable<Subtopic>{
    const pathParts = [subtopicPath.StartPath];
    const url = this.urlCreator.createMainApiUrl(pathParts);
    return this.http.post<Subtopic>(url, subtopic)
            .pipe(
              catchError(this.errorHandler.handleError<Subtopic>('addSubtopic'))
            );
  }

  editSubtopic(topic: Subtopic): Observable<Subtopic>{
    const pathParts = [subtopicPath.StartPath];
    const url = this.urlCreator.createMainApiUrl(pathParts);
    return this.http.put<Subtopic>(url, topic)
            .pipe(
              catchError(this.errorHandler.handleError<Subtopic>('editSubtopic'))
            );
  }

  removeSubtopic(id: string): Observable<any>{
    const pathParts = [subtopicPath.StartPath, id];
    const url = this.urlCreator.createMainApiUrl(pathParts);
    return this.http.delete(url)
            .pipe(
              catchError(this.errorHandler.handleError<any>('removeSubtopic'))
            );
  }
}
