using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;


namespace Care.Data
{
    public class BaseRepository<T> : IDisposable where T: class
    {
        private CareDbContext context;

        public BaseRepository() => context = new CareDbContext();

        public T GetOne(int id)
        {
            return context.Set<T>().Find(id);
        }

        public Task<T> GetOneAsync(int id)
        {
            return context.Set<T>().FindAsync(id);
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public Task<List<T>> GetAllAsync()
        {
            return context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            foreach(T item in context.Set<T>())
            {
                if (predicate(item))
                    yield return item;
            }            
        }
       
        public  int Add(T entity)
        {
            context.Set<T>().Add(entity);
            return SaveChanges();
        }

        public Task<int> AddAsync(T entity)
        {
            context.Set<T>().Add(entity);
            return SaveChangesAsync();
        }
  
        public int Save(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }
        public Task<int> SaveAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return SaveChangesAsync();
        }
        public int Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }
        public Task<int> DeleteAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            return SaveChangesAsync();
        }

        public int Delete(Func<T, bool> predicate)
        {
            foreach (T item in context.Set<T>())
            {
                if(predicate(item))
                context.Entry(item).State = EntityState.Deleted;
            }
            return SaveChanges();
        }

        public int SaveChanges()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (CommitFailedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal async Task<int> SaveChangesAsync()
        {
            try
            {
                return await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (CommitFailedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                context.Dispose();
            }
            disposed = true;
        }
    }
}
