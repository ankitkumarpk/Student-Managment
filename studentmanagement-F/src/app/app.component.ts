import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { AddComponent } from './student/add/add.component';
import { EditComponent } from './student/edit/edit.component';
import { ListComponent } from './student/list/list.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    AddComponent,
    EditComponent,
    ListComponent,
    RouterLink,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'studentmanagement';
}
