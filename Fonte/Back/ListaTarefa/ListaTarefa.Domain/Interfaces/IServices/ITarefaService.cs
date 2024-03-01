using ListaTarefa.Domain.DTOs;
using ListaTarefa.Domain.Entities;
using ListaTarefa.Domain.Enums;
using ListaTarefa.Domain.Pagination;
using ListaTarefa.Domain.Pagination.Filters;
using ListaTarefa.Domain.Pagination.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTarefa.Domain.Interfaces.IServices
{
    public interface ITarefaService : IBaseService<Tarefa>
    {
        IList<TarefaDTO> GetTarefaByStatus(StatusTarefa status);
        IList<TarefaDTO> GetTarefaDiaHoje();
        TarefaPageMessage GetTarefas(TarefaFiltro tarefaParameters);
    }
}
