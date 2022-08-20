using Kobold.TodoApp.Api.Dtos;
using Kobold.TodoApp.Api.Interfaces;
using Kobold.TodoApp.Api.Models;
using Kobold.TodoApp.Api.Models.GroupTodo;
using Kobold.TodoApp.Api.Models.TodoGroup;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kobold.TodoApp.Api.Services
{
    public class GroupTodoService : IGroupTodoService
    {
        private static List<GroupTodo> GroupTodo = new List<GroupTodo>();
        private readonly ITodoService _todoService;
        private readonly IGroupService _groupService;
        public GroupTodoService(ITodoService todoService, IGroupService groupService)
        {
            _todoService = todoService;
            _groupService = groupService;
        }
        public ResponseDto CreateTodoGroup(GroupTodoViewModel groupTodovm)
        {
            try
            {
                var groupTodo = new GroupTodo
                {
                    TodoId = groupTodovm.TodoId,
                    GroupId = groupTodovm.GroupId
                };

                GroupTodo.Add(groupTodo);
                return ResponseDto.Ok("Grupo criado com sucesso");

            }
            catch (Exception ex)
            {
                return ResponseDto.InternalServerError($"Ocorreu um erro inesperado '{ex.Message}'");
            }
        }

        public ResponseDto GetTodoGroup(int groupId)
        {
            try
            {
                var group = _groupService.GetGroupById(groupId).Response;

                if (group != null)
                {
                    var todoIds = GroupTodo.Where(x => x.GroupId == groupId).Select(x => x.TodoId);

                    var todos = _todoService.Get(todoIds);

                    var todoGroup = new GroupTodoResult
                    {
                        Group = group,
                        Todos = todos.Select(y => new TodoViewModel
                        {
                            Done = y.Done,
                            Description = y.Description
                        })
                    };

                    return ResponseDto.Ok(todoGroup);
                }
                
                return ResponseDto.NotFoundException($"Grupo não encontrado,Id:{groupId}");
            }
            catch (Exception ex)
            {
                return ResponseDto.InternalServerError($"Ocorreu um erro inesperado '{ex.Message}'");
            }
        }
    }
}
