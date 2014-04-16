namespace MatchTrakr.Data.Migrations
{
    using System;
    using MatchTrakr.Data.Entities;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<MatchTrakr.Data.MatchTrakrContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private bool AddUser(MatchTrakrContext context)
        {
            IdentityResult identityResult;
            UserManager<Usuario> userManager = new UserManager<Usuario>(new UserStore<Usuario>(context));
            var user = new Usuario()
            {
                UserName = "admin",
                FechaAlta = DateTime.Now
            };
            if (userManager.FindByName(user.UserName) != null)
            {
                return true;
            }
            identityResult = userManager.Create(user, "password");
            return identityResult.Succeeded;
        }

        protected override void Seed(MatchTrakrContext context)
        {
            AddUser(context);

            List<Complejo> complejos = new List<Complejo>();
            List<Cancha> canchas;

            complejos.Add(new Complejo { Nombre = "Complejo 62", FechaAlta = DateTime.Today });
            complejos.Add(new Complejo { Nombre = "La posta", FechaAlta = DateTime.Today });

            foreach (var comp in complejos)
            {
                context.Complejos.AddOrUpdate(comp);

                canchas = new List<Cancha>();
                canchas.Add(new Cancha { Nombre = "Cancha1", Complejo = comp, DeltaMinutos = 60, HoraInicio = DateTime.Today.AddHours(12), HoraFin = DateTime.Today.AddHours(23) });
                canchas.Add(new Cancha { Nombre = "Cancha2", Complejo = comp, DeltaMinutos = 60, HoraInicio = DateTime.Today.AddHours(12), HoraFin = DateTime.Today.AddHours(23) });
                foreach (var c in canchas)
                {
                    context.Canchas.AddOrUpdate(c);

                    DateTime fecha = DateTime.Today.AddHours(12);
                    for (int i = 0; i <= 10; i++)
                    {
                        context.Reservas.AddOrUpdate(new Reserva { Cancha = c, FechaHora = fecha });
                        fecha = fecha.AddHours(1);
                    }
                }
            }

        }
    }
}
