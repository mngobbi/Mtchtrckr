using MatchTrakr.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTrakr.Data
{

    public interface IMatchTrakrRepository
    {
        IQueryable<Complejo> GetComplejos();


        int SaveComplejo(Complejo complejo);
    }

    public class MatchTrakrRepository : IMatchTrakrRepository
    {
        private MatchTrakrContext _ctx;
        public MatchTrakrRepository()
        {
            _ctx = new MatchTrakrContext();
        }

        public IQueryable<Complejo> GetComplejos()
        {
            return _ctx.Complejos.Where( e => e.Canchas.Count > 1).AsQueryable();
        }

        public int SaveComplejo(Complejo complejo)
        {
            try
            {
                complejo.FechaAlta = DateTime.Now;
                _ctx.Complejos.Add(complejo);

                return _ctx.SaveChanges();

            }
            catch (Exception)
            {
                return 0;
            }
        }


    }

  
}
