using System;
using System.Collections.Generic;

namespace EfSamurai.Domain
{
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Haircut Haircut { get; set; }
        public SecretIdentity SecretIdentity { get; set; }

        public List<Quote> Quotes { get; set; }
    }
}
