using EfSamurai.Data;
using EfSamurai.Domain;
using System;

namespace EfSamurai.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //ClearDatabase();
            AddOneSamurai();
        }

        private static void ClearDatabase() //Fråga: hur tänka när man ska veta vilka man behöver ta bort?
        {
            var context = new SamuraiContext();

            foreach (var samurai in context.Samurais)
            {
                context.Remove(samurai);
            }

            foreach (var haircut in context.Haircuts)
            {
                context.Remove(haircut);
            }

            foreach (var quote in context.Quotes)
            {
                context.Remove(quote);
            }

            foreach (var quoteType in context.QuoteTypes)
            {
                context.Remove(quoteType);
            }

            foreach (var battle in context.Battles)
            {
                context.Remove(battle);
            }

            context.SaveChanges();
        }

        private static void AddOneSamurai()
        {
            var samurai = new Samurai { Name = "Zelda" };

            var context = new SamuraiContext();
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }
    }
}
