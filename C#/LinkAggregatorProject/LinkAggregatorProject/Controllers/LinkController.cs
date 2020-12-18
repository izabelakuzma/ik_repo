using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LinkAggregatorProject.Models;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Http;
using cloudscribe.Pagination.Models;

namespace LinkAggregatorProject.Controllers
{
    public class LinkController : Controller
    {
        private readonly UserDbContext _context;
        public LinkController(UserDbContext context)
        {
            _context = context;
        }
        // GET: Link
        [Obsolete]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10) 
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;          
            var user = HttpContext.Session.GetString("UserID") == null ? "0" : HttpContext.Session.GetString("UserID");
            var query = _context.LinkRatingViewModel.FromSql(@$"exec GetLink @userRate = {user}").ToList();
            query = query.Skip(ExcludeRecords).Take(pageSize).ToList();

            var result = new PagedResult<LinkRatingViewModel>
            {
                Data = query.AsQueryable().AsNoTracking().ToList(),
                TotalItems = _context.Links.Count(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return View(result);        
        }
        // GET: Link
        [Obsolete]
        public async Task<IActionResult> Profile(int pageNumber = 1, int pageSize = 10) 
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;
            var user = HttpContext.Session.GetString("UserID") == null ? "0" : HttpContext.Session.GetString("UserID");
            var query = _context.LinkRatingViewModel.FromSql(@$"exec GetLink @userId = {user}").ToList();
            query = query.Skip(ExcludeRecords).Take(pageSize).ToList();

            var result = new PagedResult<LinkRatingViewModel>
            {
                Data = query.AsQueryable().AsNoTracking().ToList(),
                TotalItems = _context.Links.Count(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return View(result);
        }
        // GET: Links/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var link = await _context.Links
                .FirstOrDefaultAsync(m => m.LinkId == id);
            if (link == null)
            {
                return NotFound();
            }
            return View(link);
        }
        // GET: Links/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Links/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LinkId,UserId,Title,LinkAddress,AddingData")] Link link)
        {
            var user = HttpContext.Session.GetString("UserID");
            link.AddingData = DateTime.Today;
            link.UserId = Convert.ToInt16(user);

            if (!Uri.IsWellFormedUriString(link.LinkAddress, UriKind.Absolute))
            {
                ModelState.AddModelError("", "Nieprawidłowy adres wpisanego linku.");
                return View();
            }

            if (ModelState.IsValid)
            {
                _context.Add(link);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Profile", "Link", new { area = "" });
            //return View(link);
        }

        public async Task<IActionResult> RatingAdd(int? linkId)
        {
            if (linkId == null)
            {
                return NotFound();
            }
            var user = HttpContext.Session.GetString("UserID");

            Rating rating = new Rating();
            rating.LinkId = linkId;
            rating.UserId = Convert.ToInt16(user);
            rating.IsRate = 1;

            Rating existingRate = await _context.Ratings.SingleOrDefaultAsync(
            m => m.UserId == rating.UserId && m.LinkId == rating.LinkId);
            if (existingRate != null)
            {

                ModelState.AddModelError(string.Empty, "Ten link został już przez Ciebie oceniony!");
                return RedirectToAction("Index");
            }

            _context.Add(rating);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RatingRemove(int? linkId)
        {
            if (linkId == null)
            {
                return NotFound();
            }
            var user = HttpContext.Session.GetString("UserID");

            var foos = await _context.Ratings.Where(x => x.UserId == Convert.ToInt32(user) && x.LinkId == linkId).FirstOrDefaultAsync();

            _context.Ratings.Remove(foos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: Links/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var link = await _context.Links.FindAsync(id);
            if (link == null)
            {
                return NotFound();
            }
            return View(link);
        }
        // POST: Links/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LinkId,UserId,Title,LinkAddress,AddingData")] Link link)
        {
            if (id != link.LinkId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(link);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinkExists(link.LinkId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(link);
        }
        // GET: Links/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var link = await _context.Links
                .FirstOrDefaultAsync(m => m.LinkId == id);
            if (link == null)
            {
                return NotFound();
            }
            return View(link);
        }
        // POST: Links/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var link = await _context.Links.FindAsync(id);
            _context.Links.Remove(link);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool LinkExists(int id)
        {
            return _context.Links.Any(e => e.LinkId == id);
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
