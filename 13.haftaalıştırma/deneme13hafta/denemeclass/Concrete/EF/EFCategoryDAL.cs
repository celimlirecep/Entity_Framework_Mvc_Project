using denemeclass.Abstract;
using denemeclass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace denemeclass.Concrete.EF
{
    public class EFCategoryDAL:EFBaseRepository<Category>,IEntityRepository<Category>,ICategoryDAL
    {
    }
}
