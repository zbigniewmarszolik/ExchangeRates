using System.Collections.Generic;
using System.Linq;

namespace ExchangeRates.UI.Helpers
{
    public class CurrencyDescriptionHelper
    {
        private Dictionary<string, string> _currenciesDictionary { get; set; }

        public CurrencyDescriptionHelper()
        {
            _currenciesDictionary = new Dictionary<string, string>();

            SetupDictionary();
        }

        public string ResolveDescription(string currencyNameShortcut)
        {
            return _currenciesDictionary.FirstOrDefault(x => x.Key == currencyNameShortcut).Value;
        }

        private void SetupDictionary()
        {
            _currenciesDictionary.Add("USD", "United States dollar");
            _currenciesDictionary.Add("JPY", "Japanese yen");
            _currenciesDictionary.Add("BGN", "Bulgarian lev");
            _currenciesDictionary.Add("CZK", "Czech koruna");
            _currenciesDictionary.Add("DKK", "Danish krone");
            _currenciesDictionary.Add("GBP", "Pound sterling");
            _currenciesDictionary.Add("HUF", "Hungarian forint");
            _currenciesDictionary.Add("PLN", "Polish zloty");
            _currenciesDictionary.Add("RON", "Romanian leu");
            _currenciesDictionary.Add("SEK", "Swedish krona");
            _currenciesDictionary.Add("CHF", "Swiss franc");
            _currenciesDictionary.Add("NOK", "Norwegian krone");
            _currenciesDictionary.Add("HRK", "Croatian kuna");
            _currenciesDictionary.Add("RUB", "Russian rouble");
            _currenciesDictionary.Add("TRY", "Turkish lira");
            _currenciesDictionary.Add("AUD", "Australian dollar");
            _currenciesDictionary.Add("BRL", "Brazilian real");
            _currenciesDictionary.Add("CAD", "Canadian dollar");
            _currenciesDictionary.Add("CNY", "Chinese yuan renminbi");
            _currenciesDictionary.Add("HKD", "Hong Kong dollar");
            _currenciesDictionary.Add("IDR", "Indonesian rupiah");
            _currenciesDictionary.Add("ILS", "Israeli shekel");
            _currenciesDictionary.Add("INR", "Indian rupee");
            _currenciesDictionary.Add("KRW", "South Korean won");
            _currenciesDictionary.Add("MXN", "Mexican peso");
            _currenciesDictionary.Add("MYR", "Malaysian ringgit");
            _currenciesDictionary.Add("NZD", "New Zealand dollar");
            _currenciesDictionary.Add("PHP", "Philippine piso");
            _currenciesDictionary.Add("SGD", "Singapore dollar");
            _currenciesDictionary.Add("THB", "Thai baht");
            _currenciesDictionary.Add("ZAR", "South African rand");
            _currenciesDictionary.Add("ISK", "Icelandic krona - The last rate was published on 03/12/2008");
        }
    }
}
