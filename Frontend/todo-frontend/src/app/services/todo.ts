import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Todo } from '../models/todo.model'; 


@Injectable({
  providedIn: 'root'
})
export class TodoService {
  baseApiUrl: string = "https://localhost:7112";

  constructor(private http: HttpClient) {}

  getAllTodos(): Observable<Todo[]> {  
    return this.http.get<Todo[]>(this.baseApiUrl + '/api/ToDoApi');
  }

  addTodo(newTodo:Todo): Observable<Todo>{  
    return this.http.post<Todo>(this.baseApiUrl + '/api/ToDoApi',newTodo)
  }
  updateToDo(id:string,todo:Todo):Observable<Todo>{
    return this.http.put<Todo>(this.baseApiUrl + '/api/ToDoApi/' + id, todo)
}
  deleteTodo(id:string):Observable<Todo>{
    return this.http.delete<Todo>(this.baseApiUrl+'/api/ToDoApi/'+id)
  }
  
}

