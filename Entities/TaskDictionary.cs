using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TaskDictionary
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Date {  get; set; }
        public string? Time {  get; set; }
        public bool IsCompleted { get; set; }
    }
}
