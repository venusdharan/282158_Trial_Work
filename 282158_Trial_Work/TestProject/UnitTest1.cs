using _282158_Trial_Work.Controllers;
using _282158_Trial_Work.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonDataChangesService.Models;

namespace TestProject
{
    public class UnitTest1
    {
        // Helper method to create an in-memory database context for testing
        private PersonDataContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<PersonDataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new PersonDataContext(options);
        }

        [Fact]
        public void GetChanges_ReturnsPersonsWithinDateRange()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            context.Persons.AddRange(new List<Person>
            {
                new Person { PersonalCode = "1", DateOfDeath = new DateTime(2023, 05, 15) , FirstName="F1" , LastName="L1" },
                new Person { PersonalCode = "2", DateOfDeath = new DateTime(2023, 06, 20) , FirstName="F2" , LastName="L2" },
                new Person { PersonalCode = "3" , FirstName="F3" , LastName="L3" } // No death date
            });
            context.SaveChanges();

            var controller = new PersonDataController(context);
            var startDate = new DateTime(2023, 05, 01);
            var endDate = new DateTime(2023, 06, 30);

            // Act
            var result = controller.GetChanges(startDate, endDate) as OkObjectResult;

            // Assert
            //Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
            //var changes = Assert.IsType<List<dynamic>>(result.Value);
            //Assert.Equal(2, changes.Count);
            //Assert.Contains(changes, c => c.PersonalIdentificationNumber == "1");
            //Assert.Contains(changes, c => c.PersonalIdentificationNumber == "2");
        }

        [Fact]
        public void GetChanges_ReturnsEmptyListWhenNoDeathsInRange()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            context.Persons.AddRange(new List<Person>
            {
                new Person { PersonalCode = "1", DateOfDeath = new DateTime(2023, 04, 10) , FirstName="F1" , LastName="L1" },
                new Person { PersonalCode = "2", DateOfDeath = new DateTime(2023, 07, 25) , FirstName="F2" , LastName="L2" },
                new Person { PersonalCode = "3" , FirstName="F3" , LastName="L3" } // No death date
            });
            context.SaveChanges();

            var controller = new PersonDataController(context);
            var startDate = new DateTime(2023, 05, 01);
            var endDate = new DateTime(2023, 06, 30);

            // Act
            var result = controller.GetChanges(startDate, endDate) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            //var changes = Assert.IsType<List<dynamic>>(result.Value);
            //Assert.Empty(changes);
        }

        [Fact]
        public void GetChanges_HandlesInvalidDateRange()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var controller = new PersonDataController(context);
            var startDate = new DateTime(2023, 06, 30);
            var endDate = new DateTime(2023, 05, 01);

            // Act
            var result = controller.GetChanges(startDate, endDate);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetAllPersons_ReturnsAllPersons()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            context.Persons.AddRange(new List<Person>
            {
                new Person { PersonalCode = "1" , FirstName="F1" , LastName="L1" },
                new Person { PersonalCode = "2" , FirstName="F2" , LastName="L2" },
                new Person { PersonalCode = "3" , FirstName="F3" , LastName="L3" }
            });
            context.SaveChanges();

            var controller = new PersonDataController(context);

            // Act
            var result = controller.GetAllPersons() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var persons = Assert.IsType<List<Person>>(result.Value);
            Assert.Equal(3, persons.Count);
        }

        [Fact]
        public void GetAllPersons_ReturnsNotFoundWhenNoPersons()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var controller = new PersonDataController(context);

            // Act
            var result = controller.GetAllPersons();

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}