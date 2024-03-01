import { ChangeDetectorRef, Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Tarefa } from '../../../core/model/tarefa';

@Component({
  selector: 'app-modal-visualizar',
  templateUrl: './modal-visualizar.component.html',
  styleUrls: ['./modal-visualizar.component.scss'] // Correção aqui
})
export class ModalVisualizarComponent {
  tarefa: Tarefa = {};
  constructor(
    public dialogRef: MatDialogRef<ModalVisualizarComponent>,
    @Inject(MAT_DIALOG_DATA) public tarefaa: Tarefa,
    private change: ChangeDetectorRef,
    private router: Router
  ) {
    this.tarefa = { ...tarefaa };
   }
}
