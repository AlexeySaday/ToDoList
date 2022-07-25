using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSourcer.AuthPer;
using WorkSourcer.Models;

namespace WorkSourcer.Interfaces
{
    public interface IAppData
    {
        IEnumerable<ToDo> GetToDos(string UserId,DateTime date);
        IEnumerable<ToDo> GetWhereNotDone(string UserId,DateTime date);
        void AddToDo(string description, DateTime runTime, string UserId);
        void DeleteToDo(int id);
        void IsDone(int id);
    }
}
