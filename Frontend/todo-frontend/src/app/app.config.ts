import { ApplicationConfig, provideBrowserGlobalErrorListeners, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { routes } from './app.routes';
import { Observable } from 'rxjs';
import { Todo } from './models/todo.model'; 
import { FormsModule } from '@angular/forms';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes)
  ]
};
export class TodoService {
  baseApiUrl: string = "https://localhost:7112";

  constructor(private http: HttpClient) {}

  getAllTodos(): Observable<Todo[]> {  
    return this.http.get<Todo[]>(this.baseApiUrl + '/api/ToDoApi');
  }
}
