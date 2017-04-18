using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class Borrow
    {
        public int Id
        {
            get;
            set;
        }
        public int CopyId
        {
            get;
            set;
        }
        public virtual Copy Copy
        {
            get;
            set;
        }
        public int MemberId
        {
            get;
            set;
        }
        public virtual Member Member
        {
            get; set;
        }
        public DateTime BorrowDate
        {
            get;
            set;
        }
        public DateTime ReturnDate
        {
            get;
            set;
        }
        public int Penalty
        {
            get;
            set;
        }
        public int BorrowTypeId

        {
            get;
            set;
        }
        public virtual BorrowType BorrowType

        {
            get;
            set;
        }
    }
}