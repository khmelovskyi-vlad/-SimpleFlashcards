import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService {

  constructor(private router: Router) { }
  
  handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      if (error.status === 500) {
        this.router.navigate(['internal-server-error']);
      }
      else if (error.status === 404) {
        this.router.navigate(['page-not-found']);
      }
      console.error(error);
      return of(result as T);
    }
  }
}
