using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace AppiumSummatorTests
{
    public class SummatorAppiumTests
    {

        private WindowsDriver<WindowsElement> driver;
        private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";
        private AppiumOptions options;

        [SetUp]
        public void Setup()
        {
            this.options = new AppiumOptions() { PlatformName = "Windows" };
            options.AddAdditionalCapability(MobileCapabilityType.App, @"C:\SummatorDesktopApp.exe");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServer), options);
        }
        [TearDown]
        public void hutDown()
        {
           this.driver.Quit();
        }

        [Test]
        public void Test_SumTwoPositiveNumbers()
        {
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Click();
            num1.SendKeys("5");
            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Click();
            num2.SendKeys("15");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();
            var result = driver.FindElementByAccessibilityId("textBoxSum").Text;
            Assert.That(result, Is.EqualTo("20"));
        }
        [Test]
        public void Test_InputInvalidValues()
        {
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Click();
            num1.SendKeys("kjxk");
            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Click();
            num2.SendKeys("kjsol");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();
            var result = driver.FindElementByAccessibilityId("textBoxSum").Text;
            Assert.That(result, Is.EqualTo("error"));
        }
    }
}