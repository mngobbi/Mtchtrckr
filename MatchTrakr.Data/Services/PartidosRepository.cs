using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchTrakr.Data.Entities;

namespace MatchTrakr.Data.Services
{
    public class PartidosRepository : BaseService<Partido>
    {
        public PartidosRepository(MatchTrakrContext ctx) : 
            base(ctx)
        {

        }
    }

}
