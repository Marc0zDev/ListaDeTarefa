using FluentValidation;
using ListaTarefa.Domain.Entities;
using ListaTarefa.Domain.Interfaces.IRepository;
using ListaTarefa.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTarefa.Service.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> Repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            try
            {
                if (obj == null)
                    throw new Exception($"'{typeof(TEntity).FullName}' não pode ser nulo.");
                Validate(obj, Activator.CreateInstance<TValidator>());
                Repository.Insert(obj);
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu algo ao inserir a entidade:", ex);
            }
        }
        public void Delete(int id)
        {
            try
            {
                if (id == 0 || id < 0)
                    throw new Exception("Id invalido");
                Repository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu algo ao deletar a entidade:", ex);
            }
        }

        public IList<TEntity> GetAll()
        {
            try
            {
                return Repository.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu algo ao selecionar todas as entidades:", ex);
            }
        }

        public TEntity GetById(int id)
        {
            try
            {
                return Repository.SelectById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu algo ao selecionar a entidade:", ex);
            }
        }

        public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            if (obj == null)
                throw new Exception($"'{typeof(TEntity).FullName}' não pode ser nulo.");
            Validate(obj, Activator.CreateInstance<TValidator>());
            Repository.Update(obj);
            return obj;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
