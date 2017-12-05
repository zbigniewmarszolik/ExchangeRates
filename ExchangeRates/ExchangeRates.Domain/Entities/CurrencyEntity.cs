using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace ExchangeRates.Domain.Entities
{
    [Table("currencies")]
    public class CurrencyEntity
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Base { get; set; }
        public DateTime Date { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.CascadeInsert)]
        public List<RateEntity> Rates { get; set; }
    }
}
