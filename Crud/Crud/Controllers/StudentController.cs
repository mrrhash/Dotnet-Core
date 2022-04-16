using Crud.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    public class StudentController : Controller
    {

        private readonly DataContext _Db;

        public StudentController(DataContext db)
        {
            _Db = db;
        }
        public IActionResult StudentList()
        {

            try
            {
                // var stdlist = _Db.Students.ToList();

                var stdlist = from a in _Db.Students

                              join b in _Db.Faculty
                              on a.faculty_id equals b.id
                              into faculty
                              from b in faculty.DefaultIfEmpty()

                              join c in _Db.Batch
                              on a.batch_id equals c.id
                              into batch
                              from c in batch.DefaultIfEmpty()

                              select new Students
                              {
                                  id = a.id,
                                  name = a.name,
                                  email = a.email,
                                  address = a.address,
                                  mobile = a.mobile,
                                  faculty_id = b.id,
                                  faculty = b == null ? "" : b.faculty,
                                  batch_id = c.id,
                                  batch = c == null ? "" : c.batch,
                              };





                return View(stdlist);
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        public IActionResult create()
        {
            loadbat();
            loadfac();  
            return View();
        }
        public IActionResult Edit(Students obj)
        {
            loadbat();
            loadfac();
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(Students obj)
        {
            try
            {
                if (obj.id == 0)
                {
                    _Db.Students.Add(obj);
                    await _Db.SaveChangesAsync();

                }
                else
                {
                    _Db.Entry(obj).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await _Db.SaveChangesAsync();
                }
                
                return RedirectToAction("StudentList");

            }

            catch (Exception ex)
            {
               Console.Write(ex.Message);
                return View("Create");
            }

        }

        private void loadfac()
        {
            try
            {
                List<Faculty> faclist = new List<Faculty>();
                faclist = _Db.Faculty.ToList();

                

                ViewBag.faculty = faclist;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var std = await _Db.Students.FindAsync(id);
                if(std != null)
                {
                    _Db.Students.Remove(std);
                    await _Db.SaveChangesAsync();   
                }
                
                return RedirectToAction("StudentList");
            }
            catch(Exception ex)
            {
                return RedirectToAction("StudentList");

            }
        }
        private void loadbat()
        {
            try
            {
                List<Batch> batlist = new List<Batch>();
                batlist = _Db.Batch.ToList();

              

                ViewBag.batch = batlist;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
