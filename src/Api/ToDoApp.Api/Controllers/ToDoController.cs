using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Contracts.DataServices.ToDoServices;
using ToDoApp.Application.Dto;

namespace ToDoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        private readonly IMapper _mapper;

        public ToDoController(IToDoService toDoService, IMapper mapper)
        {
            _toDoService = toDoService;
            _mapper = mapper;
        }

        [HttpGet("GetAllToDoItems")]
        public async Task<ActionResult<ToDoItemDto>> Get() 
        {
            var response = await _toDoService.GetAllToDoItems();

            if (response == null)
                return NotFound();
            return Ok(response);
        }
    }
}
