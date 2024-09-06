using Microsoft.EntityFrameworkCore;
using PersonDataChangesService.Models;

namespace PersonDataChangesService.Data;

public class PersonDataContext : DbContext
{
    public PersonDataContext(DbContextOptions<PersonDataContext> options) 
        : base(options) { }

    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasKey(p => p.PersonalCode); 
    }
}