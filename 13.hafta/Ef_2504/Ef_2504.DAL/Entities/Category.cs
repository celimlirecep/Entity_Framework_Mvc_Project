using System.Collections.Generic;


namespace Ef_2504.DAL.Entities
{
    public  class Category
    {
        public int CategoryId { get; set; }
        public string Categoryname { get; set; }
        public string CategoryDescription { get; set; }
        public List<Book> Books { get; set; }



    }
}
