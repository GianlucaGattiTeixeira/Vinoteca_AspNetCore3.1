using System;
using System.Collections.Generic;
using System.Text;

namespace Vinoteca.Core
{
    public class Bodega
    {
        public int Id { get; set; }
        public string NombreBodega { get; set; }
        public List<Vino> Vinos { get; set; }
    }
}
