using System.Collections.Generic;
using OpenQA.Selenium;
using CompareAppProject.Models;
using System;
using System.Linq;
using OpenQA.Selenium.Support.UI;

namespace CompareAppProject.Managers
{
    public class ComparisonManager : ManagerBase
    {
        public ComparisonManager(ApplicationManager manager) : base(manager) { }

        public List<Product> GetProductList()
        {
            WaitUntilElementsArePresent(By.ClassName("product"));
            List<Product> products = new List<Product>();
            foreach (IWebElement element in Driver.FindElements(By.ClassName("product")))
            {
                products.Add(new Product(
                    element.FindElement(By.ClassName("product_name")).Text,
                    element.FindElement(By.ClassName("product_price")).Text,
                    element.FindElement(By.CssSelector("p")).Text
                    ));
            }

            return products;
        }
        WebDriverWait wait;
        private void WaitUntilElementsArePresent(By by)
        {
            if (wait == null)
                wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 5));

            //wait.Until(driver);
            wait.Until(d => d.FindElement(by));
        }

        internal List<Product> GetComparedProducts()
        {
            WaitUntilElementsArePresent(By.TagName("table"));
            List<Product> products = new List<Product>();
            IWebElement cTable = Driver.FindElement(By.TagName("table"));
            products.Add(new Product(
                  (cTable.FindElement(By.ClassName("thead-default"))).FindElements(By.TagName("th"))[1].Text,
                  (cTable.FindElement(By.ClassName("price"))).FindElements(By.TagName("td"))[0].Text
                  ));

            products.Add(new Product(
                   (cTable.FindElement(By.ClassName("thead-default"))).FindElements(By.TagName("th"))[2].Text,
                   (cTable.FindElement(By.ClassName("price"))).FindElements(By.TagName("td"))[1].Text
                   ));


            return products;
        }

        internal void SelectProductsForComparison(List<Product> products)
        {
            SelectProduct(products.ElementAt(0));
            SelectProduct(products.ElementAt(1));
        }

        private void SelectProduct(Product p)
        {
            IWebElement pEl = Driver.FindElement(By.XPath(String.Format("//span[@class='product_name' and text()='{0}']", p.Name)));
            IWebElement CompareButton = (pEl.FindElement(By.XPath("../../.."))).FindElement(By.ClassName("view_details"));
            CompareButton.Click();
        }
    }
    
}
