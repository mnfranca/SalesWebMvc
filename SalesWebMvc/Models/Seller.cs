using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Models;

public class Seller
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public required string Email { get; set; }
  public DateTime BirthDate { get; set; }
  public double BaseSalary { get; set; }
  public Department? Department { get; set; }
  public required int DepartmentId { get; set; }
  public ICollection<SalesRecord> Sales { get; set; } = [];

  public Seller()
  {
  }

  public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, int departmentId)
  {
    Id = id;
    Name = name;
    Email = email;
    BirthDate = birthDate;
    BaseSalary = baseSalary;
    DepartmentId = departmentId;
  }

  public void AddSales(SalesRecord salesRecord)
  {
    Sales.Add(salesRecord);
  }

  public void RemoveSales(SalesRecord salesRecord)
  {
    Sales.Remove(salesRecord);
  }

  public double TotalSales(DateTime initial, DateTime final)
  {
    return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
  }
}
