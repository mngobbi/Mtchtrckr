namespace MatchTrakr.Data.Migrations
{
    using System;
    using MatchTrakr.Data.Entities;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MatchTrakr.Data.MatchTrakrContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MatchTrakr.Data.MatchTrakrContext context)
        {

            context.Complejos.AddOrUpdate(
                new Complejo { Nombre = "Complejo 62", FechaAlta = DateTime.Today },
                new Complejo { Nombre = "La posta", FechaAlta = DateTime.Today });

            foreach (var c in context.Complejos)
            {
                context.Canchas.AddOrUpdate(
                    new Cancha { Nombre = "Cancha1", Complejo = c, DeltaMinutos = 60, HoraInicio = DateTime.Today.AddHours(12), HoraFin = DateTime.Today },
                    new Cancha { Nombre = "Cancha2", Complejo = c, DeltaMinutos = 60, HoraInicio = DateTime.Today.AddHours(12), HoraFin = DateTime.Today });
            }

            foreach (var ch in context.Canchas)
            {
                DateTime fecha = DateTime.Today.AddHours(12);
                for (int i = 0; i <= 11; i++)
                {
                    context.Reservas.AddOrUpdate(new Reserva { Cancha = ch, FechaHora = fecha });
                }
            }
        }
    }
}
