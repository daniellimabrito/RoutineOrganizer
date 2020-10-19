import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AgendaFormComponent } from './agenda-form/agenda-form.component';


const routes: Routes = [
  { path: 'agendaForm', component: AgendaFormComponent},
  { path: '', pathMatch: 'full', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
