using Microsoft.AspNetCore.Mvc;
using Kobold.TodoApp.Api.Interfaces;
using Kobold.TodoApp.Api.Models.TodoGroup;
using Kobold.TodoApp.Api.Dtos;

namespace Kobold.TodoApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrupoTodoController : Controller
    {
        private readonly IGroupTodoService _groupTodoService;
        public GrupoTodoController(IGroupTodoService groupTodoService)
        {
            _groupTodoService = groupTodoService;
        }

        [HttpPost]
        public ResponseDto Create([FromBody] GroupTodoViewModel groupTodovm)
        {
            var response = _groupTodoService.CreateTodoGroup(groupTodovm);
            return response;
        }

        [HttpGet("{groupId}")]
        public ResponseDto Get([FromRoute] int groupId)
        {
            var response = _groupTodoService.GetTodoGroup(groupId);
            return response;
        }
    }
}
