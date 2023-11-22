using CASPAR.Infrastructure.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        // By using ReadOnly ApplicationDbContext, you can have access to only
        // querying capabilities of DbContext. UnitOfWork actually writes
        // (commits) to the PHYSICAL tables (not internal object).

        private readonly ApplicationDbContext _dbcontext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public void Add(T entity)
        {
            //string entityName = entity.GetType().Name.ToString();
            //Type entityType = typeof(T);
            //string namespaceName = "CASPAR.Infrastructure.Models";
            //var myObj = Activator.CreateInstance(namespaceName, entityName);

           
            _dbcontext.Set<T>().Add(entity);
            _dbcontext.SaveChanges();
        }

        public void Delete(T entity)
        {   
            _dbcontext.Set<T>().Remove(entity);
            _dbcontext.SaveChanges();
        }

        public void Delete(IEnumerable<T> entities)
        {
            _dbcontext.Set<T>().RemoveRange(entities);
            _dbcontext.SaveChanges();
        }

        // The virtual keyword is used to modify a method, property, indexer, or 
        // and allows for it to be overridden in a derived class.
        public virtual T Get(Expression<Func<T, bool>> predicate, bool trackChanges = false, string? includes = null)
        {
            if (includes == null)
            {
                if (!trackChanges) // if it is false
                {
                    return _dbcontext.Set<T>()
                        .Where(predicate)
                        .AsNoTracking()
                        .FirstOrDefault();
                }
                else
                {
                    return _dbcontext.Set<T>()
                        .Where(predicate)
                        .FirstOrDefault();

                }
            }
            else // includes is present
            {
                //includes = "Comma,separated,objects,without,spaces"
                IQueryable<T> queryable = _dbcontext.Set<T>();
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }

                if (!trackChanges) // if it is false
                {
                    return _dbcontext.Set<T>()
                        .Where(predicate)
                        .AsNoTracking()
                        .FirstOrDefault();
                }
                else
                {
                    return _dbcontext.Set<T>()
                        .Where(predicate)
                        .FirstOrDefault();

                }


            }
        }

        // The virtual keyword is used to modify a method, property, indexer, or 
        // and allows for it to be overridden in a derived class.
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, Expression<Func<T, int>>? orderBy = null, string? includes = null)
        {
            IQueryable<T> queryable = _dbcontext.Set<T>();
            if (predicate != null && includes == null)
            {
                return _dbcontext.Set<T>()
                    .Where(predicate)
                    .AsEnumerable();
            }

            //has includes
            else if (includes != null)
            {
                foreach (var includeProperty in includes.Split(new char[] { ',' },
                      StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }
            }
            if (predicate == null)
            {
                if (orderBy == null)
                {
                    return queryable.AsEnumerable();
                }

                else
                {
                    return queryable.OrderBy(orderBy).ToList();
                }
            }

            else
            {
                if (orderBy == null)
                {
                    return queryable
                        .Where(predicate)
                        .ToList();
                }
                else
                {
                    return queryable
                       .Where(predicate)
                       .OrderBy(orderBy)
                       .ToList();
                }
            }
        }


        // The virtual keyword is used to modify a method, property, indexer, or 
        // and allows for it to be overridden in a derived class.
        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, int>>? orderBy = null, string? includes = null)
        {
            IQueryable<T> queryable = _dbcontext.Set<T>();
            if (predicate != null && includes == null)
            {
                return _dbcontext.Set<T>()
                    .Where(predicate)
                    .AsEnumerable();
            }

            // has includes
            else if (includes != null)
            {
                foreach (var includeProperty in includes.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }
            }

            if (predicate == null)
            {
                if (orderBy == null)
                {
                    return queryable.AsEnumerable();
                }
                else
                {
                    return await queryable.OrderBy(orderBy).ToListAsync();
                }
            }

            else
            {
                if (orderBy == null)
                {
                    return await queryable
                        .Where(predicate)
                        .ToListAsync();
                }
                else
                {
                    return await queryable
                        .Where(predicate)
                        .OrderBy(orderBy)
                        .ToListAsync();
                }
            }
        }


        // The virtual keyword is used to modify a method, property, indexer, or 
        // and allows for it to be overridden in a derived class.
        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool trackChanges = false, string? includes = null)
        {
            if (includes == null) // we are not joining other objects
            {
                if (!trackChanges) //is false
                {
                    return await _dbcontext.Set<T>()
                        .Where(predicate)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();
                }
                else // we are tracking changes (Which EF does by default)
                {
                    return await _dbcontext.Set<T>()
                        .Where(predicate)
                        .FirstOrDefaultAsync();
                }
            }

            else // We have includes to deal with
            {
                //includes = "Comma,Separate,Objects,Without,Spaces"
                IQueryable<T> queryable = _dbcontext.Set<T>();
                foreach (var includeProperty in includes.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }
                if (!trackChanges) //is false
                {
                    return queryable
                        .Where(predicate)
                        .AsNoTracking()
                        .FirstOrDefault();
                }
                else // we are tracking changes (Which EF does by default)
                {
                    return queryable
                        .Where(predicate)
                        .FirstOrDefault();
                }
            }
        }

        // The virtual keyword is used to modify a method, property, indexer, or 
        // and allows for it to be overridden in a derived class.
        public virtual T GetById(int? id)
        {
            return _dbcontext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            // for track changes I'm Flagging modified to the system
            _dbcontext.Entry(entity).State = EntityState.Modified;
            _dbcontext.SaveChanges();
        }
    }
}