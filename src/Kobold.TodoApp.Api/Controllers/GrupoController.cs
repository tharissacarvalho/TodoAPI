using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kobold.TodoApp.Api.Models;
using Kobold.TodoApp.Api.Services;
using Kobold.TodoApp.Api.Interfaces;
using Kobold.TodoApp.Api.Dtos;
using Kobold.TodoApp.Api.Models.Group;

namespace Kobold.TodoApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrupoController : Controller
    {
        private readonly IGroupService _groupService;
        public GrupoController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost]
        public ResponseDto Create([FromBody] GroupViewModel groupvm)
        {
            var response = _groupService.CreateGroup(groupvm);
            return response;
        }

        [HttpGet("{id}")]
        public ResponseDto Get([FromRoute] int id)
        {
            var response = _groupService.GetGroupById(id);
            return response;
        }
    }

}
