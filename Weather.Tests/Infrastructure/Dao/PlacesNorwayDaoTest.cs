using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Weather.Infrastructure.Dao;
using Weather.Infrastructure.Spring;
using Weather.Infrastructure.Dao.Entities;

namespace Weather.Tests.Infrastructure.Dao
{
    /// <summary>
    /// Summary description for PlacesNorwayDaoTest
    /// </summary>
    [TestClass]
    public class PlacesNorwayDaoTest
    {
        public PlacesNorwayDaoTest()
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
        public void GetPlaceTest()
        {
            IPlacesNorwayDao dao = SpringObjectLocator.GetObject("PlacesNorwayDao") as PlacesNorwayDao;

            PlaceNorway place = dao.GetPlace(1);
            
            Assert.IsNotNull(place);
        }

        [TestMethod]
        public void QueryAllPlacesTest()
        {
            IPlacesNorwayDao dao = SpringObjectLocator.GetObject("PlacesNorwayDao") as PlacesNorwayDao;
            IList<PlaceNorway> places = dao.QueryAllPlaces();

            Assert.IsTrue(places.Count > 0);
        }

        [TestMethod]
        public void QueryAllChurchesTest()
        {
            IPlacesNorwayDao dao = SpringObjectLocator.GetObject("PlacesNorwayDao") as PlacesNorwayDao;
            IList<PlaceNorway> places = dao.QueryAllChurches();

            Assert.IsTrue(places.Count > 0);
        }
    }
}
