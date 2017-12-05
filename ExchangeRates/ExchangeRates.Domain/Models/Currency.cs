using System;
using System.Collections.Generic;

namespace ExchangeRates.Domain.Models
{
    public class Currency
    {
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
    }
}
