using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public interface ITodosRepository
    {
        public Task<IEnumerable<T>> GetAll<T>();
        public Task<TodoItem> GetAsync(Guid id);
        public Task<int> AddTodo(TodoItem todo);
        public Task<int> Update(Guid id, UptadeTodoItem item);
        public Task<int> Delete(Guid id);
    }
}
