using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data;

public class ToDoListContext : DbContext
{
    public ToDoListContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Problem> Problems { get; set; }
    public DbSet<Priority> Priorities { get; set; }
    public DbSet<Status> Statuses { get; set; }
}

