using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Timers;
using Dao;
using Dto;

namespace Wcf
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class HourlyService : IHourlyService
    {
        private static Timer timer;
        public static string run_at = "";
        public static bool isRunning = false;

        public HourlyService()
        {
            // Lên lịch cho việc chạy mỗi giờ vào phút thứ 0 (Giờ:00)
            GuiLogDao gl = new GuiLogDao();
            gl.GuiLogTraMaLoi(this.GetType().Name, "RUN at IIS", "", "Running at: " + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy"), "");
            ScheduleHourlyTask();
        }

        public void ScheduleHourlyTask()
        {
            // Nếu đang chạy rồi thì không cần làm gì
            if (isRunning)
            {
                return;
            }

            // Lấy thời gian hiện tại
            DateTime now = DateTime.Now;

//#if DEBUG
//            // Tính thời gian cần đến phút thứ 0 của giờ kế tiếp
//            DateTime nextHour = now.AddHours(0).AddMinutes(1).AddSeconds(0);
//#else
            DateTime nextHour = now.AddHours(1).AddMinutes(0).AddSeconds(0);
            nextHour = new DateTime(nextHour.Year,nextHour.Month,nextHour.Day,nextHour.Hour,0,0);
            run_at = nextHour.ToString("HH:mm:ss dd/MM/yyyy");
            //#endif
            GuiLogDao gl = new GuiLogDao();
            gl.GuiLogTraMaLoi(this.GetType().Name, "ScheduleHourlyTask at IIS", "", "Next executed Task  at: " + nextHour.ToString("HH:mm:ss dd/MM/yyyy"), "");

            // Tính khoảng thời gian giữa thời điểm hiện tại và thời điểm cần chạy lần đầu tiên
            double interval = (nextHour - now).TotalMilliseconds;
           

            // Tạo timer
            timer = new Timer(interval);
            timer.Elapsed += TimerElapsed;
            timer.Start();

            // Đang chạy, cập nhật biến cờ
            isRunning = true;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Gọi phương thức của dịch vụ khi hết mỗi giờ
            QuaySoBus bus = new QuaySoBus();
            bus.QuaySoVaLuuKetQua();
            GuiLogDao gl = new GuiLogDao();
            gl.GuiLogTraMaLoi(this.GetType().Name, "TimerElapsed at IIS", "", "Task executed at: " + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy"), "");

            // Dừng timer để không lên lịch cho lần kế tiếp (nếu có)
            timer.Stop();

            // Đặt lại biến cờ để có thể lên lịch cho lần tiếp theo
            isRunning = false;

            // Lên lịch cho lần kế tiếp
            ScheduleHourlyTask();
        }

        public string DoHourlyTask()
        {
            // Phương thức này không cần thực hiện gì cả, vì nó được gọi từ timer
            return run_at;
        }
    }
}
