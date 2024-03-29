using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MertProje.Models;
using MertProje.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;


namespace MertProje.Controllers;

public class HakkımızdaController : Controller
{
   
    private readonly IWebHostEnvironment _webHostEnvironment;

    private readonly Context _context;
    public HakkımızdaController(Context context, IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
        _context = context;
    }

   //son kaydı getirir veri tabanından
    public IActionResult index()
    {
       var latestModel = _context.hakkımızdas.OrderByDescending(x => x.HakkımızdaID).FirstOrDefault();
    
  
           return View("index", latestModel); 

    }
    public IActionResult hakkimizdaCreate()
    {
        var entity = _context.hakkımızdas.OrderByDescending(x => x.HakkımızdaID).FirstOrDefault();
        return View(entity);
    }


    [HttpPost]
    public IActionResult hakkimizdaCreate(HakkımızdaModel model,IFormFile? Hakkımızdaİmage, IFormFile? HakkımızdaPersonelİmage1, IFormFile? HakkımızdaPersonelİmage2)
    {
  
        if (ModelState.IsValid)
        {
            if (Hakkımızdaİmage != null && Hakkımızdaİmage.Length > 0)
            {
                var dosyaAdi1 = Guid.NewGuid().ToString() + "_" + Hakkımızdaİmage.FileName;//BNZERSİZ İSİM
                var yuklemeYolu1 = Path.Combine(_webHostEnvironment.WebRootPath, "img", dosyaAdi1);//İMG KLASÖRÜNE KAYIT
                using (var dosyaAkisi1 = new FileStream(yuklemeYolu1, FileMode.Create))
                {
                    Hakkımızdaİmage.CopyTo(dosyaAkisi1);
                }
                model.Hakkımızdaİmage = dosyaAdi1;
            }
               else if (!string.IsNullOrEmpty(model.Hakkımızdaİmage))
            {
                // Resim 1 seçilmediyse ve modelde eski bir resim varsa, eski resmi kullan
                model.Hakkımızdaİmage = _context.hakkımızdas
                    .Where(x => x.HakkımızdaID == model.HakkımızdaID)
                    .Select(x => x.Hakkımızdaİmage)
                    .FirstOrDefault();
            }

            if (HakkımızdaPersonelİmage1 != null && HakkımızdaPersonelİmage1.Length > 0)
            {
                var dosyaAdi2 = Guid.NewGuid().ToString() + "_" + HakkımızdaPersonelİmage1.FileName;
                var yuklemeYolu2 = Path.Combine(_webHostEnvironment.WebRootPath, "img", dosyaAdi2);
                using (var dosyaAkisi2 = new FileStream(yuklemeYolu2, FileMode.Create))
                {
                    HakkımızdaPersonelİmage1.CopyTo(dosyaAkisi2);
                }
                model.HakkımızdaPersonelİmage1 = dosyaAdi2;
            }
              else if (!string.IsNullOrEmpty(model.HakkımızdaPersonelİmage1))
            {
                // Resim 1 seçilmediyse ve modelde eski bir resim varsa, eski resmi kullan
                model.HakkımızdaPersonelİmage1 = _context.hakkımızdas
                    .Where(x => x.HakkımızdaID == model.HakkımızdaID)
                    .Select(x => x.HakkımızdaPersonelİmage1)
                    .FirstOrDefault();
            }

              if (HakkımızdaPersonelİmage2 != null && HakkımızdaPersonelİmage2.Length > 0)
            {
                var dosyaAdi3 = Guid.NewGuid().ToString() + "_" + HakkımızdaPersonelİmage2.FileName;
                var yuklemeYolu3 = Path.Combine(_webHostEnvironment.WebRootPath, "img", dosyaAdi3);
                using (var dosyaAkisi3 = new FileStream(yuklemeYolu3, FileMode.Create))
                {
                   HakkımızdaPersonelİmage2.CopyTo(dosyaAkisi3);
                }
                model.HakkımızdaPersonelİmage2 = dosyaAdi3;
            }
               else if (!string.IsNullOrEmpty(model.HakkımızdaPersonelİmage1))
            {
                // Resim 1 seçilmediyse ve modelde eski bir resim varsa, eski resmi kullan
                model.HakkımızdaPersonelİmage2 = _context.hakkımızdas
                    .Where(x => x.HakkımızdaID == model.HakkımızdaID)
                    .Select(x => x.HakkımızdaPersonelİmage2)
                    .FirstOrDefault();
            }
             model.HakkımızdaID = _context.hakkımızdas.Max(x => x.HakkımızdaID) + 1;
            _context.hakkımızdas.Add(model);
            _context.SaveChanges();

            return RedirectToAction("index", "Hakkımızda");
        }

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
