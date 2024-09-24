using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ETSContext : DbContext
    {
        public ETSContext(DbContextOptions<ETSContext> options) : base(options)
        {

        }
        public DbSet<UserDetails> tb_userDetails { get; set; }
    }
}
