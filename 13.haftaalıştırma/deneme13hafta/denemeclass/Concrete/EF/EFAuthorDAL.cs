using denemeclass.Abstract;
using denemeclass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace denemeclass.Concrete.EF
{
    public class EFAuthorDAL:EFBaseRepository<Author>,IEntityRepository<Author>,IAuthorDAL
    {
    }
}
