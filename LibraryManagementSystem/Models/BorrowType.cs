using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class BorrowType
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
        public int Period
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