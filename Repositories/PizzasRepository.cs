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
    internal Pizza GetById(int id)
    {
      string sql = "SELECT * FROM pizzas WHERE id = @id";
      return _db.QueryFirstOrDefault<Pizza>(sql, new { id });
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

    internal void Edit(Pizza update)
    {
      string sql = @"
      UPDATE pizzas
      SET
      name = @Name,
      description = @Description,
      price = @Price
      WHERE id = @id;";
      _db.Execute(sql, update);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM pizzas WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}