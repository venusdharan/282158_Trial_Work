using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Bogus;
using _282158_Trial_Work.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PersonDataContext>(options
 =>
    options.UseInMemoryDatabase("PersonData"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title
 = "PersonDataChangesService",
        Version = "v1"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline. //app.Environment.IsDevelopment()
if (true)
{
    app.UseSwagger();
    // app.UseSwaggerUI();
    app.UseSwaggerUI(c
=> c.SwaggerEndpoint("/swagger/v1/swagger.json",
"PersonDataChangesService v1"));

    var faker = new Faker<PersonDataChangesService.Models.Person>()
      .RuleFor(p => p.PersonalCode, f => f.Random.String2(11)) // Generate a random 11-character string
      .RuleFor(p => p.FirstName, f => f.Name.FirstName())
      .RuleFor(p => p.LastName, f => f.Name.LastName())
      .RuleFor(p => p.DateOfBirth, f => f.Date.Past(50)) // Generate a past date of birth within the last 50 years
      .RuleFor(p => p.DateOfDeath, f => f.Random.Bool(0.3f) ? f.Date.Recent(2) : null); // 30% chance of having a recent death date

    // Generate a list of dummy persons
    var dummyPersons = faker.Generate(100); // Generate 100 dummy persons

    // Add the dummy persons to the database and save changes
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<PersonDataContext>();
        context.Persons.AddRange(dummyPersons);
        context.SaveChanges();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
