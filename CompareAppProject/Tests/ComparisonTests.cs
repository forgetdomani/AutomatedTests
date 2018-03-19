using CompareAppProject.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CompareAppProject.Tests
{
    [TestFixture]
    class ComparisonTests    : TestBase
    {
        [Test]
        public void CompareFristTwoProducts() {
            List<Product> products = AppManager.Comparer.GetProductList();
            List<Product> products2Compare = new List<Product>() { products.ElementAt(0), products.ElementAt(1) };
            AppManager.Comparer.SelectProductsForComparison(products2Compare);
            List<Product> comparedProducts = AppManager.Comparer.GetComparedProducts();
            Assert.AreEqual(products2Compare, comparedProducts);
        }
    }
}
