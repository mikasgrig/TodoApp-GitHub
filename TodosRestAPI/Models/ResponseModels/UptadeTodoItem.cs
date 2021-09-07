using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class UptadeTodoItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
