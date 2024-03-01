using ListaTarefa.Domain.Entities;
using ListaTarefa.Domain.Enums;
using ListaTarefa.Domain.Interfaces.IRepository;
using ListaTarefa.Domain.Pagination;
using ListaTarefa.Domain.Pagination.Filters;
using ListaTarefa.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ListaTarefa.Infra.Data.Repository
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository
    {
        private readonly AppDbContext _context;
        public TarefaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IList<Tarefa> GetTarefaByStatus(StatusTarefa status)
        {
            try
            {
                if (status <= 0)
                    throw new ArgumentException("O status fornecido é inválido. Certifique-se de que o status seja um valor válido.");
                return _context.Tarefas.Where(x => (x.Status == status)).ToList();
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Ocorreu um erro ao selecionar as tarefas por status: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao selecionar as tarefas por status: " + ex.Message , ex);
            }
        }

        public IList<Tarefa> GetTarefaDiaHoje()
        {
            try
            {
                DateTime hoje = DateTime.Today;
                DateTime amanha = hoje.AddDays(1);

                var tarefasHoje = _context.Tarefas
                    .Where(x => x.DataVencimento >= hoje && x.DataVencimento < amanha)
                    .ToList();

                if (tarefasHoje.Count == 0)
                    throw new Exception("Nenhuma tarefa encontrada para hoje.");

                return tarefasHoje;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao recuperar as tarefas de hoje: " + ex.Message, ex);
            }
        }

        public PagedList<Tarefa> GetTarefas(TarefaFiltro tarefaParameters)
        {
            try
            {
                var tarefa = _context.Tarefas.AsQueryable();
                if (!string.IsNullOrEmpty(tarefaParameters.Status) && Enum.TryParse(tarefaParameters.Status, out StatusTarefa status))
                {
                    tarefa = tarefa.Where(t => t.Status == status);
                }
                if (!string.IsNullOrEmpty(tarefaParameters.Titulo))
                {
                    tarefa = tarefa.Where(t => t.Titulo.Contains(tarefaParameters.Titulo));
                }

                var pagedList = PagedList<Tarefa>.ToPagedList(tarefa.ToList(), tarefaParameters.PageNumber, tarefaParameters.PageSize);
                if (pagedList.Count == 0)
                {
                    throw new Exception("Nenhuma tarefa encontrada.");
                }
                return pagedList;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao buscar as tarefas: " + ex.Message, ex);
            }
        }
    }
}
