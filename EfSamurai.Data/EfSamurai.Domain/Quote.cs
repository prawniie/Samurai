﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EfSamurai.Domain
{
    public class Quote
    {
        public int Id { get; set; }
        public QuoteType Type { get; set; }
        public Samurai Samurai { get; set; }

    }
}
