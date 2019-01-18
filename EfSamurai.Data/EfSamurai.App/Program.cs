using EfSamurai.Data;
using EfSamurai.Domain;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Design;


namespace EfSamurai.App
{
    class Program
    {
        static void Main(string[] args)
        {
            ClearDatabase();
            //AddOneSamurai();
            //AddSomeSamurais();
            //AddSomeBattles();
            //AddOneSamuraiWithRelatedData();

            ListAllSamuraiNames();
            ListAllSamuraiNames_OrderByName();
            ListAllSamuraiNames_OrderByIdDescending();

            QuoteType quoteType = new QuoteType { Name = "Lame" };
            ListAllQuotesOfType(quoteType);
            ListAllQuotesOfType_WithSamurai(quoteType);

        }

        private static void ListAllQuotesOfType_WithSamurai(QuoteType quoteType)
        {
            var dataAccess = new DataAccess();

            List<Quote> quotes = dataAccess.GetAllQuotesOfType_WithSamurai(quoteType);

            Console.WriteLine("QUOTES IN CATEGORY: " + quoteType.Name);

            foreach (var quote in quotes)
            {
                Console.WriteLine($"'{quote.Text}' is a quote by {quote.Samurai.Name}");
            }

            Console.WriteLine();
        }

        private static void ListAllQuotesOfType(QuoteType quoteType)
        {
            var dataAccess = new DataAccess();

            List<Quote> quotes = dataAccess.GetAllQuotesOfType(quoteType);

            Console.WriteLine("QUOTES IN CATEGORY: " + quoteType.Name);

            foreach (var quote in quotes)
            {
                Console.WriteLine(quote.Text);
            }

            Console.WriteLine();
        }

        private static void ListAllSamuraiNames_OrderByIdDescending()
        {
            var dataAccess = new DataAccess();

            List<Samurai> samurais = dataAccess.GetAllSamurais_OrderedByIdDescending();

            Console.WriteLine("SAMURAIS ORDERED BY ID DESCENDING");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Id.ToString().PadRight(5) + samurai.Name);
            }
            Console.WriteLine();
        }

        private static void ListAllSamuraiNames_OrderByName()
        {
            var dataAccess = new DataAccess();

            List<Samurai> samurais = dataAccess.GetAllSamurais_OrderedByName();

            Console.WriteLine("SAMURAIS ORDERED BY NAME");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
            Console.WriteLine();

        }

        private static void ListAllSamuraiNames()
        {
            var dataAccess = new DataAccess();

            List<Samurai> samurais = dataAccess.GetAllSamurais();

            Console.WriteLine("SAMURAIS");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
            Console.WriteLine();
        }

        private static void AddOneSamuraiWithRelatedData()
        {
            var context = new SamuraiContext();

            var haircut = new Haircut { Name = "Short" };
            var secretIdentity = new SecretIdentity { Name = "Harry Potter"};

            var quoteType = new QuoteType { Name = "Lame" };
            var listOfQuotes = new List<Quote> { new Quote { Text = "Friends come first", Type = quoteType }, new Quote { Text = "I'm a wizard", Type = quoteType } };

            var battleEvents = new List<BattleEvent>
            {
                new BattleEvent { Description = "The tribe GoronsFTW initiated the first attack", Summary = "The tribe GoronsFTW won this event", TimeOfEvent = new DateTime(1430,3,20) }
            };

            var battleLog = new BattleLog
            {
                Name = "Goron War log",
                BattleEvents = battleEvents
            };

            var battle1 = new Battle
            {
                Name = "The Goron War",
                Description = "The disagreements between the leaders of the Gorons eventually led to the civil war of the Gorons",
                Brutal = true,
                StartDate = new DateTime(1430, 3, 16),
                EndDate = new DateTime(1432, 5, 20),
                BattleLog = battleLog
            };

            List<Battle> samuraiBattles = new List<Battle>();
            samuraiBattles.Add(battle1);

            var samurai = new Samurai
            {
                Name = "Arnold",
                Haircut = haircut,
                SecretIdentity = secretIdentity,
                Quotes = listOfQuotes,
                Battles = samuraiBattles
            };

            context.Samurais.Add(samurai);

            var samuraiBattle = new SamuraiBattle
            {
                Samurai = samurai,
                Battle = battle1
            };

            context.SamuraiBattles.Add(samuraiBattle); //borde väl inte behöva göra detta manuellt? Får det att fungera iallafall
            context.SaveChanges();

        }

        private static void AddSomeBattles()
        {
            var context = new SamuraiContext();

            var battleEvents = new List<BattleEvent>
            {
                new BattleEvent { Description = "The tribe GoronsFTW initiated the first attack", Summary = "The tribe GoronsFTW won this event", TimeOfEvent = new DateTime(1430,3,20) }
            };

            var battleLog = new BattleLog
            {
                Name = "Goron War log",
                BattleEvents = battleEvents
            };

            var battle1 = new Battle
            {
                Name = "The Goron War",
                Description = "The disagreements between the leaders of the Gorons eventually led to the civil war of the Gorons",
                Brutal = true,
                StartDate = new DateTime(1430,3,16),
                EndDate = new DateTime(1432,5,20),
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
            //KOLLA VAD MAN SKA TA BORT CONSTRAINT FÖR ATT TA BORT 
            var context = new SamuraiContext();

            context.RemoveRange(context.Samurais);
            context.RemoveRange(context.Haircuts);
            context.RemoveRange(context.Quotes);
            context.RemoveRange(context.QuoteTypes);
            context.RemoveRange(context.Battles);
            context.RemoveRange(context.SamuraiBattles);
            context.RemoveRange(context.BattleLogs);
            context.RemoveRange(context.BattleEvents);

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
