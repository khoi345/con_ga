using Dao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class BaoCaoDaoTests
    {
        [TestMethod]
        public void LoadKetQuaSoByUserID_WithValidUserID_ReturnsExpectedResult()
        {
            // Arrange

            // Create an instance of BaoCaoDao with the mocked SqlConnection
            var dao = new BaoCaoDao();

            // Create BaoCao instance with the desired UserID
            var p = new BaoCao { UserID = "2231" };

            // Act
            var result = dao.LoadKetQuaSoByUserID(p);

            // Assert

           
            // Your assertions for the result
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 1); // This line is modified
            Assert.AreEqual(DateTime.Now.AddHours(-1).ToString("yyyyMMddHH"), result[0].SlotMoSoID);
            //    Assert.AreEqual(10, result[0].SoDuocDat);
            Assert.IsTrue(result[0].SoDuocDat >= 0 && result[0].SoDuocDat <= 9);

            Assert.IsTrue(result[0].KetQua == "WIN" || result[0].KetQua == "LOSE" || result[0].KetQua == "");

            // Add any other assertions based on your specific implementation and expectations
        }
    }
}