using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Tests
{
    public class Tests
    {
        public IWebDriver Driver { get; set; }

        [SetUp]
        public void Setup()
        {
            //TODO add chrome options new ChromeOptions()
            Driver = new ChromeDriver(Environment.CurrentDirectory);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
            Driver.Quit();//TODO google difference
        }

        [Test]
        public void Test1()
        {
            //arrange
            var uri = new Uri("https://google.com.ua");

            //act

            Driver.Navigate().GoToUrl(uri);
            IWebElement searchInput = Driver.FindElement(By.XPath("//input[contains(@class,'gLFyf')]"));
            searchInput.SendKeys("github");
            searchInput.SendKeys(Keys.Enter);
            //assert
            //Assert.Pass();
            string result = Driver.FindElement(By.CssSelector(".TbwUpd")).Text;
           // Assert.AreEqual("github", "github.com");
            StringAssert.Contains("github",result);

        } 
    

     
    }
}