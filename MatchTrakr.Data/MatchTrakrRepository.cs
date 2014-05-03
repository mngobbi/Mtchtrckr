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
        IEnumerable<Grupo> AllGrupos();

        Grupo FindGrupo(int id);

        void AddGrupo(int id, string nombre);

        void UpdateGrupo(int id, string nombre);

        void RemoveGrupo(Grupo grupo);

        bool GrupoExists(int id);

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

        #region Grupo
        public IEnumerable<Grupo> AllGrupos()
        {
            return _ctx.Grupos.AsEnumerable();
        }

        public Grupo FindGrupo(int id)
        {
            return _ctx.Grupos.Find(id);
        }

        public void AddGrupo(int id, string nombre)
        {
            throw new NotImplementedException();
        }

        public void UpdateGrupo(int id, string nombre)
        {
            throw new NotImplementedException();
        }

        public void RemoveGrupo(Grupo grupo)
        {
            throw new NotImplementedException();
        }

        public bool GrupoExists(int id)
        {
            return _ctx.Grupos.Count(e => e.Id == id) > 0;
        }
        #endregion

        #region ComplejosOLD
        public IQueryable<Complejo> GetComplejos()
        {
            return _ctx.Complejos.Where(e => e.Canchas.Count > 0).AsQueryable();
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
        #endregion

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

    }


}
