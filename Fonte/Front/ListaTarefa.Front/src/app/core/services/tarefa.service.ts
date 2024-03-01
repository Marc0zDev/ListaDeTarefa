import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Tarefa } from '../model/tarefa';

@Injectable({
  providedIn: 'root',
})
export class TarefaServiceService {
  private readonly API = 'https://localhost:44301/api/Tarefa';
  constructor(private http: HttpClient) {}

  listarTarefas(): Promise<Tarefa[]> {
    return new Promise<Tarefa[]>((resolve, reject) => {
      this.http
        .get<Tarefa[]>(this.API + '/BuscarTodasTarefas')
        .toPromise()
        .then((response) => {
          resolve(response as Tarefa[]);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  listarTarefasDiaHoje(): Promise<Tarefa[]> {
    return new Promise<Tarefa[]>((resolve, reject) => {
      this.http
        .get<Tarefa[]>(this.API + '/BuscarTarefaDiaHoje')
        .toPromise()
        .then((response) => {
          resolve(response as Tarefa[]);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }


  excluirTarefa(tarefa: Tarefa) {
    return new Promise<any>((resolve, reject) => {
      this.http
        .delete(this.API + '/DeletarTarefa/' + tarefa.id)
        .toPromise()
        .then((response) => {
          resolve(response);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  cadastrarTarefa(tarefa: Tarefa): Promise<Tarefa> {
    return new Promise<Tarefa>((resolve, reject) => {
      this.http
        .post<Tarefa>(this.API + '/AdicionarTarefa', tarefa)
        .toPromise()
        .then((response) => {
          resolve(response as Tarefa);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  atualizarTarefa(tarefa: Tarefa): Promise<any> {
    const url = `${this.API}/AtualizarTarefa`;
    return this.http.put<any>(url, tarefa).toPromise();
  }

  buscarTarefaPorStatus(status: number): Promise<Tarefa[]> {
    return new Promise<Tarefa[]>((resolve, reject) => {
      this.http
        .get<Tarefa[]>(this.API + '/BuscarTarefaByStatus/' + status)
        .toPromise()
        .then((response) => {
          resolve(response as Tarefa[]);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  
  buscarTarefasComPaginacao(tarefaParameters: any): Promise<Tarefa[]> {
    return new Promise<Tarefa[]>((resolve, reject) => {
      const params = new HttpParams({ fromObject: tarefaParameters });
      this.http
        .get<Tarefa[]>(`${this.API}/BuscarTarefas`, { params })
        .toPromise()
        .then((response) => {
          resolve(response as Tarefa[]);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  
  
}
