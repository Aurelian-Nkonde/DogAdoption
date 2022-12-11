using System;
using Microsoft.EntityFrameworkCore;
using dogAdoption.Models;


namespace dogAdoption.Data 
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt): base(opt)
        {
            
        }

        public DbSet<Dog> dogs { get;set; }
        public DbSet<AdoptionRequest> adoptionRequests { get;set; }
    }
}