using ListaTarefa.Domain.Entities;
using ListaTarefa.Domain.Enums;
using ListaTarefa.Domain.Interfaces.IRepository;
using ListaTarefa.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTarefa.Service.Service
{
    public class TarefaService : BaseService<Tarefa>, ITarefaService
    {
        private readonly ITarefaRepository Repository;
        public TarefaService(IBaseRepository<Tarefa> repository, ITarefaRepository tarefa) : base(repository)
        {
            Repository = tarefa;
        }

        public IList<Tarefa> GetTarefaByStatus(StatusTarefa status)
        {
            var listaTarefas = Repository.GetTarefaByStatus(status);

            if (listaTarefas == null)
                throw new Exception("Nenhuma tarefa encontrada");

            return listaTarefas;
        }

        public IList<Tarefa> GetTarefaDiaHoje()
        {
            try
            {
                var listaHoje = Repository.GetTarefaDiaHoje().ToList();

                foreach (var tarefa in listaHoje)
                { 

                    var formato = tarefa.DataVencimento.ToString("dd/MM/yyyy");
                    tarefa.DataVencimento = Convert.ToDateTime(formato);
                }

                return listaHoje;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu algo ao selecionar todas as entidades:", ex);
            }
        }
    }
}
