using System;
using System.Collections.Generic;
using System.Text;

namespace EfSamurai.Domain
{
    public class SecretIdentity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Samurai Samurai { get; set; }
        public int SamuraiForeignKey { get; set; }
    }
}
