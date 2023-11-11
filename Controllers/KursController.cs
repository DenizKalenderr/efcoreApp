using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class KursController : Controller
    {
        private readonly DataContext _contex;
        public KursController(DataContext context)
        {
            _contex = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var kurslar = await _contex.Kurslar.ToListAsync();
            return View(kurslar);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Kurs model)
        {
            _contex.Kurslar.Add(model);
            //Vt na aktarır bu satır.
            await _contex.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var kurs = await _contex.Kurslar.FindAsync(id);

            if(kurs == null)
            {
                return NotFound();
            }
            return View(kurs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Kurs model)
        {
            if(id != model.KursId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _contex.Update(model);
                    await _contex.SaveChangesAsync();

                }

                catch(DbUpdateConcurrencyException)
                {
                    if(!_contex.Kurslar.Any(k => k.KursId == model.KursId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var krs = await _contex.Kurslar.FindAsync(id);

            if(krs == null)
            {
                return NotFound();
            }

            return View(krs);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            var ogrn = await _contex.Kurslar.FindAsync(id);
            if(ogrn == null)
            {
                return NotFound();
            }
            _contex.Kurslar.Remove(ogrn);
            await _contex.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}