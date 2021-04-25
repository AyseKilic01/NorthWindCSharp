using NortWindCSharp.Layouts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortWindCSharp.Entity
{
    public class NWContext : DbContext
    {
        public DbSet<Products> products { get; set; }
    }
}
