using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class Membership
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
        public int MaxBooks
        {
            get;
            set;
        }
        public ICollection<Member> Members
        {
            get; set;
        }
    }
}