using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Weather.Model.Common;

namespace Weather.Tests.Model.Common
{
    /// <summary>
    /// Summary description for HelpersTest
    /// </summary>
    [TestClass]
    public class HelpersTest
    {
        public HelpersTest()
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
        public void ParseSymbolVarTest()
        {
            string var = "mf/03n.83";
            string actual = Helpers.ParseSymbolVar(var);
            Assert.AreEqual("03n", actual);

        }

        [TestMethod]
        public void CalculateDistanceTest()
        {
            double destLongitude = 10.7460923576733;  // jeg tror dette er min lokasjon i Oslo
            double destLatitude = 59.912726542422;

            double startLongitude = 12.0937602381878;  //  dette er http://www.yr.no/sted/Norge/Hedmark/Kongsvinger/Gjermshus/varsel.xml 
            double startLatitude = 60.137353471887;

            double distance = Helpers.CalculateDistance(startLatitude, startLongitude, destLatitude, destLongitude);   // gir 78,9 km

            startLongitude = 10.2044912002555;                          // dette er http://www.yr.no/sted/Norge/Buskerud/Drammen/Drammen/varsel.xml
            startLatitude = 59.7438903362171;

            distance = Helpers.CalculateDistance(startLatitude, startLongitude, destLatitude, destLongitude);   // gir 35,61 km
        }
    }
}
