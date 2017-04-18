using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class Shelf
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
        public int NumberOfBooks
        {
            get;
            set;
        }
        public ICollection<Shelf> Shelves
        {
            get;
            set;
        }
    }
}