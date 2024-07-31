using AutoMapper;
using workone.Models;

namespace workone.VmModel;
[AutoMap(typeof(Student),ReverseMap =true)]
public class VmStudent
{
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
