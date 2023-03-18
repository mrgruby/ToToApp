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

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
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
