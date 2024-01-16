using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dao;
using Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class NguoiDungDaoTests
    {
        // Mocked SqlConnection for testing
        private Mock<SqlConnection> mockSqlConnection;

        [TestInitialize]
        public void Setup()
        {
            // Initialize mock SqlConnection
            mockSqlConnection = new Mock<SqlConnection>();
        }

        [TestMethod]
        public void GetByDienThoai_ReturnsNguoiDung()
        {

            // Create an instance of DatMuaSoDao with the mocked SqlConnection

            // Arrange
            var nguoiDung = new NguoiDung {
                  DienThoai = "0866592512"
              };

            var dao = new NguoiDungDao();

            // Act
            var result = dao.GetByDienThoai(nguoiDung);

            // Assert
            Assert.IsNotNull(result);
            // Add more assertions based on your specific implementation and expectations
        }

        // Add more test methods for other functions in NguoiDungDao
    }
}