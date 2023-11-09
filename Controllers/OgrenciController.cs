using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace efcoreApp.Controllers
{
    public class OgrenciController : Controller
    {
        //Bu işleme injection denir. Consturctor ile bu şekilde yapılır.
        private readonly DataContext _context;
        public OgrenciController(DataContext context)
        {
            _context = context;
            
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ogrenciler.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model)
        {
            //Ogrenciler üzerine add aracılığıyla gönderilen model bilgisini ekledim.
            _context.Ogrenciler.Add(model);
           await _context.SaveChangesAsync();
           return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var ogr = await _context.Ogrenciler.FindAsync(id);
            // var ogr = await _context.Ogrenciler.FirstOrDefaultAsync(o => o.OgrenciId == id );

            if(ogr == null)
            {
                return NotFound();
            }
            return View(ogr);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Ogrenci model)
        {
            if(id != model.OgrenciId)
            {
                return NotFound();               
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    //Güncelleme burada oluyor.
                    await _context.SaveChangesAsync();
                }
                //Aynı anda bu kaydı güncelleyip kayıt olmadığı durum için
                catch(DbUpdateConcurrencyException)
                {
                    // Any = bir ya da daha fazla kayıt var mı?
                    if(!_context.Ogrenciler.Any(o => o.OgrenciId == model.OgrenciId))
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

            var ogrenci = await _context.Ogrenciler.FindAsync(id);

            if(ogrenci == null)
            {
                return NotFound();
            }
            
            return View(ogrenci);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if(ogrenci == null)
            {
                return NotFound();
            }
            _context.Ogrenciler.Remove(ogrenci);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}