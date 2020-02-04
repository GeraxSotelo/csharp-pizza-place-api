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

    internal Pizza Create(Pizza newData)
    {
      _repo.Create(newData);
      return newData;
    }
  }
}