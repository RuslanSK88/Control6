using System.ComponentModel.DataAnnotations;
namespace ToDoList.Models;

[DisplayColumn("Приоритет")]
public class Priority
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Приоритет")]
    public string? Name { get; set; }

    public virtual List<Problem>? Problem { get; set; }
}
