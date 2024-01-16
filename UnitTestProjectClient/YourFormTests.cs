using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chicken;
using Client;

namespace UnitTestChicken
{
    [TestClass]
    public class YourFormTests
    {
        [TestMethod]
        public void TxDienThoai_Validated_ValidPhoneNumber_ShouldSetFlagAndFetchNguoiDung()
        {
            // Arrange
            var yourForm = new frMain(); // Replace YourForm with the actual form class name
            var expectedPhoneNumber = "0866592512";
            yourForm.txDienThoai.Text = "+840" + expectedPhoneNumber;

            // Act
            yourForm.txDienThoai_Validated(null, EventArgs.Empty);

            // Assert
            Assert.IsTrue(yourForm.flag);
            Assert.IsNotNull(yourForm.nguoiDung);
            Assert.AreEqual(expectedPhoneNumber, yourForm.nguoiDung.DienThoai);
        }

        [TestMethod]
        public void TxDienThoai_Validated_InvalidPhoneNumber_ShouldShowMessageBoxAndSetFlagToFalse()
        {
            // Arrange
            var yourForm = new frMain(); // Replace YourForm with the actual form class name
            yourForm.txDienThoai.Text = "12345";

            // Act
            yourForm.txDienThoai_Validated(null, EventArgs.Empty);

            // Assert
            Assert.IsFalse(yourForm.flag);
            Assert.IsNull(yourForm.nguoiDung);
            // Add assertions for the MessageBox display (mock MessageBox, if needed)
        }
    }
}