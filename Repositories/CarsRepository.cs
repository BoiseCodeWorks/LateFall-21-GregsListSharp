using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using lf21GregslistSharp.Models;

namespace lf21GregslistSharp.Repositories
{
  public class CarsRepository
  {
    private readonly IDbConnection _db;

    public CarsRepository(IDbConnection db)
    {
      _db = db;
    }

    // REVIEW this one does not populate relationship
    // internal List<Car> GetAll()
    // {
    //   string sql = @"SELECT * FROM cars;";
    //   // NOTE Query comes from dapper, <Typeof> tells dapper what the information on the table coming back should be cast as.
    //   return _db.Query<Car>(sql).ToList();
    // }

    // REVIEW this one does Populate 'creator' relationship
    internal List<Car> GetAll()
    {
      string sql = @"
      SELECT
        car.*,
        account.*
      FROM cars car
      JOIN accounts account ON car.creatorId = account.id;";
      // NOTE Query comes from dapper, <Typeof> tells dapper what the information on the table coming back should be cast as.
      return _db.Query<Car, Account, Car>(sql, (car, account) =>
      {
        car.Creator = account;
        return car;
      }, splitOn: "id").ToList();
    }


    internal Car GetById(int id)
    {
      string sql = @$"SELECT * FROM cars WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Car>(sql, new { id });

    }

    internal Car Create(Car newCar)
    {
      string sql = @$"
     INSERT INTO cars
      (make, model, year, price, imgURL, description, color, creatorId)
     VALUES
      (@Make, @Model, @Year, @Price, @ImgURL, @Description, @Color, @CreatorId)
     ;
     SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newCar);
      newCar.Id = id;
      return newCar;
    }

    internal void Remove(int id)
    {
      string sql = @"
      DELETE FROM cars
      WHERE id = @Id
      ;";
      int rows = _db.Execute(sql, new { id });
      if (rows <= 0)
      {
        throw new Exception("invalid Id");
      }
    }

    internal Car Update(Car updatedCar)
    {
      string sql = @"
      UPDATE cars
      SET
      make = @Make,
      model = @Model,
      year = @Year,
      price = @Price,
      imgURL = @ImgURL,
      description = @Description,
      color = @Color
      WHERE id = @Id
      ;";
      int rows = _db.Execute(sql, updatedCar);
      if (rows <= 0)
      {
        throw new Exception("Car was not updated");
      }
      return updatedCar;
    }
  }
}