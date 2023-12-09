using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5Podderzhka
{
    public class SearchFilterPagecs
    {
        private IWebDriver driver;
        private IWebElement payeeSearchInput;
        private IWebElement accountSearchSelect;
        private IWebElement typeSearchSelect;
        private IWebElement searchResultsTable;
        private IWebElement expenditurePayeesLink;

        public SearchFilterPagecs(IWebDriver driver)
        {
            this.driver = driver;
            payeeSearchInput = driver.FindElement(By.XPath("//input[@placeholder='Payee Name']"));
            accountSearchSelect = driver.FindElement(By.XPath("//select[@ng-model='filterTxn.account']"));
            typeSearchSelect = driver.FindElement(By.XPath("//select[@ng-model='filterTxn.txnType']"));
            searchResultsTable = driver.FindElement(By.XPath("//table[@class='table table-striped table-bordered']"));
            expenditurePayeesLink = driver.FindElement(By.Id("input4"));
        }

        public void EnterPayeeSearchText(string searchText)
        {
            payeeSearchInput.Clear();
            payeeSearchInput.SendKeys(searchText);
        }

        public void SelectAccountSearchOption(string optionValue)
        {
            accountSearchSelect.SendKeys(optionValue);
        }

        public void SelectTypeSearchOption(string optionValue)
        {
            typeSearchSelect.SendKeys(optionValue);
        }

        public void GoToExpenditurePayeesPage()
        {
            expenditurePayeesLink.Click(); // должен быть ввод текса
        }

        public bool AreSearchResultsDisplayed()
        {
            return searchResultsTable.Displayed;
        }

        public List<SearchResult> GetSearchResults()
        {
            List<SearchResult> results = new List<SearchResult>();

            // Получение строк результатов поиска
            var rows = searchResultsTable.FindElements(By.XPath(".//tbody/tr"));

            // Извлечение данных из строк результатов и добавление их в список результатов
            foreach (var row in rows)
            {
                var cells = row.FindElements(By.XPath(".//td"));
                string num = cells[0].Text; // не нужен
                string account = cells[1].Text;
                string type = cells[2].Text;
                string payee = cells[3].Text;
                string amount = cells[4].Text;

                results.Add(new SearchResult(num,account, type, payee, amount));
            }

            return results;
        }
    }
}
