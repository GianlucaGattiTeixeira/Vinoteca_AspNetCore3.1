using System;

namespace Vinoteca.Core
{
    public class Vino
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double PrecioVenta { get; set; }
        public int IdBodega { get; set; }
        public byte[] Imagen { get; set; }
    }
}
