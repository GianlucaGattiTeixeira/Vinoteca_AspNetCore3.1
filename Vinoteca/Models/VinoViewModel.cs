using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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
        public Byte[] TransformToByteArray()
        {
            using (var memoryStream = new MemoryStream())
            {
                this.Imagen.CopyTo(memoryStream); //esta era Await this.Imagen.CopyToAsync(memoryStream);
                if (memoryStream.Length < 2097152) {
                    byte[] retorno = memoryStream.ToArray();
                    return retorno;
                }
            }
            return null;
        }
    }


}
