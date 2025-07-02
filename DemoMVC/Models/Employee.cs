using System.ComponentModel.DataAnnotations;
namespace DemoMVC.Models;

public class Employee
{
    public string PersonId { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public string EmployeeID { get; set; }
    public int Age { get; set;}
}