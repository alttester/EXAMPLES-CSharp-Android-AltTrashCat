using System;
using System.Threading;
using AltTester.AltTesterSDK.Driver;
using alttrashcat_tests_csharp.pages;
using NUnit.Framework;

namespace alttrashcat_tests_csharp.tests
{
    public class StartPageTests
    {
        private AltDriver altDriver;
        private MainMenuPage mainMenuPage;
        private StartPage startPage;
        [SetUp]
        public void Setup()
        {
            altDriver = new AltDriver();
            startPage = new StartPage(altDriver);
            startPage.Load();
            mainMenuPage = new MainMenuPage(altDriver);

        }
        [Test]
        public void TestStartPageLoadedCorrectly()
        {
            Assert.True(startPage.IsDisplayed());
        }
        [Test]
        public void TestStartButtonLoadMainMenu()
        {
            startPage.PressStart();
            Assert.True(mainMenuPage.IsDisplayed());
        }

        [TearDown]
        public void Dispose()
        {
            altDriver.Stop();
            Thread.Sleep(100);
        }
    }
}