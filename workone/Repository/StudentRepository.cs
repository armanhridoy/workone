using AutoMapper;
using workone.Models;
using workone.Service;
using workone.StudentDBase;
using workone.VmModel;

namespace workone.Repository;

public class StudentRepository : CommonService<Student, VmStudent>, IStudentRepository
{
    public StudentRepository(IMapper mapper, ApplicationSt dbcontext) : base(mapper, dbcontext)
    {
    }
}
