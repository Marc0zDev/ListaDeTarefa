using ListaTarefa.Domain.Entities;
using ListaTarefa.Domain.Enums;
using ListaTarefa.Domain.Pagination;
using ListaTarefa.Domain.Pagination.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ListaTarefa.Domain.Interfaces.IRepository
{
    public interface ITarefaRepository : IBaseRepository<Tarefa>
    {
        IList<Tarefa> GetTarefaByStatus(StatusTarefa status);
        IList<Tarefa> GetTarefaDiaHoje();
        PagedList<Tarefa> GetTarefas(TarefaFiltro tarefaParameters);
          
    }
}
