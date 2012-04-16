using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Weather.Tests
{
    /// <summary>
    /// Summary description for DateTimeTest
    /// </summary>
    [TestClass]
    public class FrameworkTest
    {
        public FrameworkTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void DateTimeParseTest()
        {
            DateTime test1 = DateTime.Parse("2012-04-15T18:00:00");
            DateTime test2 = DateTime.Parse("2012-04-16T00:00:00");
        }

        [TestMethod]
        public void ImageUrlTest()
        {
            string var = "mf/03n.83";
            string fileName = var.TrimStart("mf/".ToCharArray()).TrimEnd(".83".ToCharArray());

            Assert.AreEqual("03n", fileName);
        }

         
    }
}
