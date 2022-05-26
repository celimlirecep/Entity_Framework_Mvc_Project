using Ef_2504.DAL.Abstract;
using Ef_2504.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_2504.DAL.Concrete.EF
{
    public class EFBookDetailDAL:EFBaseRepository<BookDetail>,IEntityRepository<BookDetail>,IBookDetailDAL
    {
    }
}
