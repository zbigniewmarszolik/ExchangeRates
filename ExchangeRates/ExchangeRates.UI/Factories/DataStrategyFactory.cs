using Autofac.Features.Indexed;
using ExchangeRates.Domain.Entities;
using ExchangeRates.UI.Enums;
using ExchangeRates.UI.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExchangeRates.UI.Factories
{
    public class DataStrategyFactory
    {
        private IDataStrategy _dataStrategy { get; set; }
        private IIndex<EDataType, IDataStrategy> _strategies { get; set; }

        public DataStrategyFactory(IIndex<EDataType, IDataStrategy> strategies)
        {
            _strategies = strategies;
        }

        public IDataStrategy CreateDataStrategy(IList<CurrencyEntity> currencyDataSet)
        {
            var type = SelectDataStrategy(currencyDataSet);

            return _strategies[type];
        }

        private EDataType SelectDataStrategy(IList<CurrencyEntity> currencyDataSet)
        {
            if (currencyDataSet != null && currencyDataSet.Count > 0)
            {
                var lastEntity = currencyDataSet.Last();

                var presentTime = DateTime.Now;
                var yesterdayTime = presentTime.AddDays(-1);
                var centralRefreshTime = new TimeSpan(17, 0, 0);

                if (lastEntity.LocalSavedDate.ToLocalTime().DayOfYear == presentTime.DayOfYear && lastEntity.LocalSavedDate.ToLocalTime().Year == presentTime.Year)
                {
                    if (TimeSpan.Compare(presentTime.TimeOfDay, centralRefreshTime) == 1)
                    {
                        if (TimeSpan.Compare(lastEntity.LocalSavedDate.ToLocalTime().TimeOfDay, centralRefreshTime) < 1)
                        {
                            return EDataType.InternetData;
                        }

                        else return EDataType.DatabaseData;
                    }

                    else return EDataType.DatabaseData;
                }

                else if (lastEntity.LocalSavedDate.ToLocalTime().DayOfYear == yesterdayTime.DayOfYear && lastEntity.LocalSavedDate.ToLocalTime().Year == yesterdayTime.Year)
                {
                    if (TimeSpan.Compare(presentTime.TimeOfDay, centralRefreshTime) < 1)
                    {
                        if (TimeSpan.Compare(lastEntity.LocalSavedDate.ToLocalTime().TimeOfDay, centralRefreshTime) == 1)
                        {
                            return EDataType.DatabaseData;
                        }

                        else return EDataType.InternetData;
                    }

                    else return EDataType.InternetData;
                }

                else return EDataType.InternetData;
            }

            else return EDataType.InternetData;
        }
    }
}
