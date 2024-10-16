using System;

namespace SalesWebMvc.Models;

public class Department
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public ICollection<Seller> Sellers { get; set; } = [];

  public Department()
  {
  }

  public Department(int id, string name)
  {
    Id = id;
    Name = name;
  }

  public void AddSeller(Seller seller)
  {
    Sellers.Add(seller);
  }

  public double TotalSales(DateTime initial, DateTime final)
  {
    return Sellers.Sum(s => s.TotalSales(initial, final));
  }

  public override string ToString()
  {
    return Name;
  }
}
