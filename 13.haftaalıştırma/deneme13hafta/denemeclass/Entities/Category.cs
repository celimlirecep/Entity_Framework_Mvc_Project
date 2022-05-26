using System.Collections.Generic;

namespace denemeclass.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public List<Book> Books { get; set; }


    }

}
