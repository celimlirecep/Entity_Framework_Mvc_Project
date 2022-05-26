using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ef_2504.DAL.Abstract
{
    public interface IEntityRepository<T> where T:class
    {
        void Add(T entity);//(C)reate
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //(R)ead
        T Get(Expression<Func<T, bool>> filter );//Tek kayıt Read
        void Update(T entity);//(U)pdate
        void Delete(T entity);//(D)elete

    }
}
