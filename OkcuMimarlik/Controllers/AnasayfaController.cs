﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MertProje.Models;
using MertProje.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;


namespace MertProje.Controllers;

public class AnasayfaController : Controller
{
    // private readonly ILogger<AnasayfaController> _logger;

    // public AnasayfaController(ILogger<AnasayfaController> logger)
    // {
    //     _logger = logger;
    // }
    private readonly IWebHostEnvironment _webHostEnvironment;

    private readonly Context _context;
    public AnasayfaController(Context context, IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
        _context = context;
    }
    [HttpGet]
    public IActionResult index()
    {
        //veri tabanındaki son kaydı alıyoruz
        var latestModel = _context.anasayfas.OrderByDescending(x => x.AnasayfaID).FirstOrDefault();


        return View("index", latestModel);

    }
    public IActionResult anasayfaCreate()
    {

        var entity = _context.anasayfas.OrderByDescending(x => x.AnasayfaID).FirstOrDefault();
        return View(entity);
    }


    [HttpPost]
    public IActionResult anasayfaCreate( AnasayfaModel model, IFormFile? Anasayfaİmage1, IFormFile? Anasayfaİmage2)
    {
        if (ModelState.IsValid)
        {
            if (Anasayfaİmage1 != null && Anasayfaİmage1.Length > 0)
            {
                var dosyaAdi1 = Guid.NewGuid().ToString() + "_" + Anasayfaİmage1.FileName;
                var yuklemeYolu1 = Path.Combine(_webHostEnvironment.WebRootPath, "img", dosyaAdi1);
                using (var dosyaAkisi1 = new FileStream(yuklemeYolu1, FileMode.Create))
                {
                    Anasayfaİmage1.CopyTo(dosyaAkisi1);
                }
                model.Anasayfaİmage1 = dosyaAdi1;
            }
            else if (!string.IsNullOrEmpty(model.Anasayfaİmage1))
            {
                // Resim 1 seçilmediyse ve modelde eski bir resim varsa, eski resmi kullan
                model.Anasayfaİmage1 = _context.anasayfas
                    .Where(x => x.AnasayfaID == model.AnasayfaID)
                    .Select(x => x.Anasayfaİmage1)
                    .FirstOrDefault();
            }


            if (Anasayfaİmage2 != null && Anasayfaİmage2.Length > 0)
            {
                var dosyaAdi2 = Guid.NewGuid().ToString() + "_" + Anasayfaİmage2.FileName;
                var yuklemeYolu2 = Path.Combine(_webHostEnvironment.WebRootPath, "img", dosyaAdi2);
                using (var dosyaAkisi2 = new FileStream(yuklemeYolu2, FileMode.Create))
                {
                    Anasayfaİmage2.CopyTo(dosyaAkisi2);
                }
                model.Anasayfaİmage2 = dosyaAdi2;
            }
            else if (!string.IsNullOrEmpty(model.Anasayfaİmage2))
            {
                // Resim 2 seçilmediyse ve modelde eski bir resim varsa, eski resmi kullan
                model.Anasayfaİmage2 = _context.anasayfas
                    .Where(x => x.AnasayfaID == model.AnasayfaID)
                    .Select(x => x.Anasayfaİmage2)
                    .FirstOrDefault();
            }

            model.AnasayfaID = _context.anasayfas.Max(x => x.AnasayfaID) + 1;
            _context.anasayfas.Add(model);
            _context.SaveChanges();

            return RedirectToAction("index", "Anasayfa");
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
