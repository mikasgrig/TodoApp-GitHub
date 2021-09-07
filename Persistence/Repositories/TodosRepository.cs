using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class TodosRepository : ITodosRepository
    {
        private readonly ISqlClient _sqlClient;
        private readonly string TableName;
        public TodosRepository(ISqlClient sqlClient)
        {
            _sqlClient = sqlClient;
            TableName = "todos";
        }
        public Task<int> AddTodo(TodoItem todo)
        {
            var sql = $"INSERT INTO {TableName} (Id, Title, Description, Difficulty, DateCreated, Done)  VALUES  (@Id, @Title, @Description, @Difficulty, @DateCreated, @Done)";
            return _sqlClient.ExecuteAsync(sql, new 
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                Difficulty = todo.Difficulty.ToString(),
                DateCreated = todo.DateCreated,
                Done = todo.Done
            });
        }

        public  Task<int> Delete(Guid id)
        {
            var sql = $"DELETE FROM {TableName} WHERE Id = @id";
            
            return _sqlClient.ExecuteAsync(sql, new { id });
        }

        public async Task<TodoItem> GetAsync(Guid Id)
        {
            var sql = $"SELECT * FROM {TableName} WHERE Id = @Id";
            var todoGet = await _sqlClient.QueryAsync<TodoItem>(sql, new { Id });
            
            return todoGet.FirstOrDefault(todo => todo.Id == Id);
        }

        public Task<IEnumerable<T>> GetAll<T>()
        {
            var sql = @$"SELECT * FROM {TableName}";
            return _sqlClient.QueryAsync<T>(sql);
        }

        public Task<int> Update(Guid Id, UptadeTodoItem item)
        {
            var sql = $"UPDATE {TableName} SET Title = @Title, Description = @Description, Difficulty = @Difficulty WHERE Id = @Id";
            var parametr = new { item.Title, item.Description, Difficulty = item.Difficulty.ToString(), Id };
            return _sqlClient.ExecuteAsync(sql, parametr);
        }
    }
}
