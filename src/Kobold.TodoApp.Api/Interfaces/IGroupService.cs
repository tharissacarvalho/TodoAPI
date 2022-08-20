using Kobold.TodoApp.Api.Dtos;
using Kobold.TodoApp.Api.Models.Group;

namespace Kobold.TodoApp.Api.Interfaces
{
    public interface IGroupService
    {
        ResponseDto CreateGroup(GroupViewModel groupvm);
        ResponseDto GetGroupById(int id);
    }
}
