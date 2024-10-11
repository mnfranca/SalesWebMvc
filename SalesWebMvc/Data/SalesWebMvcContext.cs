using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

public class SalesWebMvcContext : DbContext
{
    public SalesWebMvcContext(DbContextOptions<SalesWebMvcContext> options)
        : base(options)
    {
    }

    public DbSet<Department> Department { get; set; } = default!;
    public DbSet<Department> Seller { get; set; } = default!;
    public DbSet<Department> SalesRecord { get; set; } = default!;
}
