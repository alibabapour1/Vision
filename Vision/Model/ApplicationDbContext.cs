using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Vision.Model
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

        // DbContext configuration...

        public ApplicationDbContext(DbContextOptions options):base(options) 
        {
            
        }

       
    }
}