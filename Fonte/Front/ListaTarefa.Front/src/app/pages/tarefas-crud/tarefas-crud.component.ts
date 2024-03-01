
import { TarefaPageMessage } from './../../core/model/_pageMessage/tarefaPageMessage';
import { HttpHeaders } from '@angular/common/http';
import { TarefaFilter } from './../../core/model/tarefaFilter';
import { Tarefa } from './../../core/model/tarefa';
import { TarefaServiceService } from './../../core/services/tarefa.service';
import { AfterViewInit, ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ModalExcluirComponent } from './modal-excluir/modal-excluir.component';
import { ModalAdicionarComponent } from './modal-adicionar/modal-adicionar.component';
import { Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import {MatSnackBar} from '@angular/material/snack-bar';
import { ModalVisualizarComponent } from './modal-visualizar/modal-visualizar.component';

@Component({
  selector: 'app-tarefas-crud',
  templateUrl: './tarefas-crud.component.html',
  styleUrl: './tarefas-crud.component.scss'
})
export class TarefasCrudComponent implements AfterViewInit{
   displayedColumns: string[] = ['Titulo', 'Descrição', 'DatadeVencimento', 'Status', 'Ações'];
   dataSource = new MatTableDataSource<Tarefa>();
   tarefaFilter: TarefaFilter = {};
    totalitems: number;
    pageSize: number;
    pageEvent: PageEvent;
   statusOptions = [
    { label: 'Pendente', value: 'Pendente' },
    { label: 'Em Andamento', value: 'EmAndamento' },
    { label: 'Concluída', value: 'Concluida' }
  ];
  @ViewChild(MatPaginator) paginator: MatPaginator;

    constructor(private tarefaService: TarefaServiceService, 
      private change: ChangeDetectorRef,
      private modal: MatDialog,
      private router: Router,
      private _snackBar: MatSnackBar
    ) { }


    ngAfterViewInit() {
      this.dataSource.paginator = this.paginator;
      this.loadTarefas();
    }
    
    

    loadTarefas(): void {
      this.tarefaService.buscarTarefas(this.tarefaFilter, this.paginator.pageIndex + 1, this.paginator.pageSize)
        .then((response) => {
          this.dataSource = new MatTableDataSource(response.items as Tarefa[]);
          this.totalitems = response.totalCount;
          this.pageSize = response.pageSize;
        })
        .catch((error: { error: string; }) => {
          console.log(error);
          this._snackBar.open(error.error, 'Fechar', { duration: 2000 });
        });
    }

  openDeleteDialog(tarefa: Tarefa): void {
    const dialogRef = this.modal.open(ModalExcluirComponent, {
      width: '450px',
      data: tarefa
    });
    
    this.loadTarefas();
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadTarefas();
      }
      this._snackBar.open("Tarefa Excluida!", 'Fechar', { duration: 2000 });
    });
  }

  openEditDialog(tarefa: Tarefa): void {
    const dialogRef = this.modal.open(ModalAdicionarComponent, {
      width: '70%',
      data: {...tarefa}
    });
  
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadTarefas();
      }
      this._snackBar.open("Tarefa Editada!", 'Fechar', { duration: 2000 });
    });
}

openCreateDialog(): void {
    const tarefa = {id: 0} as Tarefa;
    const dialogRef = this.modal.open(ModalAdicionarComponent, {
      width: '70%',
      data: tarefa
    });
   
    dialogRef.afterClosed().subscribe(result => {
      this.loadTarefas();
      this._snackBar.open("Tarefa Criada!", 'Fechar', { duration: 2000 });
    });
}

openViewDialog(tarefa: Tarefa): void {
  const dialogRef = this.modal.open(ModalVisualizarComponent, {
    width: '70%',
    data: tarefa
  });
}


  filter(): void {
    this.loadTarefas();
    
  }

  limparFiltros() {
		this.tarefaFilter = new TarefaFilter();
		this.loadTarefas();
	}

  onPageChange(event: PageEvent) {
    let page = event.pageIndex + 1;
    let pageSize = event.pageSize;
    this.tarefaService.buscarTarefas(this.tarefaFilter, page, pageSize).then((response) => { 
      this.dataSource.data = response.items as Tarefa[];
      this.totalitems = response.totalCount;
      this.pageSize = response.pageSize;
      this.change.detectChanges();
    }).catch((error: { error: string; }) => {
      console.log(error);
      this._snackBar.open(error.error, 'Fechar', { duration: 2000 });
    });

  }
  
  
}
