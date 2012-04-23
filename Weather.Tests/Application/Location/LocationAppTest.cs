using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Weather.Application.Location;
using Weather.Model.Domain;

namespace Weather.Tests.Application.Location
{
    /// <summary>
    /// Summary description for LocationAppTest
    /// </summary>
    [TestClass]
    public class LocationAppTest
    {
        public LocationAppTest()
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
        public void GetPlacesThatStartsWithTest()
        {
            string query = "Troll";
            IList<Place> places = LocationApp.GetPlacesThatStartsWith("NO", query);

            Assert.IsTrue(places.Count > 0);
            
            // is this hitting database?
            query = "Os";
            places = LocationApp.GetPlacesThatStartsWith("NO", query);

            Assert.IsTrue(places.Count > 0);
        }

        [TestMethod]
        public void GetClosestPlaceTest()
        {
            double longitude = 10.7460923576733;
            double latitude = 59.912726542422;

            Place place = LocationApp.GetClosestPlace("NO", latitude, longitude);


            Assert.IsNotNull(place);
        }
    }
}
