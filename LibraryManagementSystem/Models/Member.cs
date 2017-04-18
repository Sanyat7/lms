using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class Member
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
        public DateTime DateOfBirth
        {
            get;
            set;
        }

        public String Sex
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        public int Mobile
        {
            get;
            set;
        }
        public int MembershipId
        {
            get;
            set;
        }
        public virtual Membership Membership
        {
            get;
            set;
        }

        public ICollection<Borrow> borrows
        {
            get;
            set;
        }
    }
}