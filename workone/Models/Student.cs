using System.ComponentModel.DataAnnotations;

namespace workone.Models;

public class Student
{
    [Key]
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string TutionFee { get; set; }
    public string Joining_date { get; set; }
}
