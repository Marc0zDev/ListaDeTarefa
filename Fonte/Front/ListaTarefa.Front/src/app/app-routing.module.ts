import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { TarefasCrudComponent } from './pages/tarefas-crud/tarefas-crud.component';

const routes: Routes = [
  { 
    path: '', component: HomeComponent,
  },
  {
    path: 'tarefas', component: TarefasCrudComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
