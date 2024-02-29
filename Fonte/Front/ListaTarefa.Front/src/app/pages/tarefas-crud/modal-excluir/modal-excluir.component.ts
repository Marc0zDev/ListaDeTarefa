import { Tarefa } from './../../../core/model/tarefa';
import { ChangeDetectorRef, Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { TarefaServiceService } from '../../../core/services/tarefa.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-modal-excluir',
  templateUrl: './modal-excluir.component.html',
  styleUrl: './modal-excluir.component.scss'
})
export class ModalExcluirComponent {
  constructor(
    public dialogRef: MatDialogRef<ModalExcluirComponent>,
    @Inject(MAT_DIALOG_DATA) public tarefa: Tarefa,
    private tarefaService : TarefaServiceService,
    private change: ChangeDetectorRef,
    private router: Router
  ) { }

  excluir(){
    this.tarefaService.excluirTarefa(this.tarefa).then(() => {
      this.dialogRef.close();
      this.change.detectChanges();
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        this.router.navigate([this.router.url]);
      });
    });
  }
}
