

namespace lf21GregslistSharp.Models
{
  public class Car
  {
    public int Id { get; set; }

    public string? Model { get; set; }
    public string? Make { get; set; }
    public int Year { get; set; }
    public string ImgURL { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public string? Color { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
    // NOTE now that we use Dapper, we do not want a constructor for our models (dapper can't handle them)
    // public Car(string? model, string? make, int year, int price, string? color)
    // {
    //   Model = model;
    //   Make = make;
    //   Year = year;
    //   Price = price;
    //   Color = color;
    // }
  }
}