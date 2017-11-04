using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace CopyWebText
{
    

    [TestClass]
    public class UnitTest1
    {

        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            //driver = new FirefoxDriver();
            driver = new InternetExplorerDriver();
        }

        [TestMethod]
        public void TestMethod1()
        {
            driver.Navigate().GoToUrl("http://localhost:8080");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //Clickin Manager button
            IWebElement manager = driver.FindElement(By.CssSelector("td.buttonNormal:nth-child(2)"));
            manager.Click();

            //logging in
            String OKButton = "#inputDialog > a:nth-child(3) > img:nth-child(1)";
            driver.FindElement(By.CssSelector("#inputDialogArea")).SendKeys("3");
            driver.FindElement(By.CssSelector(OKButton)).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#inputDialogArea")));
            driver.FindElement(By.CssSelector("#inputDialogArea")).SendKeys("3");
            driver.FindElement(By.CssSelector(OKButton)).Click();

            //select Terminal
            String selectTerminal = "tr.posInfoLine:nth-child(2) > td:nth-child(1) > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(1) > td:nth-child(1)";
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(selectTerminal)));
            driver.FindElement(By.CssSelector(selectTerminal)).Click();

            //click Product button
            String product = "#buttonsTable > tr:nth-child(1) > td:nth-child(3)";
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(product)));
            driver.FindElement(By.CssSelector("#buttonsTable > tr:nth-child(1) > td:nth-child(3)")).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#previewDialogMessage")));
            String report = driver.FindElement(By.CssSelector("#previewDialogMessage")).Text;
            System.IO.File.WriteAllText(@"C:\exported_text.txt", report);
        }
    }
}
