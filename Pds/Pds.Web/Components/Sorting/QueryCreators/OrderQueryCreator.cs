using Pds.Api.Contracts.Paging;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Pds.Web.Components.Sorting.QueryCreators
{
    public class OrderQueryCreator<T, TField> where T : class 
                                              where TField : Enum
    {
        private readonly Dictionary<TField, IOrderQuery<T, T>> queryCreators;

        public OrderQueryCreator(Dictionary<TField, IOrderQuery<T, T>> queryCreators)
        {
            this.queryCreators = queryCreators;
        }

        public IQueryable<T> Create(OrderSetting<TField>[] orderSettings, IQueryable<T> query)
        {
            var selector = queryCreators[orderSettings[0].FieldName];
            var orderedQuery = selector.CreateOrderBy(query, orderSettings[0].Ascending);

            foreach (var orderSetting in orderSettings.Skip(1))
            {
                selector = queryCreators[orderSetting.FieldName];
                orderedQuery = selector.CreateThenBy(orderedQuery, orderSetting.Ascending);
            }

            query = orderedQuery;
            return query;
        }
    }
}
