using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ExchangeRates.Domain.Entities
{
    [Table("rates")]
    public class RateEntity
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string CurrencyName { get; set; }
        public decimal CurrencyRate { get; set; }

        [ManyToOne]
        public CurrencyEntity Currency { get; set; }

        [ForeignKey(typeof(CurrencyEntity))]
        public int CurrencyId { get; set; }
    }
}
