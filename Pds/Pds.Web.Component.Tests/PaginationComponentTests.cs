using NUnit.Framework;
using Pds.Web.Components;
using System.Linq;

namespace Pds.Web.ComponentsTests
{
    public class PaginationComponentTests
    {
        [TestCase(new int[] { -5, 5, 10, 25, 50 }, 5, 90)] //with negative value, expected value = 5, expected sum = 90
        [TestCase(new int[] { 0, 5, 25, 50 }, 5, 80)] //with 0 value, expected value = 5, expected sum = 80
        [TestCase(new int[] { 0, 5, -10, 25, 0, 50 }, 5, 80)] //with 0 and negative value value, expected value = 5, expected sum = 80
        [TestCase(new int[] { }, 10, 10)] //is empty, expected value = 10, expected sum = 10
        [TestCase(new int[] { 5, 10, 25, 50 }, 5, 90)] //normal, expected value = 5,
        public void CheckInputParameterPageSizeList_ShouldReturnNonNegativValuesOrDefault(int[] parameter, int expectedValue, int expectedSum)
        {

            var pagination = new PagingComponentBase
            {
                PageSizeList = parameter
            };

            var pageSize = pagination.PageSizeList[0];

            Assert.AreEqual(expectedValue, pageSize);
            Assert.AreEqual(expectedSum, pagination.PageSizeList.Sum());
        }

        [TestCase(null, 2)] //null, expected value = 2
        [TestCase(0, 2)] //with 0, expected value = 2
        [TestCase(-1, 2)] //with negative value, expected value = 2
        [TestCase(3, 3)] //normal, expected value = 3
        public void CheckInputParameterRadius_ShouldSetValueOrSetDefaultParameters(int? value, int expectedValue)
        {

            var pagination = new PagingComponentBase();

            pagination.Radius = value;

            var radius = pagination.Radius;

            Assert.AreEqual(expectedValue, radius);
        }

        [TestCase(null, 0)] //null, expected value = 0
        [TestCase(0, 0)] //with 0, expected value = 0
        [TestCase(-10, 0)] //with negative value, expected value = 0
        [TestCase(100, 100)] //normal, expected value = 100
        public void CheckInputParameterTotalItems_ShouldSetValueOrSetDefaultValue(int? value, int expectedValue)
        {
            var pagination = new PagingComponentBase();
            pagination.TotalItems = value;

            var totalItems = pagination.TotalItems;

            Assert.AreEqual(expectedValue, totalItems);
        }
    }
}