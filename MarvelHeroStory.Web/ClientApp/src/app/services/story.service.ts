import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { IStory } from '../model/story.model';
@Injectable({ providedIn: 'root' })

export class StoryService {
  baseUrl = "";
  constructor(@Inject('BASE_URL') _baseUrl: string, private httpClient: HttpClient) {
   this.baseUrl = _baseUrl; 
  }

  getStory(): Observable<IStory> {
    return this.httpClient.get<IStory>(`${this.baseUrl}api/story`)
    .pipe(
      tap(_ => console.log('fetched Story'),
      catchError(this.handleError<IStory>('getStory'))
    ));
  }
  
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.log(error);
      console.log(`${operation} failed> ${error.message}`);
      return of (result as T);
    }
  }
}
