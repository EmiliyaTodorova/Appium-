using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;
using SummatorAppiumTest_POM.Summator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummatorAppiumTest_POM.Tests
{
    class SummatorTests
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
        public void Test_SumTwoPositiveNumbers_POM()
        {
            var window = new SummatorWindows(driver);

            string field1 = "5";
            string field2 = "15";
            string result = window.Calculate(field1, field2);
            Assert.That(result, Is.EqualTo("20"));
        }
    }
}
