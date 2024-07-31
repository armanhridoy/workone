using Microsoft.AspNetCore.Mvc;
using workone.Repository;
using workone.VmModel;

namespace workone.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController (IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllStudent(CancellationToken cancellationToken)
        {
            return Json(await _studentRepository.GetAllAsync(cancellationToken));
        }
        [HttpGet]
        public async Task<IActionResult>CreateOrEdit(int id,CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                return View(new VmStudent());
            }
            else
            {
                var data = await _studentRepository.GetByIdAsync(id, cancellationToken);
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task <IActionResult> CreateOrEdit(int id,VmStudent vmStudent,CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                await _studentRepository.InsertAsync(vmStudent, cancellationToken);
                return RedirectToAction("Index");
            }
            else
            {
                await _studentRepository.UpDateAsync(id,vmStudent, cancellationToken);
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult>Delete(int id,CancellationToken cancellationToken)
        {
            await _studentRepository.DeleteAsync(id,cancellationToken);
            return RedirectToAction("Index");
        }
        
    }
}
