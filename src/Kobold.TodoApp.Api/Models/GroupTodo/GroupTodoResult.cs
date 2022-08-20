using System.Collections.Generic;

namespace Kobold.TodoApp.Api.Models.GroupTodo
{
    public class GroupTodoResult
    {
        public object Group { get; set; }
        public IEnumerable<TodoViewModel> Todos { get; set; }
    }
}
