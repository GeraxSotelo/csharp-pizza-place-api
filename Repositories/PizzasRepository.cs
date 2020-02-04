using System;
using System.Collections.Generic;
using System.Data;
using csharp_pizza_place_api.Models;
using Dapper;

namespace csharp_pizza_place_api.Repositories
{
  public class PizzasRepository
  {
    private readonly IDbConnection _db;
    public PizzasRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Pizza> GetAll()
    {
      string sql = "SELECT * FROM pizzas";
      return _db.Query<Pizza>(sql);
    }

    internal Pizza Create(Pizza newData)
    {
      string sql = @"
      INSERT INTO pizzas
      (name, description, price)
      VALUES
      (@Name, @Description, @Price);
      SELECT LAST_INSERT_ID()";

      int id = _db.ExecuteScalar<int>(sql, newData);
      newData.Id = id;
      return newData;
    }
  }
}