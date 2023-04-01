using ToDoList.Models;
namespace ToDoList.ViewModels;


public class IndexViewModel
{
    public virtual List<Problem>? Problem { get; set; }
    public virtual List<Priority>? Priority { get; set; }
    public virtual List<Status>? Status { get; set; }

}