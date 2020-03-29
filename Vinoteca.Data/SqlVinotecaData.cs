using System.Collections.Generic;
using System.Linq;
using Vinoteca.Core;

namespace Vinoteca.Data
{
    public class SqlVinotecaData : IVinotecaData
    {
        private readonly VinotecaDbContext _ctx;
        public SqlVinotecaData(VinotecaDbContext ctx) 
        {
            _ctx = ctx;
        }

        public Vino AddVino(Vino newVino)
        {
            _ctx.Add(newVino);
            return newVino;
        }

        public int Commit()
        {
            return _ctx.SaveChanges();
        }

        public Vino DeleteVino(int id)
        {
            var vino = GetVinoById(id);
            if (vino != null){
                _ctx.Remove(vino);
            } 
            return vino;
        }

        public List<int> GetAllIdBodegas() // que pasa si quiero retrivear un array de int
        {
            List<int> Ids = _ctx.Bodegas.Select(b => b.Id).ToList();
            return Ids;
        }

        public IEnumerable<Vino> GetAllVinos()
        {
            return _ctx.Vinos.ToList();
        }

        public Vino GetVinoById(int id)
        {
            var vino =_ctx.Vinos.FirstOrDefault(v => v.Id == id);
            return vino;
        }

        public Vino UpdateVino(Vino updatedVino)
        {
            var vino = GetVinoById(updatedVino.Id);
            if (vino != null)
            {
                vino = updatedVino;
                return vino;
            }
            return vino;
        }
    }
}
