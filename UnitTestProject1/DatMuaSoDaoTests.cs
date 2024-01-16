using Dao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dto;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class DatMuaSoDaoTests
    {
        [TestMethod]
        public void Insert_WithValidDatMuaSo_ReturnsInsertedID()
        {
            // Arrange

            // Create a DatMuaSo instance for testing
            var datMuaSo = new DatMuaSo
            {
                ThoiGianDat = DateTime.Now,
                SlotMoSoID = 1,
                SoDuocDat = 5,
                UserID = 123,
                CreateUser = "TestUser",
                CreateDate = DateTime.Now,
                EditUser = "TestUser",
                EditDate = DateTime.Now
            };


            var dao = new DatMuaSoDao();

            // Act
            var insertedID = dao.Insert(datMuaSo);

            // Assert
            Assert.IsTrue(insertedID > 0); // Assert the expected inserted ID
        }
    

    [TestMethod]
        public void GetOnlyByID_WithValidID_ReturnsExpectedResult()
        {
            // Arrange

            // Create an instance of DatMuaSoDao with the mocked SqlConnection
            var dao = new DatMuaSoDao();




            // Act
            var result = dao.GetOnlyByID("31");

            // Assert
            Assert.IsNotNull(result);
            // Add more assertions based on your specific implementation and expectations
        }

        [TestMethod]
        public void Get_WithValidByID_ReturnsExpectedResult()
        {
            // Arrange

            // Create an instance of DatMuaSoDao with the mocked SqlConnection
            var dao = new DatMuaSoDao();

            // Create a DatMuaSo instance with the desired ID
            var p = new DatMuaSo { ID = "31" };


            // Act
            var result = dao.Get(p);

            // Assert
            Assert.IsNotNull(result);
            // Add more assertions based on your specific implementation and expectations
        }
        [TestMethod]
        public void GetAll_ReturnsExpectedResult()
        {
            // Arrange

            // Create an instance of DatMuaSoDao with the mocked SqlConnection
            var dao = new DatMuaSoDao();

            // Create a DatMuaSo instance with the desired ID
            var p = new DatMuaSo { };


            // Act
            var result = dao.GetAll(p);

            // Assert
            Assert.IsNotNull(result);
            // Add more assertions based on your specific implementation and expectations
        }

    }
}
