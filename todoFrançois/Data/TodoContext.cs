using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todoFrançois.Models;

namespace todoFrançois.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext (DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<todoFrançois.Models.TodoTask> TodoTask { get; set; } = default!;
    }
}
