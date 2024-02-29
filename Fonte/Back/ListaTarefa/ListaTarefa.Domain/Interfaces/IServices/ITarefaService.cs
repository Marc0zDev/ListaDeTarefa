using ListaTarefa.Domain.Entities;
using ListaTarefa.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTarefa.Domain.Interfaces.IServices
{
    public interface ITarefaService : IBaseService<Tarefa>
    {
        IList<Tarefa> GetTarefaByStatus(StatusTarefa status);
        IList<Tarefa> GetTarefaDiaHoje();

    }
}
