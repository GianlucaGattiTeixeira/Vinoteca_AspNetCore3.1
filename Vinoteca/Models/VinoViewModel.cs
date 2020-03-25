using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vinoteca.Models
{
    public class VinoViewModel
    {
        public string Nombre { get; set; }
        public double PrecioVenta { get; set; }
        public int IdBodega { get; set; }
        public IFormFile Imagen {get; set;}
    }
}
