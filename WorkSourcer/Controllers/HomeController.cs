using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims; 
using WorkSourcer.Interfaces;

namespace WorkSourcer.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAppData data;
        public HomeController(IAppData data) { this.data = data; }
        public IActionResult Index(bool flag)
        {
            if(flag) 
                return View(data.GetWhereNotDone(User.FindFirstValue(ClaimTypes.NameIdentifier),DateTime.Now)); 
            return View(data.GetToDos(User.FindFirstValue(ClaimTypes.NameIdentifier),DateTime.Now)); 
        }
        public IActionResult Add() => View();
        public IActionResult GetDataFromView(string description,string date,string time)
        {
            string datetime = date + "T" + time;
            data.AddToDo(description, Convert.ToDateTime(datetime), User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Redirect("~/");
        }
        public IActionResult IsDone(int Id)
        {
            data.IsDone(Id);
            return Redirect("~/"); 
        }
        public IActionResult Delete(int Id)
        {
            data.DeleteToDo(Id); 
            return Redirect("~/");
        }
        [HttpGet]
        public IActionResult Calender()
        {
            return View(null);
        }
        [HttpPost]
        public IActionResult Calender(string datetime)
        {
            return View(data.GetToDos(User.FindFirstValue(ClaimTypes.NameIdentifier), Convert.ToDateTime(datetime)));
        }
    }
}
