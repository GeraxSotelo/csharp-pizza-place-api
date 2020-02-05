using System;
using System.Collections.Generic;
using csharp_pizza_place_api.Models;
using csharp_pizza_place_api.Repositories;

namespace csharp_pizza_place_api.Services
{
  public class PizzasService
  {
    private readonly PizzasRepository _repo;
    public PizzasService(PizzasRepository pr)
    {
      _repo = pr;
    }
    internal IEnumerable<Pizza> GetAll()
    {
      return _repo.GetAll();
    }
    internal Pizza GetById(int id)
    {
      var found = _repo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal Pizza Create(Pizza newData)
    {
      _repo.Create(newData);
      return newData;
    }

    internal Pizza Edit(Pizza update)
    {
      var found = _repo.GetById(update.Id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Edit(update);
      return update;
    }

    internal String Delete(int id)
    {
      var found = _repo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}