using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharp_pizza_place_api.Models;
using csharp_pizza_place_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace csharp_pizza_place_api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PizzasController : ControllerBase
  {
    private readonly PizzasService _ps;
    public PizzasController(PizzasService ps)
    {
      _ps = ps;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Pizza>> GetAll()
    {
      try
      {
        return Ok(_ps.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Pizza> GetById(int id)
    {
      try
      {
        return Ok(_ps.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Pizza> Create([FromBody] Pizza newData)
    {
      try
      {
        return Ok(_ps.Create(newData));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Pizza> Edit([FromBody] Pizza update, int id)
    {
      try
      {
        update.Id = id;
        return Ok(_ps.Edit(update));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        return Ok(_ps.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}