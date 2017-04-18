using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors
        {
            get;
            set;
        }
        public DbSet<Book> Books
        {
            get;
            set;
        }
        public DbSet<Borrow> Borrows
        {
            get;
            set;
        }
        public DbSet<BorrowType> BorrowTypes
        {
            get;
            set;
        }
        public DbSet<Category> Categories
        {
            get;
            set;
        }
        public DbSet<Copy> Copies
        {
            get;
            set;
        }
        public DbSet<Member> Members
        {
            get;
            set;
        }
        public DbSet<Membership> Memberships
        {
            get;
            set;
        }
        public DbSet<Publisher> Publishers
        {
            get;
            set;
        }
        public DbSet<Shelf> Shelves
        {
            get;
            set;
        }
    }
}