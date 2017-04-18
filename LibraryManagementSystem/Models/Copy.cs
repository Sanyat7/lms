using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class Copy
    {
        public int Id
        {
            get;
            set;
        }
        public int BookId
        {
            get;
            set;
        }
        public virtual Book Book
        {
            get;
            set;
        }
        public int CopyNumber
        {
            get;
            set;
        }
        public int ShelfId
        {
            get;
            set;
        }
        public virtual Shelf Shelf
        {
            get;
            set;
        }
        public Boolean Available
        {
            get;
            set;
        }
        public virtual ICollection<Borrow> Borrows
        {
            get;
            set;
        }
    }
}