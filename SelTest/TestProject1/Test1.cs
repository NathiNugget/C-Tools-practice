

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        IWebDriver driver; 

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
       
        public void Add()
        {
            int expected = 4; 
            driver.FindElement(By.Id("inputName")).SendKeys("testName");
            driver.FindElement(By.Id("inputURL")).SendKeys("testURL");
            driver.FindElement(By.Id("CreateButton")).Click();
            int actual = driver.FindElements(By.Name("swag")).Count(); 
            Assert.AreEqual(expected, actual); 
        }
    }
}
