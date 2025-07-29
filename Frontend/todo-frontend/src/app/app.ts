import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet,RouterLink } from '@angular/router';
import { Todo } from './models/todo.model';        // todo.model.ts dosyasının yolu
import { TodoService } from './services/todo'; // todo.service.ts dosyasının yolu
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet,RouterLink,FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class AppComponent { 
  todos: Todo[] = [];
  newTodo : Todo = {
    id :'',
    title :'',
    description :'',
    isCompleted :false,
    createdAt : new Date()
  }

  constructor(private todoService : TodoService){}
  ngOnInit(): void {
    this.getAllTodos()
  }

  getAllTodos(){
        this.todoService.getAllTodos()
      .subscribe({
        next : (todos) => {
           this.todos = todos
          }
        })
  }
  addTodo(){
      console.log(this.newTodo);
      this.todoService.addTodo(this.newTodo)
        .subscribe({
          next : (todos) =>{
            this.getAllTodos()
          }
        })
  }

  onCompletedChange(id:string,todo:Todo){
    todo.isCompleted= !todo.isCompleted;
    this.todoService.updateToDo(id,todo)
    .subscribe({
      next:(response) =>{
        this.getAllTodos()
      }
    })
  }

  deleteTodo(id:string){
    this.todoService.deleteTodo(id)
    .subscribe({
      next : (response) =>{
        this.getAllTodos();
      }
        
    })
  }


}


