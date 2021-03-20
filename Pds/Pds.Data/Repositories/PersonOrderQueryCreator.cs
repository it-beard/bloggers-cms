using System.Collections.Generic;
using System.Linq;
using Pds.Data.Entities;

namespace Pds.Data.Repositories
{
    public class PersonOrderQueryCreator
    {
        private readonly Dictionary<PersonsFieldName, IOrderQuery<Person>> queryCreators;

        public PersonOrderQueryCreator(Dictionary<PersonsFieldName, IOrderQuery<Person>> queryCreators)
        {
            this.queryCreators = queryCreators;
        }
        
        public IQueryable<Person> Create(OrderSetting<PersonsFieldName>[] orderSettings, IQueryable<Person> query)
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