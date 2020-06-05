using BlazorAppTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppTest.DAL
{
    public class BlazorAppDB : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public BlazorAppDB(DbContextOptions<BlazorAppDB> Options) : base(Options) { }
    }
}
