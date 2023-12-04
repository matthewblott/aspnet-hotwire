using Microsoft.AspNetCore.Mvc;

namespace aspnet_hotwire.MVC.Controllers;

using Data;
using Hubs;
using Microsoft.AspNetCore.SignalR;
using Services;

public class TodosController : Controller
{
  private readonly IHubContext<AppHub> _hub;
  private readonly IRazorPartialToStringRenderer _renderer; 
  
  public TodosController(IHubContext<AppHub> hub, IRazorPartialToStringRenderer renderer) 
  {
    _hub = hub;
    _renderer = renderer;
  } 
  
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
    var note = new Todo { Id = 0, Name = String.Empty };
    return View(note);
  }

  public IActionResult Edit(int id)
  {
    var note = Todos.Instance.FirstOrDefault(i => i.Id == id);
    return View(note);
  }

  [HttpPost]
  public async Task<IActionResult> Create(string name)
  {
    var note = new Todo { Id = Todos.Instance.Count + 1, Name = name };
    Todos.Instance.Add(note);
    
    var renderedViewStr = await _renderer.RenderPartialToStringAsync("../Todos/_New", note);

    await _hub.Clients.All.SendAsync("TodosChanged", renderedViewStr);

    return new EmptyResult(); 
  }

  [HttpPut]
  [HttpPost]
  public async Task<IActionResult> Update(int id, string name)
  {
    var note = Todos.Instance.FirstOrDefault(i => i.Id == id);

    note.Name = name;
    var renderedViewStr = await _renderer.RenderPartialToStringAsync("../Todos/_Edit", note);

    await _hub.Clients.All.SendAsync("TodosChanged", renderedViewStr);

    return new EmptyResult(); 
  }

  [HttpDelete]
  [HttpPost]
  public async Task<IActionResult> Delete(int id)
  {
    var note = Todos.Instance.FirstOrDefault(i => i.Id == id);
    Todos.Instance.Remove(note);
    var renderedViewStr = await _renderer.RenderPartialToStringAsync("../Todos/_Delete", note);
    await _hub.Clients.All.SendAsync("TodosChanged", renderedViewStr);
    return new EmptyResult(); 
  }

}
