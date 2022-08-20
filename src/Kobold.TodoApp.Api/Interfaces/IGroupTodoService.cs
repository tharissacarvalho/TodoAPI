using Kobold.TodoApp.Api.Dtos;
using Kobold.TodoApp.Api.Models.TodoGroup;

namespace Kobold.TodoApp.Api.Interfaces
{
    public interface IGroupTodoService
    {
        ResponseDto CreateTodoGroup(GroupTodoViewModel groupTodovm);
        ResponseDto GetTodoGroup(int groupId);
    }
}
