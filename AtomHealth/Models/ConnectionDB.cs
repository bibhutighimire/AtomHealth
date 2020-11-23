using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtomHealth.Models;

namespace AtomHealth.Models
{
    public class ConnectionDB : DbContext
    {
        public ConnectionDB(DbContextOptions<ConnectionDB> options) : base(options)
        {

        }
        public DbSet<Atom> tblAtom { get; set; }
        public DbSet<Position> tblPosition { get; set; }
        public DbSet<Employee> tblEmployee { get; set; }
        public DbSet<Subscribe> tblSubscribe { get; set; }
        public DbSet<Admin> tblAdmin { get; set; }
      
      


    }
}
