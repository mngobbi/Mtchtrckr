﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTrakr.Data
{
    class MatchTrakrContextMigrationConfiguration : DbMigrationsConfiguration<MatchTrakrContext>
    {
        public MatchTrakrContextMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;

        }

    }
}
