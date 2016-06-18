using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PhBE
{
    public class PhBContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
