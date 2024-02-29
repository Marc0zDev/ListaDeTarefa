import { ChangeDetectorRef, Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { TarefaServiceService } from '../../../core/services/tarefa.service';
import { NgForm } from '@angular/forms';
import { Tarefa } from '../../../core/model/tarefa';
import { Router } from '@angular/router';

@Component({
  selector: 'app-modal-adicionar',
  templateUrl: './modal-adicionar.component.html',
  styleUrl: './modal-adicionar.component.scss',
})
export class ModalAdicionarComponent {
  isEdicao: boolean = false;
  tarefa: Tarefa = {};
  statusOptions = [
    { value: 1, label: 'Pendente' },
    { value: 2, label: 'Em Andamento' },
    { value: 3, label: 'Concluida' },
  ];

  constructor(
    public dialogRef: MatDialogRef<ModalAdicionarComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private tarefaService: TarefaServiceService,
    private change: ChangeDetectorRef,
    private router: Router
  ) {
    if (data.id != 0) {
      this.isEdicao = true;
    }
    this.tarefa = { ...data };
    console.log(this.isEdicao)
    console.log(data)
  }

  salvarTarefa(form: NgForm): void {
    if (form.valid) {
      this.tarefa.titulo = form.value.titulo;
      this.tarefa.descricao = form.value.descricao;
      this.tarefa.dataVencimento = form.value.dataVencimento;
      this.tarefa.status = form.value.status;
      this.tarefa.id = this.data.id;
      if (this.isEdicao) {
        this.tarefaService.atualizarTarefa(this.tarefa).then(() => {
          this.dialogRef.close();
          this.router
            .navigateByUrl('/tarefas', { skipLocationChange: true })
            .then(() => {
              this.router.navigate([this.router.url]);
            });
        });
      } else {
        this.tarefaService.cadastrarTarefa(this.tarefa).then(() => {
          this.dialogRef.close();
        });
      }
    }
  }
}
