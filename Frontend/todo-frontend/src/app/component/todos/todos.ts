import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Todo } from '../../models/todo.model';
import { TodoService } from '../../services/todo';
import { RouterOutlet,RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';



@Component({
  selector: 'app-todos',
  standalone: true, 
  imports: [CommonModule, RouterOutlet,RouterLink,FormsModule], 
  templateUrl: './todos.html',
  styleUrls: ['./todos.scss'] 
})
export class Todos implements OnInit{
  todos: Todo[] = [];

  constructor(private todoService : TodoService){}
  ngOnInit(): void {
    this.todoService.getAllTodos()
      .subscribe({
        next : (todos) => {
           this.todos = todos
          }
        })
  }
}


