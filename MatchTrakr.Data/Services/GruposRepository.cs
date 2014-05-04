using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchTrakr.Data.Entities;

namespace MatchTrakr.Data.Services
{
    public class GruposRepository : BaseService<Grupo>
    {
        public GruposRepository(MatchTrakrContext ctx)
            : base(ctx)
        {
           
        }

        public bool Exists(int id) {
            if (Find(e => e.Id == id) != null)
            {
                return true;
            } else {
                return false;
            }
        }
    }
}
