using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummatorAppiumTest_POM.Summator
{
    
    class SummatorWindows
    {
        private readonly WindowsDriver<WindowsElement> driver;
        public SummatorWindows(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }
        public WindowsElement num1 => driver.FindElementByAccessibilityId("textBoxFirstNum");
        public WindowsElement num2 => driver.FindElementByAccessibilityId("textBoxSecondNum");
        public WindowsElement calcButton => driver.FindElementByAccessibilityId("buttonCalc");
        public WindowsElement result => driver.FindElementByAccessibilityId("textBoxSum");

        public string Calculate (string field1, string field2)
        {
            num1.Click();
            num1.SendKeys(field1);
            num2.Click();
            num2.SendKeys(field2);
            calcButton.Click();
            return result.Text;
        }

    }
}
