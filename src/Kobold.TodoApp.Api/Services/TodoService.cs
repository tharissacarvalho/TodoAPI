using System;
using System.Collections.Generic;
using System.Linq;
using Kobold.TodoApp.Api.Models;
using Kobold.TodoApp.Api.Dtos;
using Kobold.TodoApp.Api.Interfaces;

namespace Kobold.TodoApp.Api.Services
{
    public class TodoService : ITodoService
    {
        private static int nextId = 1;
        private static List<Todo> Todos = new List<Todo>();

        public IEnumerable<Todo> Get(IEnumerable<int> todoIds)
        {
            return Todos.Where(x => todoIds.Contains(x.Id)).ToList();
        }

        public IEnumerable<Todo> Get()
        {
            return Todos;
        }

        public ResponseDto Create(TodoViewModel todovm)
        {
            try
            {
                var todo = new Todo { Id = nextId++, DataCriacao = DateTime.Now, Description = todovm.Description, Done = todovm.Done };
                Todos.Add(todo);
                return ResponseDto.Ok("Todo criado com sucesso");
            }
            catch (Exception ex)
            {
                return ResponseDto.InternalServerError($"Ocorreu um erro inesperado,{ex.Message}");
            }
        }

        public ResponseDto Update(int id, TodoViewModel todovm)
        {

            var todo = Todos.FirstOrDefault(todo => todo.Id == id);

            if (todo == null)
            {
                return ResponseDto.NotFoundException($"Todo não encontrado,Id:{id}");
            }

            try
            {
                todo.Done = todovm.Done;
                return ResponseDto.Ok("Todo atualizado com sucesso");
            }

            catch (Exception ex)
            {

                return ResponseDto.InternalServerError($"Ocorreu um erro inesperado,{ex.Message}");
            }
        }

        public ResponseDto Get(int id)
        {
            try
            {
                var todos = Todos.FirstOrDefault(todo => todo.Id == id);

                if (todos == null)
                {
                    return ResponseDto.NotFoundException($"Todo não encontrado,Id:{id}");
                }
                return ResponseDto.Ok(todos);
            }
            catch (Exception ex)
            {

                return ResponseDto.InternalServerError($"Ocorreu um erro inesperado,{ex.Message}");
            }

        }

        public ResponseDto Remove(int id)
        {
            try
            {
                var index = Todos.FindIndex(todo => todo.Id == id);

                if (index > -1)
                {
                    Todos.RemoveAt(index);
                    return ResponseDto.Ok("Todo removido com sucesso");
                }
                else
                {
                    return ResponseDto.NotFoundException($"Todo não encontrado,Id:{id}");
                }

            }
            catch (Exception ex)
            {
                return ResponseDto.InternalServerError($"Ocorreu um erro inesperado,{ex.Message}");
            }

        }
       
    }
}
