using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomHealth.Models
{
    public class ConnectionDB : DbContext
    {
        public ConnectionDB(DbContextOptions<ConnectionDB> options) : base(options)
        {

        }
        public DbSet<Atom> tblAtom { get; set; }
        public DbSet<Position> tblPosition { get; set; }

    }
}
