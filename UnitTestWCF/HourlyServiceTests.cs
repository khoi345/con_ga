using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wcf;
namespace UnitTestWCF
{
    [TestClass]

    class HourlyServiceTests
    {
        [TestMethod]
        public void ScheduleHourlyTask_Always_RunsOnceAnHour()
        {
            // Arrange
            var hourlyService = new HourlyService();

            // Act
            hourlyService.ScheduleHourlyTask();

            // Assert
            Assert.IsTrue(HourlyService.isRunning); // Verify that the task is running
            Assert.IsNotNull(HourlyService.run_at); // Verify that the 'run_at' variable is set

            // Cleanup
            HourlyService.isRunning = false; // Reset the isRunning flag
        }

        
        public void DoHourlyTask_Always_ReturnsExpectedString()
        {
            // Arrange
            var hourlyService = new HourlyService();
            var expectedRunAt = DateTime.Now.ToString("yyyyMMddHH");

            // Act
            HourlyService.run_at = expectedRunAt;
            var result = hourlyService.DoHourlyTask();

            // Assert
            Assert.AreEqual(expectedRunAt, result);
        }
    }
}