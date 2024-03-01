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
                    throw new Exception("Status inválido");
                return _context.Tarefas.Where(x => (x.Status == status)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu algo ao selecionar todas as entidades:", ex);
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
                throw new Exception("Ocorreu algo ao selecionar todas as entidades:", ex);
            }
        }

        public PagedList<Tarefa> GetTarefas(TarefaFiltro tarefaParameters)
        {
            try
            {
                var tarefa = _context.Tarefas.AsQueryable();
                if (!string.IsNullOrEmpty(tarefaParameters.Status))
                {
                    if (Enum.TryParse(tarefaParameters.Status, out StatusTarefa status))
                    {
                        
                        tarefa = tarefa.Where(t => t.Status == status);
                    }
                }
                if (!string.IsNullOrEmpty(tarefaParameters.Titulo))
                {
                    tarefa = tarefa.Where(t => t.Titulo.Contains(tarefaParameters.Titulo));
                }
                if(tarefa == null) { throw new Exception("Nenhuma tarefa encontrada.");}

                var pagedList = PagedList<Tarefa>.ToPagedList(tarefa.ToList(), tarefaParameters.PageNumber, tarefaParameters.PageSize);
                return pagedList;
            }
            catch(Exception ex)
            {
                throw new Exception("Ocorreu algo ao selecionar todas as entidades:", ex);
            }
        }
    }
}
