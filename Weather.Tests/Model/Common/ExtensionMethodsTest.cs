﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Weather.Model.Common;

namespace Weather.Tests.Model.Common
{
    /// <summary>
    /// Summary description for ExtensionMethodsTest
    /// </summary>
    [TestClass]
    public class ExtensionMethodsTest
    {
        public ExtensionMethodsTest()
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
        public void ToStringPeriodTest1()
        {
            double test1 = 1.23;

            Assert.AreEqual("1,23", test1.ToString());
            Assert.AreEqual("1.23", test1.ToStringPeriod());
        }

        [TestMethod]
        public void ToStringPeriodTest2()
        {
            double test2 = 1234.5;

            Assert.AreEqual("1234.5", test2.ToStringPeriod());
        }

        [TestMethod]
        public void ToStringPeriodTest3()
        {
            double test3 = 1.12345;

            Assert.AreEqual("1.12345", test3.ToStringPeriod());
        }

    }
}