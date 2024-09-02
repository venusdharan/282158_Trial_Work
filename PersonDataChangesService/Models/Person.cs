namespace PersonDataChangesService.Models;

public class Person
{
    public string PersonalCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; } 
}