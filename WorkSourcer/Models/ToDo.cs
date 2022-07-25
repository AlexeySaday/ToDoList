using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSourcer.AuthPer;

namespace WorkSourcer.Models
{
    public class ToDo : IComparable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime RunTime { get; set; }
        public string UserId { get; set; }
        public int CompareTo(object obj)
        {
            ToDo toDo = (ToDo)obj;
            if (toDo.RunTime < this.RunTime) return 1;
            else if (toDo.RunTime > this.RunTime) return -1;
            else return 0;
        }
    }
}
