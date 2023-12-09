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
            // ������������� �������� Selenium
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // ������� �� �������� ������ � ����������
            driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/SearchFilter/");

            // ������������� ������� �������� ������ � ����������
            searchFilterPage = new SearchFilterPagecs(driver);
        }

        [TearDown]
        public void Teardown()
        {
            // �������� �������� � ������������ ��������
            driver.Quit();

        }



        [Test]
        public void SearchByAccountTest()
        {
            // ����� �������� "All Accounts" � ���� ������ �� ��������. �� ������� cash bank
            searchFilterPage.SelectAccountSearchOption("Cash");

            // �������� ����������� ������
            NUnit.Framework.Assert.IsTrue(searchFilterPage.AreSearchResultsDisplayed());

            // ��������� ����������� ������
            List<SearchResult> searchResults = searchFilterPage.GetSearchResults();

            // ��������, ��� ������ ��������� �������� ������� "cash"
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

            // ����� �������� "All Accounts" � ���� ������ �� ��������. �� ������� cash bank
            searchFilterPage.SelectAccountSearchOption("Bank Savings");

            // ��������, ��� ������ ��������� �������� ������� "Bank Savings"
            List<SearchResult> searchResults = searchFilterPage.GetSearchResults();
            CollectionAssert.AreEquivalent(sr, searchResults);
            NUnit.Framework.Assert.IsTrue(searchFilterPage.AreSearchResultsDisplayed());
        }

        [Test]
        public void SearchByTypeTest()
        {
            // ����� �������� "EXPENDITURE" � ���� ������ �� ����
            searchFilterPage.SelectTypeSearchOption("EXPENDITURE");

            // �������� ����������� ������
            NUnit.Framework.Assert.IsTrue(searchFilterPage.AreSearchResultsDisplayed());

            // ��������� ����������� ������
            List<SearchResult> searchResults = searchFilterPage.GetSearchResults();

            // ��������, ��� ������ ��������� ����� ��� "EXPENDITURE"
            foreach (SearchResult result in searchResults)
            {
                NUnit.Framework.Assert.AreEqual("EXPENDITURE", result.Type);
            }
        }
        [Test]
        public void SearchByTypeTestINCOME()
        {
            // ����� �������� "EXPENDITURE" � ���� ������ �� ����
            searchFilterPage.SelectTypeSearchOption("INCOME");

            // �������� ����������� ������
            NUnit.Framework.Assert.IsTrue(searchFilterPage.AreSearchResultsDisplayed());

            // ��������� ����������� ������
            List<SearchResult> searchResults = searchFilterPage.GetSearchResults();

            // ��������, ��� ������ ��������� ����� ��� "EXPENDITURE"
            foreach (SearchResult result in searchResults)
            {
                NUnit.Framework.Assert.AreEqual("INCOME", result.Type);
            }
        }
        [Test]
        public void SearchByPayeeTest()
        {
            // �������� ���������� ������ �������� ������
            SearchFilterPagecs searchFilterPage = new SearchFilterPagecs(driver);      

            List<SearchResult> sr = new() {
                new SearchResult("1","Cash","EXPENDITURE","HouseRent","1000"),
             
            };
            // ����� �������� "All Accounts" � ���� ������ �� ��������. �� ������� cash bank
            searchFilterPage.EnterPayeeSearchText("HouseRent");

            // ��������, ��� ������ ��������� �������� ������� "Bank Savings"
            List<SearchResult> searchResults = searchFilterPage.GetSearchResults();
            CollectionAssert.AreEquivalent(sr, searchResults);
            NUnit.Framework.Assert.IsTrue(searchFilterPage.AreSearchResultsDisplayed());
        }
        [Test]
        public void SearchByPayeeTest1()
        {
            // �������� ���������� ������ �������� ������
            SearchFilterPagecs searchFilterPage = new SearchFilterPagecs(driver);

            List<SearchResult> sr = new() {
                new SearchResult("1","Bank Savings","EXPENDITURE","InternetBill","500"),
                 new SearchResult("2","Cash","EXPENDITURE","InternetBill","1200"),
            };
            // ����� �������� "All Accounts" � ���� ������ �� ��������. �� ������� cash bank
            searchFilterPage.EnterPayeeSearchText("InternetBill");

            // ��������, ��� ������ ��������� �������� ������� "Bank Savings"
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


