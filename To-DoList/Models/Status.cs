using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
namespace ToDoList.Models;

[DisplayColumn("Статус")]
public class Status
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Статус")]
    public string? Name { get; set; }

    public virtual List<Problem>? Problem { get; set; }
}
