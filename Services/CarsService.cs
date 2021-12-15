using System;
using System.Collections.Generic;
using lf21GregslistSharp.Models;
using lf21GregslistSharp.Repositories;

namespace lf21GregslistSharp.Services
{
  public class CarsService
  {
    private readonly CarsRepository _repo;

    public CarsService(CarsRepository repo)
    {
      _repo = repo;
    }

    internal List<Car> Get()
    {
      return _repo.GetAll();
    }

    internal Car Get(int id)
    {
      Car found = _repo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid ID");
      }
      return found;
    }
    internal Car Create(Car newCar)
    {
      _repo.Create(newCar);
      return newCar;
    }
    internal Car Update(Car updatedCar)
    {
      Car oldCar = Get(updatedCar.Id);
      updatedCar.Make = updatedCar.Make != null ? updatedCar.Make : oldCar.Make;
      updatedCar.Model = updatedCar.Model != null ? updatedCar.Model : oldCar.Model;
      updatedCar.Year = updatedCar.Year != 0 ? updatedCar.Year : oldCar.Year;
      updatedCar.Price = updatedCar.Price != 0 ? updatedCar.Price : oldCar.Price;
      updatedCar.ImgURL = updatedCar.ImgURL != null ? updatedCar.ImgURL : oldCar.ImgURL;
      updatedCar.Description = updatedCar.Description != null ? updatedCar.Description : oldCar.Description;
      updatedCar.Color = updatedCar.Color != null ? updatedCar.Color : oldCar.Color;
      return _repo.Update(updatedCar);
    }
    internal void Remove(int id)
    {
      Car car = Get(id);
      _repo.Remove(id);
    }

  }
}