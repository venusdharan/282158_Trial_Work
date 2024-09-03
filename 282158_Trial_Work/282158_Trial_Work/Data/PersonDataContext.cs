using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;
using PersonDataChangesService.Models;

namespace _282158_Trial_Work.Data
{
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
}
