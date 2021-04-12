using Pds.Api.Contracts.Person;
using Pds.Api.Contracts.Paging;
using System.Collections.Generic;
using System.Linq;


namespace Pds.Web.Components.Sorting.QueryCreators.Person
{
    public class PersonOrderQueryCreator
    {
        private readonly Dictionary<PersonsFieldName, IOrderQuery<PersonDto>> queryCreators;

        public PersonOrderQueryCreator(Dictionary<PersonsFieldName, IOrderQuery<PersonDto>> queryCreators)
        {
            this.queryCreators = queryCreators;
        }
        
        public IQueryable<PersonDto> Create(OrderSetting<PersonsFieldName>[] orderSettings, IQueryable<PersonDto> query)
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