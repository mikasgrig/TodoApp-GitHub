using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.Repositories;
using TodosRestAPI;
using Models.ResponseModels;
using Models.RequestModels;
using TodosRestAPI.Models.RequestModels;
using Persistence.Models;

namespace Persistence.Controllers
{
    public class TodosAppController : ControllerBase
    {
        private readonly ITodosRepository _todosRepository;
        public TodosAppController(ITodosRepository todosRepository)
        {
            _todosRepository = todosRepository;
        }
        [HttpGet]
        [Route("todos")]
        public async Task<IEnumerable<TodoItem>> GetTodos()
        {

            var comment = await _todosRepository.GetAll<TodoItem>();
            
            return comment;
        }
        [HttpGet]
        [Route("todos/{id}")]
        public async Task<ActionResult<TodoItem>> GetTodo(Guid id)
        {
            var todo = await _todosRepository.GetAsync(id);
            if (todo is null)
            {
                return NotFound();
            }

            return Ok(todo);
        }
        [HttpPost]
        [Route("todos")]
        public async Task<ActionResult<TodoResponse>> AddCommentAsync(AddTodoReqest reqest)
        {
            var todo = new TodoItem
            {
                Id = Guid.NewGuid(),
                Description = reqest.Description,
                Title = reqest.Title,
                Difficulty = reqest.Difficulty,
                DateCreated = DateTime.Now,
                Done = false
            };
            await _todosRepository.AddTodo(todo);
            return CreatedAtAction("GetTodo", new { id = todo.Id }, todo.MapTodoToResponse());
        }
        [HttpPut]
        [Route("todos/{todosId}")]
        public async Task<ActionResult<TodoResponse>> UpdateTodoAsync(Guid todosId, UptadeTodoItem todo)
        {
            if (todo is null)
            {
                return BadRequest();
            }
            var todoUptade = await _todosRepository.GetAsync(todosId);
            if (todoUptade is null)
            {
                return NotFound();
            }
            await _todosRepository.Update(todosId, todo);
            var todoNewUpdate = await _todosRepository.GetAsync(todosId);
            return Ok(todoNewUpdate.MapTodoToResponse());
        }
        [HttpDelete]
        [Route("todos/{todosId}")]
        public async Task<ActionResult<TodoResponse>> DeleteTodoAsync(Guid todosId)
        {
            var todoDelete = await _todosRepository.GetAsync(todosId);
            if (todoDelete is null)
            {
                return NotFound();
            }
            await _todosRepository.Delete(todosId);
            return NoContent();
        }

    }
}

