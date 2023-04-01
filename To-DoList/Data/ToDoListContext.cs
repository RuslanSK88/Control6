using Microsoft.EntityFrameworkCore;

namespace ToDoList.Data;

public class ToDoListContext : DbContext
{
    public ToDoListContext(DbContextOptions options) : base(options)
    {
    }

}

