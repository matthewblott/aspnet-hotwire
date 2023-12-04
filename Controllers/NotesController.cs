using Microsoft.AspNetCore.Mvc;

namespace aspnet_hotwire.MVC.Controllers;

using Data;

public class NotesController : Controller
{
  public IActionResult Index()
  {
    return View();
  }

  public IActionResult Show()
  {
    return View();
  }

  public IActionResult New()
  {
    var note = new Note { Id = 0, Name = String.Empty };
    return View(note);
  }

  public IActionResult Edit(int id)
  {
    var note = Notes.Instance.FirstOrDefault(i => i.Id == id);
    return View(note);
  }
  
  [HttpPost]
  public IActionResult Create(string name)
  {
    var note = new Note { Id = Notes.Instance.Count + 1, Name = name };
    Notes.Instance.Add(note);
    Response.ContentType = "text/vnd.turbo-stream.html";
    return PartialView("_New", note);
  }

  [HttpPut]
  [HttpPost] 
  public IActionResult Update(int id, string name)
  {
    var note = Notes.Instance.FirstOrDefault(i => i.Id == id);
    
    note.Name = name;
    Response.ContentType = "text/vnd.turbo-stream.html";
    return PartialView("_Edit", note);
  }
  
  [HttpDelete]
  [HttpPost] 
  public IActionResult Delete(int id)
  {
    var note = Notes.Instance.FirstOrDefault(i => i.Id == id);
    Notes.Instance.Remove(note);
    Response.ContentType = "text/vnd.turbo-stream.html";
    return PartialView("_Delete", note);
  }
  
}
