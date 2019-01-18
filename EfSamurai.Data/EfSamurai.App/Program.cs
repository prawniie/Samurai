using EfSamurai.Data;
using EfSamurai.Domain;
using System;
using System.Collections.Generic;

namespace EfSamurai.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //ClearDatabase();
            AddOneSamurai();
            AddSomeSamurais();
            AddSomeBattles();
        }

        private static void AddSomeBattles()
        {
            var context = new SamuraiContext();

            var battleEvents = new List<BattleEvent>
            {
                new BattleEvent { Description = "The leader Goron initiated the first attack", TimeOfEvent = new DateTime(900,1,20) }
            };

            var battleLog = new BattleLog
            {
                Name = "Goron War log",
                BattleEvents = battleEvents
            };

            var battle1 = new Battle
            {
                Name = "The Goron War",
                BattleLog = battleLog
            };

            context.Battles.Add(battle1);
            context.SaveChanges();

        }

        private static void AddSomeSamurais()
        {
            var context = new SamuraiContext();

            var samurai1 = new Samurai { Name = "Link" };
            var samurai2 = new Samurai { Name = "Ganondorf" };
            var samurai3 = new Samurai { Name = "Midna" };

            context.Samurais.AddRange(samurai1, samurai2, samurai3);
            context.SaveChanges();
        }

        private static void ClearDatabase() //Fråga: hur tänka när man ska veta vilka man behöver ta bort?
        {
            //MÅSTE TA HAND OM CONSTRAINT FÖR ATT TA BORT 
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
