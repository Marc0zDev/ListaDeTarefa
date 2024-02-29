import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { ButtonModule } from 'primeng/button';

import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';
import {
  MatDialog,
  MatDialogRef,
  MatDialogActions,
  MatDialogClose,
  MatDialogTitle,
  MatDialogContent,
} from '@angular/material/dialog';
import { HomeComponent } from './pages/home/home.component';
import { LayoutComponent } from './layout/layout/layout.component';
import { HttpClientModule } from '@angular/common/http';
import { TarefasCrudComponent } from './pages/tarefas-crud/tarefas-crud.component';
import { ModalExcluirComponent } from './pages/tarefas-crud/modal-excluir/modal-excluir.component';
import { ModalAdicionarComponent } from './pages/tarefas-crud/modal-adicionar/modal-adicionar.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { FormsModule } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LayoutComponent,
    TarefasCrudComponent,
    ModalExcluirComponent,
    ModalAdicionarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatButtonModule,
    MatTableModule,
    MatCardModule,
    HttpClientModule,
    MatDialogActions,
    MatDialogClose, 
    MatDialogTitle, 
    MatDialogContent,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    FormsModule ,
    MatNativeDateModule 
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
