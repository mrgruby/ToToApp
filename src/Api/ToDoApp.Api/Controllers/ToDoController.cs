using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using ToDoApp.Application.Contracts.DataServices.ToDoServices;
using ToDoApp.Application.Dto;
using ToDoApp.Application.Responses;
using ToDoApp.Domain.Entities;

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
        public async Task<ActionResult<List<ToDoItemDto>>> Get() 
        {
            var response = await _toDoService.GetAllToDoItems();

            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetToDoItemById")]
        public async Task<ActionResult<ToDoItemDto>> Get(int id)
        {
            var response = await _toDoService.GetToDoItem(id);

            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItemDto>> Post(ToDoItemDto toDoItem)
        {
            var response = await _toDoService.CreateToDoItem(toDoItem);

            if (response.Data != null && response.Success)
                return CreatedAtRoute("GetToDoItemById", new { id = response.Data.ToDoItemId}, response.Data);
            else
                return BadRequest($"Failed to save ToDoItem");
        }

        [HttpPut]
        public async Task<ActionResult> Put(ToDoItemDto toDoItem)
        {
            var response = await _toDoService.UpdateToDoItem(toDoItem);

            if (!response.Success)
                return BadRequest($"{response.Message}");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _toDoService.DeleteToDoItem(id);

            if (!response.Success)
                return BadRequest($"{response.Message}");
            return NoContent();

        }
    }
}
