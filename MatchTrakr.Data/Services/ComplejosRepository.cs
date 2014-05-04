using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchTrakr.Data.Entities;

namespace MatchTrakr.Data.Services
{
    public class ComplejosRepository: BaseService<Complejo>
    {
        public ComplejosRepository(MatchTrakrContext ctx):
            base(ctx)
        {

        }
    }
}
