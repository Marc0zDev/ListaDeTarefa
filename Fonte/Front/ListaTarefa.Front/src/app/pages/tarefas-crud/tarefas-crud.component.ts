import { Tarefa } from './../../core/model/tarefa';
import { TarefaServiceService } from './../../core/services/tarefa.service';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ModalExcluirComponent } from './modal-excluir/modal-excluir.component';
import { ModalAdicionarComponent } from './modal-adicionar/modal-adicionar.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tarefas-crud',
  templateUrl: './tarefas-crud.component.html',
  styleUrl: './tarefas-crud.component.scss'
})
export class TarefasCrudComponent implements OnInit{
  dataSource: Tarefa[] = [];
   displayedColumns: string[] = ['Titulo', 'Descrição', 'DatadeVencimento', 'Status', 'Ações'];

    constructor(private tarefaService: TarefaServiceService, 
      private change: ChangeDetectorRef,
      private modal: MatDialog,
      private router: Router
    ) { }

  ngOnInit(): void {
    this.tarefaService.listarTarefas().then((response) => {
      this.dataSource = response;
    });
  }

  openDeleteDialog(tarefa: Tarefa): void {
    const dialogRef = this.modal.open(ModalExcluirComponent, {
      width: '450px',
      data: tarefa
    });
  }

  openEditDialog(tarefa: Tarefa): void {
    const dialogRef = this.modal.open(ModalAdicionarComponent, {
      width: '70%',
      data: {...tarefa}
    });
    this.change.detectChanges();
    this.router
            .navigateByUrl('/tarefas', { skipLocationChange: true })
            .then(() => {
              this.router.navigate([this.router.url]);
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
        // Atualiza a página após fechar o diálogo
        this.router.navigateByUrl('/tarefas', { skipLocationChange: true }).then(() => {
          this.router.navigate(['/tarefas']);
        });
      }
    });
  }

}
