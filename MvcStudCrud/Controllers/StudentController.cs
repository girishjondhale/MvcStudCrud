using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcStudCrud.Models;

namespace MvcStudCrud.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration configuration;
        private StudentCrud crud;

        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new StudentCrud(this.configuration);
        }

        public ActionResult Index()
        {
            var model = crud.GetAllStudents();
            return View(model);
           
        }

       

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var result = crud.GetStudentById(id);
            return View(result);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                int result = crud.AddStudent(student);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = crud.GetStudentById(id);
            return View(result);

        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                int result = crud.UpdateStudent(student);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = crud.GetStudentById(id);
            return View(result);

        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteStudent(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }

        }
    }
}
