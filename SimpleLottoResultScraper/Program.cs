using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLottoResultScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize the Chrome driver
            using (var driver = new ChromeDriver())
            {
                //Set delay
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                
                //Go to the homepage
                driver.Navigate().GoToUrl("http://www.pcso.gov.ph/games/search-lotto-results/");

                //Get the page elements
                //var userNameField = driver.FindElementById("usr");
                //var userPasswordField = driver.FindElementById("pwd");
                //var loginButton = driver.FindElementByXPath("//input[@value='Login']");

                //Type username and password
                //userNameField.SendKeys("admin");
                //userPasswordField.SendKeys("12345");

                //and click the login button
                //loginButton.Click();

                //Extract the text and save it into result.txt
                //var result = driver.FindElementByXPath("//*[@id=\"GridView1\"]").Text;
                //var result = driver.FindElementByXPath("//*[@id=\"search - lotto\"]/div[2]").Text;
                driver.SwitchTo().Frame(driver.FindElement(By.Id("form-iframe")));
                var result = driver.FindElementById("GridView1").Text;
                //driver.SwitchTo().DefaultContent();
                File.WriteAllText("result.txt", result);

                //Take a screenshot and save it into screen.png
                driver.GetScreenshot().SaveAsFile(@"screen.png", ScreenshotImageFormat.Png);
            }
        }
    }
}
