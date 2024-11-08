import { Routes } from '@angular/router';
import { AddComponent } from './student/add/add.component';
import { EditComponent } from './student/edit/edit.component';
import { ListComponent } from './student/list/list.component';

export const routes: Routes = [
  { path: 'add', component: AddComponent },
  { path: 'edit', component: EditComponent },
  { path: 'list', component: ListComponent },
];
