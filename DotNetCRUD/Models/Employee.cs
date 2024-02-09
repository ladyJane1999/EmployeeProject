namespace EmployeeProject.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    public string MobileNumber { get; set; }
    public Passport Passport { get; set; }
    public Department Department { get; set; }
}