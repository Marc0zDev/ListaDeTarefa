using ListaTarefa.Domain.Entities;
using ListaTarefa.Domain.Interfaces.IRepository;
using ListaTarefa.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTarefa.Infra.Data.Repository
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(AppDbContext context) : base(context)
        {

        }
    }
}
