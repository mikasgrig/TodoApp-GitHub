using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodosRestAPI.Models.RequestModels
{
    public class TodoItemRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Difficulty Difficulty { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Done { get; set; }
    }
}
