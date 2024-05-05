using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DBConfiguration;

public class AppDBContext : DbContext
{
    public DbSet<JobTitle> JobTitles { get; set; }
    
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
        Database.EnsureCreated();
    } 
}