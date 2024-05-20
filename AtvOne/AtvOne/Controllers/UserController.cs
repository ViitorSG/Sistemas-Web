using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtvOne.Models;

namespace AtvOne.Controllers
{
    public class UserController : Controller
    {
        private readonly AtvOne.Data.AppContext _appContext;

        public UserController(AtvOne.Data.AppContext context)
        {
            _appContext = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var allUsers = await _appContext.Users.ToListAsync();
            return View(allUsers);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user, IList<IFormFile> Img)
        {
            IFormFile uploadImage = Img.FirstOrDefault();
            MemoryStream ms = new MemoryStream();
            if (Img.Count > 0)
            {
                uploadImage.OpenReadStream().CopyTo(ms);
                user.Foto = ms.ToArray();
            }
            _appContext.Users.Add(user);
            _appContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _appContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, User user, IList<IFormFile> Img)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var oldUserData = _appContext.Users.AsNoTracking().FirstOrDefault(u => u.Id == id);

                    MemoryStream ms = new MemoryStream();
                    if (Img.Count > 0)
                    {
                        IFormFile uploadedImage = Img.FirstOrDefault();
                        uploadedImage.OpenReadStream().CopyTo(ms);
                        user.Foto = ms.ToArray();
                    }
                    else
                    {
                        user.Foto = oldUserData.Foto;
                    }

                    _appContext.Update(user);
                    await _appContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        [HttpGet]
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _appContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _appContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var user = await _appContext.Users.FindAsync(id);
            _appContext.Users.Remove(user);
            await _appContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(Guid id)
        {
            return _appContext.Users.Any(e => e.Id == id);
        }
    }
}
