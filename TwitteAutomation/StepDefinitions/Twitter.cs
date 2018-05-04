using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace TwitteAutomation.StepDefinitions
{
    [Binding]
    public sealed class Twitter
    {
        IWebDriver driver;

        [StepDefinition(@"I open Twitter application")]
        public void GivenIOpenTwitterApplication()
        {
            driver = new ChromeDriver();
            driver.Url = "https://twitter.com/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5000);
            driver.Manage().Window.Maximize();
            Console.WriteLine("Maximized Browser");
        }

        [StepDefinition(@"I Enter valid Username")]
        public void WhenIEnterValidUsername()
        {
            driver.FindElement(By.XPath("//a[contains(@class,'StaticLoggedOutHomePage-buttonLogin')]")).Click();
            driver.FindElement(By.XPath("//input[contains(@class,'js-username-field')]")).SendKeys("");
        }

        [StepDefinition(@"I Enter valid Password")]
        public void WhenIEnterValidPassword()
        {
            driver.FindElement(By.XPath("//input[contains(@class,'js-password-field')]")).SendKeys("");
        }

        [When(@"I Enter valid Username as ""(.*)""")]
        public void WhenIEnterValidUsernameAs(string userName)
        {
            driver.FindElement(By.XPath("//a[contains(@class,'StaticLoggedOutHomePage-buttonLogin')]")).Click();
            //Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[contains(@class,'js-username-field')]")).SendKeys(userName);
        }

        [When(@"I Enter valid Password as ""(.*)""")]
        public void WhenIEnterValidPasswordAs(string password)
        {
            driver.FindElement(By.XPath("//input[contains(@class,'js-password-field')]")).SendKeys(password);
        }


        [StepDefinition(@"I click on Login button")]
        public void WhenIClickOnLoginButton()
        {
            driver.FindElement(By.XPath("//button[text()='Log in']")).Click();
        }

        [StepDefinition(@"I verify login is successfull")]
        public void ThenIVerifyLoginIsSuccessfull()
        {
            string userNameText = driver.FindElement(By.XPath("//a[contains(@class,'DashboardProfileCard')]/span[contains(@class,'username u-dir')]")).Text;
            Assert.True(userNameText.Equals("@GvsBharadwaja"), "Username does not match, hence failed");
        }

        [StepDefinition(@"I Enter Tweet as ""(.*)""")]
        public void WhenIEnterTweetAs(string Tweet)
        {
            driver.FindElement(By.XPath("//div[contains(@id,'tweet-box-home-timeline')]")).SendKeys(Tweet);
        }

        [StepDefinition(@"Click Tweet")]
        public void WhenClickTweet()
        {
            driver.FindElement(By.XPath("(//button[contains(@class,'tweet-action')])[1]")).Click();
            Thread.Sleep(2000);
        }

        [StepDefinition(@"I verify tweet ""(.*)"" is posted")]
        public void ThenIVerifyTweetIsPosted(string TweetText)
        {
            string actualTweetText = driver.FindElement(By.XPath("//div[@data-name='gvs bharadwaja']//p[contains(@class,'tweet-text')]")).Text.Trim();
            Assert.True(TweetText.Equals(actualTweetText), "Tweet is NOT posted successfully, hence failed.");
        }


    }
}
