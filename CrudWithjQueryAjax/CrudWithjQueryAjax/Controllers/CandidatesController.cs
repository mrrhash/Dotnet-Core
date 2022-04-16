#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudWithjQueryAjax.Models;

namespace CrudWithjQueryAjax.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly DataContext _context;

        public CandidatesController(DataContext context)
        {
            _context = context;
        }

        // GET: Candidates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Candidates.ToListAsync());
        }



        // GET: Candidates/AddOrEdit
        // GET: Candidates/AddOrEdit/5
        public async Task<IActionResult> AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new Candidate());
            }
            else
            {
                var candidate = await _context.Candidates.FindAsync(id);
                if (candidate == null)
                {
                    return NotFound();
                }
                return View(candidate);
            }
          
        }


        // POST: Candidates/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("CandidateID,CandidateName,Email,BloodGroup,Age,Mobile,Created,Address")] Candidate candidate)
        {
            
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    candidate.Created = DateTime.Now;
                    _context.Add(candidate);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(candidate);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CandidateExists(candidate.CandidateID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
               
                return Json(new {isValid = true,html= Helper.RenderRazorViewToString(this,"_ViewAll",_context.Candidates.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit",candidate ) });
        }

       
        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Candidates.ToList()) });

        }

        private bool CandidateExists(int id)
        {
            return _context.Candidates.Any(e => e.CandidateID == id);
        }
    }
}
