using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverScrapingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize the Chrome driver
            using (var driver = new ChromeDriver())
            {
                //Go to the homepage
                driver.Navigate().GoToUrl("http://testing-ground.scraping.pro/login");

                //Get the page elements
                var userNameField = driver.FindElementById("usr");
                var userPasswordField = driver.FindElementById("pwd");
                var loginButton = driver.FindElementByXPath("//input[@value='Login']");
                //*[@id="case_login"]/form/input[3]

                //Type username and password
                userNameField.SendKeys("admin");
                userPasswordField.SendKeys("12345");

                //and click the login button
                loginButton.Click();

                //Extract the text and save it into result.txt
                var result = driver.FindElementByXPath("//div[@id='case_login']/h3").Text;
                File.WriteAllText("result.txt", result);

                //Take a screenshot and save it into screen.png
                driver.GetScreenshot().SaveAsFile(@"screen.png", ScreenshotImageFormat.Png);
            }
        }
    }
}
