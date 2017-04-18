using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public DateTime YearOfPublication
        {
            get;
            set;
        }
        public int Isbn
        {
            get;
            set;
        } 
        public int PublisherId
        {
            get;
            set;
        }
        public virtual Publisher Publisher
        {
            get;
            set;
        }
        public string Details
        {
            get;
            set;
        }
        public double Penalty
        {
            get;
            set;
        }
        public virtual ICollection<Author> Authors
        {
            get;
            set;
        }
        public virtual ICollection<Category> Categories
        {
            get;
            set;
        }
        public virtual ICollection<Copy> Copies
        {
            get;
            set;
        }
    }
}