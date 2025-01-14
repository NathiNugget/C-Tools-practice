using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics.CodeAnalysis;

namespace htmltest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public sealed class Test1
    {
        private static WebDriver driver;
        [TestInitialize]
        public void TestInit()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5500"); 
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Dispose();
        }

        [TestMethod]
        [DataRow("testName", "testURL")]
        [DataRow("testName2", "testURL2")]
        public void AddTest(string name, string URL)
        {
            int expected = 4; 
            driver.FindElement(By.Name("inputName")).SendKeys(name);
            driver.FindElement(By.Name("inputURL")).SendKeys(URL);
            driver.FindElement(By.Name("sendButton")).Click();
            int actual = driver.FindElements(By.ClassName("liElement")).Count(); 
            Assert.AreEqual(expected, actual);
        }
    }
}
