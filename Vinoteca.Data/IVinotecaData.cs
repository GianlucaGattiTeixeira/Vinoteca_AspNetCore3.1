using System;
using System.Collections.Generic;
using System.Text;
using Vinoteca.Core;

namespace Vinoteca.Data
{
    public interface IVinotecaData
    {
        IEnumerable<Vino> GetAllVinos();
        Vino GetVinoById(int id);
        Vino UpdateVino(Vino vino);
        Vino AddVino(Vino Vino);
        Vino DeleteVino(int id);
        int Commit();
    }
}
