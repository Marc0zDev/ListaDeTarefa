import { Component, OnInit } from '@angular/core';
import { Tarefa } from '../../core/model/tarefa';
import { TarefaServiceService } from '../../core/services/tarefa.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent implements OnInit {
  tarefas: Tarefa[] = [];
  hasTarefas: boolean = false;

  constructor(private tarefaService: TarefaServiceService) {}

  ngOnInit(): void {
    this.tarefaService
      .listarTarefasDiaHoje()
      .then((response) => {
        this.tarefas = response;
        this.hasTarefas = true;
        if (this.tarefas.length === 0) {
          this.hasTarefas = false;
        }
        console.log(this.tarefas);
      })
      .catch((error) => {
        console.log(error);
      });
  }

  mudarStatusTarefa(tarefa: Tarefa) {
    if (tarefa.status != 0 && tarefa.status != undefined) {
      if (tarefa.status === 3) {
        tarefa.status = 1;
      } else {
        tarefa.status++;
      }

      this.tarefaService
        .atualizarTarefa(tarefa)
        .then((response) => {
          console.log('Tarefa atualizada com sucesso:', response);
        })
        .catch((error) => {
          console.error('Erro ao atualizar tarefa:', error);
        });
    }
  }
}
