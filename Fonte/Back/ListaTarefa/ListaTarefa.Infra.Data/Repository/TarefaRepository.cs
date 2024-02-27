﻿using ListaTarefa.Domain.Entities;
using ListaTarefa.Domain.Enums;
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
    }
}