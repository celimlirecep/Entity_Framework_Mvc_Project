using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_2504.DAL.Entities
{
    public class BookAuthor
    {
        public int BookAuthorId { get; set; }
        public int BookId { get; set; }//FK
        public Book Book { get; set; }//navigation proporty
        public int AuthorId { get; set; }//FK
        public Author Author { get; set; }//navigation proporty


    }
}
