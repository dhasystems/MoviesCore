using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesCore.Models;

namespace MoviesCore.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieListDbContext _context;

        public MovieController(MovieListDbContext context)
        {
            _context = context;
        }

        // GET: Movie
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovieLists.ToListAsync());
        }



        // GET: Movie/AddOrEdit
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new MovieListModel());
            else
            {
                var movieListModel = await _context.MovieLists.FindAsync(id);
                if (movieListModel == null)
                {
                    return NotFound();
                }
                return View(movieListModel);
            }
        }

        // POST: Movie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("MovieID,TmdbID,Title,Year,Type,Genre,Poster,Trailer,Quality")] MovieListModel movieListModel)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    _context.Add(movieListModel);
                    await _context.SaveChangesAsync();

                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(movieListModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MovieListModelExists(movieListModel.MovieID))
                        { return NotFound(); }
                        else
                        { throw; }
                    }

                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.MovieLists.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", movieListModel) });
        }



            // GET: Movie/Delete/5
            public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieListModel = await _context.MovieLists
                .FirstOrDefaultAsync(m => m.MovieID == id);
            if (movieListModel == null)
            {
                return NotFound();
            }

            return View(movieListModel);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieListModel = await _context.MovieLists.FindAsync(id);
            _context.MovieLists.Remove(movieListModel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.MovieLists.ToList()) });
        }

        private bool MovieListModelExists(int id)
        {
            return _context.MovieLists.Any(e => e.MovieID == id);
        }
    }
}
