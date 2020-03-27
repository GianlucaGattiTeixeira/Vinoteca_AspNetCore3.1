using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vinoteca.Core;
using Vinoteca.Data;
using Vinoteca.Models;

namespace Vinoteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVinotecaData _VinotecaData;
        private readonly IWebHostEnvironment _host;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IVinotecaData VinotecaData, IWebHostEnvironment host)
        {
            _logger = logger;
            _VinotecaData = VinotecaData;
            _host = host;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Listado() 
        {
            IEnumerable<Vino> vinos = _VinotecaData.GetAllVinos();
            List<VinoViewModel> listado = new List<VinoViewModel>();
            foreach (var v in vinos)
            {
                var vino = new VinoViewModel
                {
                    Nombre = v.Nombre,
                    Id = v.Id,
                    PrecioVenta = v.PrecioVenta,
                    IdBodega = v.IdBodega,
                    imgDataURL = null
                };
                if (v.Imagen != null)
                {
                    vino.imgDataURL = vino.ConvertByteArrayToString(v.Imagen);
                }
                listado.Add(vino);
            }
            return View(listado);
        }
        //este deberia ser el listado
        [HttpGet]
        public IActionResult Vino() {
            return View();
        }
        [HttpPost]
        public IActionResult Vino(VinoViewModel vino) {
            if (ModelState.IsValid)
            {
                if (vino.Imagen != null)
                {
                    //var uploadFolder = Path.Combine(_host.WebRootPath, "images");
                    //var nombreArchivoIngresado = Path.GetFileName(vino.Imagen.FileName);
                    //var uniqueFileName = Guid.NewGuid().ToString() + "_" + nombreArchivoIngresado;
                    //var filePath = Path.Combine(uploadFolder, uniqueFileName);
                    //vino.Imagen.CopyTo(new FileStream(filePath, FileMode.Create));
                    byte[] bitearray = vino.TransformToByteArray();
                }
                var dbVino = new Vino()
                {
                    Nombre = vino.Nombre,
                    PrecioVenta = vino.PrecioVenta,
                    IdBodega = vino.IdBodega,
                };
                
                _VinotecaData.AddVino(dbVino);
                _VinotecaData.Commit();
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
