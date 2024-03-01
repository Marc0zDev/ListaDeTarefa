﻿using AutoMapper;
using ListaTarefa.Domain.DTOs;
using ListaTarefa.Domain.Entities;
using ListaTarefa.Domain.Enums;
using ListaTarefa.Domain.Interfaces.IRepository;
using ListaTarefa.Domain.Interfaces.IServices;
using ListaTarefa.Domain.Pagination.Filters;


using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ListaTarefa.Service.Service
{
    public class TarefaService : BaseService<Tarefa>, ITarefaService
    {
        private readonly ITarefaRepository Repository;
        private readonly IMapper _mapper;

        public TarefaService(IBaseRepository<Tarefa> repository, ITarefaRepository tarefa, IMapper mapper) : base(repository)
        {
            Repository = tarefa;
            _mapper = mapper;
        }

        public IList<TarefaDTO> GetTarefaByStatus(StatusTarefa status)
        {
            try
            {
                var listaTarefas = Repository.GetTarefaByStatus(status);
                var listaTarefasDTO = _mapper.Map<IList<TarefaDTO>>(listaTarefas);
                if (listaTarefas == null)
                    throw new Exception("Nenhuma tarefa encontrada");

                return listaTarefasDTO;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }

        public IList<TarefaDTO> GetTarefaDiaHoje()
        {
            try
            {
                var listaHoje = Repository.GetTarefaDiaHoje().ToList();
                
                foreach (var tarefa in listaHoje)
                { 

                    var formato = tarefa.DataVencimento.ToString("dd/MM/yyyy");
                    tarefa.DataVencimento = Convert.ToDateTime(formato);
                }
                var listaTarefasDTO = _mapper.Map<IList<TarefaDTO>>(listaHoje);
                return listaTarefasDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        Domain.Pagination.PagedList<Tarefa> ITarefaService.GetTarefas(TarefaFiltro tarefaParameters)
        {
            try
            {
                var tarefas = Repository.GetTarefas(tarefaParameters);
                

                if (tarefas == null)
                    throw new Exception("Nenhuma tarefa encontrada");



                return tarefas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
