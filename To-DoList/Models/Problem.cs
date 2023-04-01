using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models;

[DisplayColumn("Задача")]
public class Problem
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Название Задачи")]
    public string? Name { get; set; }

    [Required]
    [Display(Name = "Описание")]
    public string? Description { get; set; }

    public int PriorityId { get; set; }
    public virtual Priority? Priority { get; set; }

    public int StatusId { get; set; }
    public virtual Status? Status { get; set; }
}
