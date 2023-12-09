using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;
namespace Laba5Podderzhka
{
    [TestFixture]
    public class SearchFilterTests
    {


        private IWebDriver driver;
        private SearchFilterPagecs searchFilterPage;

        [SetUp]
        public void Setup()
        {
            // Инициализация драйвера Selenium
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Переход на страницу поиска и фильтрации
            driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/SearchFilter/");

            // Инициализация объекта страницы поиска и фильтрации
            searchFilterPage = new SearchFilterPagecs(driver);
        }

        [TearDown]
        public void Teardown()
        {
            // Закрытие браузера и освобождение ресурсов
            driver.Quit();

        }



        [Test]
        public void SearchByAccountTest()
        {
            // Выбор значения "All Accounts" в поле поиска по аккаунту. по каждому cash bank
            searchFilterPage.SelectAccountSearchOption("Cash");

            // Проверка результатов поиска
            NUnit.Framework.Assert.IsTrue(searchFilterPage.AreSearchResultsDisplayed());

            // Получение результатов поиска
            List<SearchResult> searchResults = searchFilterPage.GetSearchResults();

            // Проверка, что каждый результат содержит аккаунт "cash"
            foreach (SearchResult result in searchResults)
            {
                NUnit.Framework.Assert.AreEqual("Cash", result.Account);
            }
        }
        [Test]
        public void SearchByAccountTestBank()
        {            
            List<SearchResult> sr = new() { 
                new SearchResult("1", "Bank Savings", "EXPENDITURE", "InternetBill", "500"),
                new SearchResult("2", "Bank Savings", "INCOME", "Salary", "5000")
            };

            // Выбор значения "All Accounts" в поле поиска по аккаунту. по каждому cash bank
            searchFilterPage.SelectAccountSearchOption("Bank Savings");

            // Проверка, что каждый результат содержит аккаунт "Bank Savings"
            List<SearchResult> searchResults = searchFilterPage.GetSearchResults();
            CollectionAssert.AreEquivalent(sr, searchResults);
            NUnit.Framework.Assert.IsTrue(searchFilterPage.AreSearchResultsDisplayed());
        }

        [Test]
        public void SearchByTypeTest()
        {
            // Выбор значения "EXPENDITURE" в поле поиска по типу
            searchFilterPage.SelectTypeSearchOption("EXPENDITURE");

            // Проверка результатов поиска
            NUnit.Framework.Assert.IsTrue(searchFilterPage.AreSearchResultsDisplayed());

            // Получение результатов поиска
            List<SearchResult> searchResults = searchFilterPage.GetSearchResults();

            // Проверка, что каждый результат имеет тип "EXPENDITURE"
            foreach (SearchResult result in searchResults)
            {
                NUnit.Framework.Assert.AreEqual("EXPENDITURE", result.Type);
            }
        }
        [Test]
        public void SearchByTypeTestINCOME()
        {
            // Выбор значения "EXPENDITURE" в поле поиска по типу
            searchFilterPage.SelectTypeSearchOption("INCOME");

            // Проверка результатов поиска
            NUnit.Framework.Assert.IsTrue(searchFilterPage.AreSearchResultsDisplayed());

            // Получение результатов поиска
            List<SearchResult> searchResults = searchFilterPage.GetSearchResults();

            // Проверка, что каждый результат имеет тип "EXPENDITURE"
            foreach (SearchResult result in searchResults)
            {
                NUnit.Framework.Assert.AreEqual("INCOME", result.Type);
            }
        }
        [Test]
        public void SearchByPayeeTest()
        {
            // Создание экземпляра класса страницы поиска
            SearchFilterPagecs searchFilterPage = new SearchFilterPagecs(driver);      

            List<SearchResult> sr = new() {
                new SearchResult("1","Cash","EXPENDITURE","HouseRent","1000"),
             
            };
            // Выбор значения "All Accounts" в поле поиска по аккаунту. по каждому cash bank
            searchFilterPage.EnterPayeeSearchText("HouseRent");

            // Проверка, что каждый результат содержит аккаунт "Bank Savings"
            List<SearchResult> searchResults = searchFilterPage.GetSearchResults();
            CollectionAssert.AreEquivalent(sr, searchResults);
            NUnit.Framework.Assert.IsTrue(searchFilterPage.AreSearchResultsDisplayed());
        }
        [Test]
        public void SearchByPayeeTest1()
        {
            // Создание экземпляра класса страницы поиска
            SearchFilterPagecs searchFilterPage = new SearchFilterPagecs(driver);

            List<SearchResult> sr = new() {
                new SearchResult("1","Bank Savings","EXPENDITURE","InternetBill","500"),
                 new SearchResult("2","Cash","EXPENDITURE","InternetBill","1200"),
            };
            // Выбор значения "All Accounts" в поле поиска по аккаунту. по каждому cash bank
            searchFilterPage.EnterPayeeSearchText("InternetBill");

            // Проверка, что каждый результат содержит аккаунт "Bank Savings"
            List<SearchResult> searchResults = searchFilterPage.GetSearchResults();
            CollectionAssert.AreEquivalent(sr, searchResults);
            NUnit.Framework.Assert.IsTrue(searchFilterPage.AreSearchResultsDisplayed());
        }
       



        [Test]
        public void SearchByPayeeTest31()
        {
            searchFilterPage.EnterPayeeSearchText("PowerBill");
            NUnit.Framework.Assert.IsTrue(searchFilterPage.AreSearchResultsDisplayed());

            List<SearchResult> sr = new() {
                new SearchResult("1","Cash","EXPENDITURE", "PowerBill","200"),
            };
       
            List<SearchResult> searchResults = searchFilterPage.GetSearchResults();
            CollectionAssert.AreEquivalent(sr, searchResults);
 
        }
    }
}


