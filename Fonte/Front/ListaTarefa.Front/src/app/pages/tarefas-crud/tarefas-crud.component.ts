import { Tarefa } from './../../core/model/tarefa';
import { TarefaServiceService } from './../../core/services/tarefa.service';
import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ModalExcluirComponent } from './modal-excluir/modal-excluir.component';
import { ModalAdicionarComponent } from './modal-adicionar/modal-adicionar.component';
import { Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-tarefas-crud',
  templateUrl: './tarefas-crud.component.html',
  styleUrl: './tarefas-crud.component.scss'
})
export class TarefasCrudComponent implements OnInit{
   displayedColumns: string[] = ['Titulo', 'Descrição', 'DatadeVencimento', 'Status', 'Ações'];
   dataSource = new MatTableDataSource<Tarefa>();

   @ViewChild(MatPaginator) paginator: MatPaginator | undefined;

    constructor(private tarefaService: TarefaServiceService, 
      private change: ChangeDetectorRef,
      private modal: MatDialog,
      private router: Router
    ) { }

    ngOnInit(): void {
      if (this.paginator) {
        this.dataSource.paginator = this.paginator;
      }
      this.loadTarefas();
    }
    
    

  loadTarefas(): void {
    this.tarefaService.listarTarefas().then((response) => {
      this.dataSource.data = response;
    });
  }

  openDeleteDialog(tarefa: Tarefa): void {
    const dialogRef = this.modal.open(ModalExcluirComponent, {
      width: '450px',
      data: tarefa
    });
    
    this.loadTarefas();
    this.change.detectChanges();
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
    });
}

openCreateDialog(): void {
    const tarefa = {id: 0} as Tarefa;
    const dialogRef = this.modal.open(ModalAdicionarComponent, {
      width: '70%',
      data: tarefa
    });
   
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadTarefas();
      }
    });
}

  filterByStatus(status: number): void {
    if(status == 0) {
      this.loadTarefas();
      console.log('teste');
    }else{
      this.tarefaService.buscarTarefaPorStatus(status).then((response) => {
        this.dataSource.data = response;
      }).catch((error) => {
        console.error(error);
      })
    }
    
  }

}
