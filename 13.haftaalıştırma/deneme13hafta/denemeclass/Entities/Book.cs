using System;
using System.Collections.Generic;

namespace denemeclass.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public decimal BookPrice { get; set; }
        public string BookImgUrl { get; set; }
        public DateTime BookCreateDate { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public List<BookAuthor> BookAuthor { get; set; }
        public BookDetail BookDetail { get; set; }



    }

}
