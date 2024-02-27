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
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        #region Atributtes
        private readonly AppDbContext _context;
        #endregion

        #region Constructor
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public void Delete(int id)
        {
            try
            {
                _context.Set<TEntity>().Remove(SelectById(id));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu algo ao deletar a entidade:", ex);
            }
        }

        public void Insert(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu algo ao inserir a entidade:", ex);
            }
        }

        public IList<TEntity> SelectAll()
        {
            try
            {
                return _context.Set<TEntity>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu algo ao selecionar todas as entidades:", ex);
            }
        }

        public TEntity SelectById(int id)
        {
            try
            {
                return _context.Set<TEntity>().Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu algo ao selecionar a entidade por id:", ex);
            }
        }

        public void Update(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Update(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu algo ao atualizar a entidade:", ex);
            }
        }
        #endregion
    }
}
