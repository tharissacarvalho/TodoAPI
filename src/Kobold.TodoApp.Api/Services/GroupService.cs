using Kobold.TodoApp.Api.Dtos;
using Kobold.TodoApp.Api.Interfaces;
using Kobold.TodoApp.Api.Models.Group;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kobold.TodoApp.Api.Services
{
    public class GroupService : IGroupService
    {
        private static int nextId = 1;
        private static List<Group> Group = new List<Group>();
        public ResponseDto CreateGroup(GroupViewModel groupvm)
        {
            try
            {
                var group = new Group
                {
                    Id = nextId++,
                    Name = groupvm.Name
                };

                Group.Add(group);

                return ResponseDto.Ok("Grupo criado com sucesso");
            }
            catch (Exception ex)
            {
                return ResponseDto.InternalServerError($"Ocorreu um erro inesperado '{ex.Message}'");
            }
        }

        public ResponseDto GetGroupById(int id)
        {
            try
            {
                var group = Group.FirstOrDefault(x => x.Id == id);

                if (group != null)
                {
                    return ResponseDto.Ok(group);
                   
                }

                return ResponseDto.NotFoundException($"Grupo não encontrado,Id:{id}");
            }
            catch (Exception ex)
            {
                return ResponseDto.InternalServerError($"Ocorreu um erro inesperado,{ex.Message}");
            }
        }
    }
}
