import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Topic } from '../../../models/topics/topic';
import { ErrorHandlerService } from '../../error-handler/error-handler.service';
import { UrlCreatorService } from '../../url-creator/url-creator.service';

import * as topicPath from '../../../../assets/pathes/topic-path.json';

@Injectable({
  providedIn: 'root'
})
export class TopicsApiService {
  
  constructor(private http: HttpClient, private errorHandler: ErrorHandlerService, private urlCreator: UrlCreatorService) { }

  getTopics(part: string = undefined): Observable<Topic[]>{
    const pathParts = [topicPath.StartPath];
    if (part){
      pathParts.push(part);
    }
    const url = this.urlCreator.createMainApiUrl(pathParts);
    return this.http.get<Topic[]>(url)
            .pipe(
              catchError(this.errorHandler.handleError<Topic[]>('getTopics'))
            );
  }

  addTopic(topic: Topic): Observable<Topic>{
    const pathParts = [topicPath.StartPath];
    const url = this.urlCreator.createMainApiUrl(pathParts);
    return this.http.post<Topic>(url, topic)
            .pipe(
              catchError(this.errorHandler.handleError<Topic>('addTopic'))
            );
  }

  editTopic(topic: Topic): Observable<Topic>{
    const pathParts = [topicPath.StartPath];
    const url = this.urlCreator.createMainApiUrl(pathParts);
    return this.http.put<Topic>(url, topic)
            .pipe(
              catchError(this.errorHandler.handleError<Topic>('editTopic'))
            );
  }

  removeTopic(id: string): Observable<any>{
    const pathParts = [topicPath.StartPath, id];
    const url = this.urlCreator.createMainApiUrl(pathParts);
    return this.http.delete(url)
            .pipe(
              catchError(this.errorHandler.handleError<any>('removeTopic'))
            );
  }
}
