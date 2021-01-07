using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowSeleniumDemo6.Steps

{
    public class SearchKeyWord
    {
        public string SearchText { get; set; }
    }
    [Binding]
    public class GoogleSearchSteps
    {
        IWebDriver driver;
        [Given(@"I have navigated to google page")]
        public void GivenIHaveNavigatedToGooglePage()
        {
            try
            {
                driver = new ChromeDriver();
                driver.Url = "https://www.google.com/";
            }
            catch (Exception )
            {
                Console.WriteLine("Exception");
            }
            Console.WriteLine("Test Successfully completed");
        }
        
        [Given(@"I see the google page fully loaded")]
        public void GivenISeeTheGooglePageFullyLoaded()
        {
           if (driver.FindElement(By.Name("q")).Displayed)
                Console.WriteLine("Page fully loaded");
            else
            {
                Console.WriteLine("Page not loaded");
            }
            Assert.IsTrue(driver.FindElement(By.Name("q")).Displayed, "Page not loaded");
        }

        [When(@"I type the search keyword as")]
        public void WhenITypeTheSearchKeywordAs(Table table)
        {
           
            var searchkey = table.CreateInstance<SearchKeyWord>();           
            var element = driver.FindElement(By.Name("q"));
            element.SendKeys(searchkey.SearchText);
            element.SendKeys(Keys.Enter);
            Console.WriteLine("Searched by Keyword");
        }

        [Then(@"I should see result for keyword")]
        public void ThenIShouldSeeResultForKeyword(Table table)
        {
            var searchkey = table.CreateInstance<SearchKeyWord>();
            Assert.IsTrue(driver.FindElement(By.PartialLinkText(searchkey.SearchText)).Displayed, "No Search Results");            
        }
    }
   
}
