using denemeclass.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace denemeclass.Concrete.EF
{
    public class EFBaseRepository<T> : IEntityRepository<T> where T:class
    {
        public void Add(T entity)
        {
            using (var _context=new DenemeContext() )
            {
                _context.Entry(entity).State = EntityState.Added;
                _context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var _context=new DenemeContext())
            {
                _context.Entry(entity).State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (var _context=new DenemeContext())
            {
                return _context.Set<T>().SingleOrDefault(filter);
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var _context=new DenemeContext())
            {
                return filter == null ?
                    _context.Set<T>().ToList() :
                    _context.Set<T>().Where(filter).ToList();
            }
        }

        public void Update(T entity)
        {
            using (var _context=new DenemeContext())
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }

}
