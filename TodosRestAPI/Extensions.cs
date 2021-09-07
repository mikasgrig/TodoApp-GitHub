using Models.ResponseModels;
using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodosRestAPI
{
    public static class Extensions
    {
        public static TodoResponse MapTodoToResponse(this TodoItem todo)
        {
            return new TodoResponse
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                Difficulty = todo.Difficulty,
                DateCreated = todo.DateCreated
            };
        }
    }
}
