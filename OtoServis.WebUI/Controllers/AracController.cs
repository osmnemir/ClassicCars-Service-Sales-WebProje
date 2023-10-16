using Microsoft.AspNetCore.Mvc;
using OtoServis.Entities;
using OtoServis.Service.Abstract;
using OtoServis.Service.Concrete;
using OtoServis.WebUI.Utils;

namespace OtoServis.WebUI.Controllers
{
    public class AracController : Controller
    {
        private readonly ICarService _serviceArac;
        private readonly IService<Musteri> _serviceMusteri;


        public AracController(ICarService serviceArac, IService<Musteri> serviceMusteri)
        {
            _serviceArac = serviceArac;
            _serviceMusteri = serviceMusteri;
        }

        public async Task<IActionResult> IndexAsync(int id)
        {
            var model = await _serviceArac.GetCustomCar(id);
            return View(model);
        }

        [Route("tum-araclarimiz")]
        public async Task<IActionResult> List()
        {
            var model = await _serviceArac.GetCustomCarList(c => c.SatistaMi);
            return View(model);
        }

        public async Task<IActionResult> Ara(string q)
        {
            var model = await _serviceArac.GetCustomCarList(c => c.SatistaMi && c.Marka.Name.Contains(q) || c.Modeli.Contains(q));
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MusteriKayit(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _serviceMusteri.UpdateAsync(musteri);
                    await _serviceMusteri.SaveAsync();
                   // await MainHelper.SendMailAsync(musteri);
                    TempData["Message"] = "" +
                        "<style>\r\n    .custom-alert-success {\r\n        background-color: #4CAF50; /* Yeşil arka plan rengi */\r\n    " +
                        "    color: #fff; /* Beyaz metin rengi */\r\n        border: 2px solid #357a38; /* Kenarlık rengi */\r\n        border-radius: 5px; /* Yuvarlak köşeler */\r\n       " +
                        " padding: 15px; /* Daha fazla dolgulu alan */\r\n        margin: 10px 0; /* Daha fazla dönüşüm alanı */\r\n    }\r\n\r\n   " +
                        " .custom-alert-success h4 {\r\n        font-size: 20px; /* Başlık font büyüklüğü */\r\n    }\r\n\r\n    .custom-alert-success p {\r\n        " +
                        "font-size: 16px; /* Açıklama font büyüklüğü */\r\n   " +
                        " }\r\n</style>\r\n<div class=\"alert custom-alert-success\">\r\n    <h4 class=\"alert-heading\">Başarılı!</h4>\r\n    <p class=\"mb-0\">Talebiniz başarıyla alınmıştır. Teşekkür ederiz!</p>\r\n</div>\r\n";
                    return Redirect("/Arac/Index/" + musteri.AracId);
                }
                catch
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Talebiniz Alınamamıştır.Tekrar Deneyiniz..</div>";

                    ModelState.AddModelError("", "Hata Oluştu");
                }

            }
            return View();
        }
    }
}
