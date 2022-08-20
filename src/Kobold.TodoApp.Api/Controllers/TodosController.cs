using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kobold.TodoApp.Api.Models;
using Kobold.TodoApp.Api.Interfaces;
using Kobold.TodoApp.Api.Dtos;

namespace Kobold.TodoApp.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly ILogger<TodosController> _logger;

        public TodosController(ILogger<TodosController> logger, ITodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return _todoService.Get();
        }

        [HttpPost]
        public ResponseDto Create([FromBody] TodoViewModel todovm)
        {
            var response = _todoService.Create(todovm);
            return response;
        }

        [HttpPut("{id}")]
        public ResponseDto Update([FromRoute] int id, [FromBody] TodoViewModel todovm)
        {
            var response = _todoService.Update(id, todovm);
            return response;
        }

        [HttpGet("{id}")]
        public ResponseDto Get([FromRoute] int id)
        {
            var response = _todoService.Get(id);
            return response;
        }


        [HttpDelete("{id}")]
        public ResponseDto Remove([FromRoute] int id)
        {
            var response = _todoService.Remove(id);
            return response;
        }
    }
}
