using Kobold.TodoApp.Api.Dtos;
using Kobold.TodoApp.Api.Models;
using System.Collections.Generic;

namespace Kobold.TodoApp.Api.Interfaces
{
    public interface ITodoService
    {
        IEnumerable<Todo> Get(IEnumerable<int> todoIds);
        IEnumerable<Todo> Get();
        ResponseDto Create(TodoViewModel todovm);
        ResponseDto Update(int id, TodoViewModel todovm);
        ResponseDto Get(int id);
        ResponseDto Remove(int id);
    }
}
