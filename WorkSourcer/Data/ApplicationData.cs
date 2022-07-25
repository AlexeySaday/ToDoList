using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSourcer.AuthPer;
using WorkSourcer.DataContext;
using WorkSourcer.Interfaces;
using WorkSourcer.Models;

namespace WorkSourcer.Data
{
    public class ApplicationData : IAppData 
    {
        private readonly ApplicationDbContext context;
        public ApplicationData(ApplicationDbContext context) 
        {
            this.context = context;
            foreach (var e in context.toDo) if (e.RunTime.Date < DateTime.Now.Date) context.toDo.Remove(e);
            context.SaveChanges();
        }
        public IEnumerable<ToDo> GetToDos(string UserId,DateTime date)
        {
            List<ToDo> toDos = new List<ToDo>();
            foreach (var e in context.toDo) if (e.UserId == UserId && e.RunTime.Date==date.Date) toDos.Add(e);
            toDos.Sort();
            return toDos;
        }
        public IEnumerable<ToDo> GetWhereNotDone(string UserId,DateTime date)
        {
            List<ToDo> toDos = new List<ToDo>();
            foreach (var e in context.toDo) if (e.RunTime.Date==date.Date && e.UserId == UserId && !e.IsDone && e.RunTime>DateTime.Now) toDos.Add(e);
            toDos.Sort();
            return toDos;
        }
        public void AddToDo(string description, DateTime runTime, string UserId)
        {
            context.Add(new ToDo() { IsDone = false, RunTime = runTime, UserId = UserId, Description = description });
            context.SaveChanges();
        }
        public void DeleteToDo(int id)
        {
            context.toDo.Remove(context.toDo.FirstOrDefault(e => e.Id == id));
            context.SaveChanges();
        }
        public void IsDone(int id)
        {
            context.toDo.FirstOrDefault(e => e.Id == id).IsDone = true;
            context.SaveChanges();
        }
        
    }
}
