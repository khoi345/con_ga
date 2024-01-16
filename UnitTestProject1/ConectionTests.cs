using Dao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class ConectionTests
    {
        [TestMethod]
        public void TestMaincode()
        {
            // Arrange
            var expectedValue = "http://localhost/";

            // Act
            var result = Conection.Maincode("Release");

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void TestPass()
        {
            //// Arrange
            //var expectedValue = "ExpectedPassValue";

            //// Act
            //var result = Conection.Pass("YourItem");

            //// Assert
            //Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void TestConnectionStringBuilderInitialization()
        {
            // Arrange

            // Act
            var connectionString = Conection.connStringBuilder.ConnectionString;

            // Assert
            // Add assertions to ensure that the connection string is correctly initialized.
            // You may want to check specific properties like DataSource, InitialCatalog, etc.
            Assert.IsNotNull(connectionString);
            Assert.IsTrue(connectionString.Contains("Data Source=KHOI-PC\\SQLEXPRESS;Initial Catalog=ConGa;User ID=sa;Password=chrome;MultipleActiveResultSets=True"));
        }

        [TestMethod]
        public void TestConnectionStringBuilder2Initialization()
        {
            // Arrange

            // Act
            var connectionString2 = Conection.connStringBuilder2.ConnectionString;

            // Assert
            // Add assertions to ensure that the connection string is correctly initialized.
            // You may want to check specific properties like DataSource, InitialCatalog, etc.
            Assert.IsNotNull(connectionString2);
            Assert.IsTrue(connectionString2.Contains("Data Source=KHOI-PC\\SQLEXPRESS;Initial Catalog=ConGa;User ID=sa;Password=chrome;MultipleActiveResultSets=True"));
        }
    }
}