using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace denemeclass.Abstract
{
    public interface IEntityRepository<T> where T:class
    {
        //C
        void Add(T entity);

        //R
        List<T> GetAll(Expression<Func<T, bool>> filter = null);//nullable bazen sadece ismi şuolanları döndür diyebilirim

        T Get(Expression<Func<T, bool>> filter);//tek bitane veri döndrücek

        //U
        void Update(T entity);

        //D
        void Delete(T entity);

        
    }
        
}
