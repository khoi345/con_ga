using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dto;
namespace Client
{
    public partial class frMain : Form
    {
        public frMain()
        {
            InitializeComponent();
        }
        public bool flag = true;
        public NguoiDungClient nguoiDungClient = new NguoiDungClient();
        public DatMuaSoClient datMuaSoClient = new DatMuaSoClient();
        public NguoiDung nguoiDung = new NguoiDung();
        public BaoCaoClient baoCaoClient = new BaoCaoClient();



        private void SetDataGridViewColumnHeader(string propertyName, string headerText)
        {
            var column = dgLichSu.Columns[propertyName];
            if (column != null)
            {
                column.HeaderText = headerText;
            }
        }

        private void btDatCuoc_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                MessageBox.Show("Kiểm tra lại thông tin có thông tin sai");
            }
            if (txHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Nhập tên người đặt cược");
                txHoTen.Focus();
                return;
            }
            if (nguoiDung != null && nguoiDung.ID != null && nguoiDung.ID.ToString() != "-1")
            {
                DatMuaSo tmp = new DatMuaSo();
                tmp.UserID = nguoiDung.ID;
                tmp.SoDuocDat = txDatCuoc.Value;
                tmp.CreateUser = nguoiDung.ID.ToString();
                tmp.ThoiGianDat = DateTime.Now;

                try
                {
                    var kq = datMuaSoClient.DatMuaSoConGa(tmp);
                    if (kq != null && kq.ID != null)
                    {
                        txThongBao.Text = "Bạn đã đặt mua slot: (" + kq.SlotMoSoID.ToString() + ") Số: " + kq.SoDuocDat + " lúc " + kq.ThoiGianDat.ToString("HH:mm dd/MM/yyyy");
                        paMau.BackColor = Color.Green;
                    }
                    else
                    {
                        txThongBao.Text = "Không thể mua vui lòng quay lại sau";
                        paMau.BackColor = Color.Pink;
                    }
                }
                catch (Exception ex)
                {
                    txThongBao.Text = ex.Message.ToString();
                    paMau.BackColor = Color.Red;
                }
                try
                {
                    LoadCacLanDatTruoc();
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                txThongBao.Text = "Người dùng chưa có thông tin";
                nguoiDung = new NguoiDung()
                {
                    DienThoai = txDienThoai.Text,
                    HoTen = txHoTen.Text,
                    NgaySinh = dtNgaySinh.Value,
                };
                if (!nguoiDungClient.KiemTraTonTaiSoDienThoai(nguoiDung))
                    if (nguoiDungClient.Insert(nguoiDung))
                    {
                        txThongBao.Text = "Đã thêm người dùng";
                    }
                txDienThoai_Validated(null, null);
                btDatCuoc_Click(null, null);
            }
        }
        public void LoadCacLanDatTruoc()
        {
            BaoCao tmp = new BaoCao();
            tmp.UserID = nguoiDung.ID.ToString();
            List<BaoCaoKetQua> list = baoCaoClient.LoadKetQuaSoByUserID(tmp);
            DataTable tb = DataTransport.ToDataTable<BaoCaoKetQua>(list);
            dgLichSu.DataSource = tb;
            SetDataGridViewColumnHeader("SlotMoSoID", "Slot ID");
            SetDataGridViewColumnHeader("SoDuocDat", "Số đã cược");
            SetDataGridViewColumnHeader("KetQua", "Kết Quả");
        }
        static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Sử dụng biểu thức chính quy để kiểm tra số điện thoại
            // Điều chỉnh biểu thức chính quy để hỗ trợ số điện thoại mới
            string pattern = @"^(\+84|0)([0-9]{9,10})$";

            // Kiểm tra chuỗi với biểu thức chính quy
            return Regex.IsMatch(phoneNumber, pattern);
        }

        public void txDienThoai_Validated(object sender, EventArgs e)
        {
            txDienThoai.Text = txDienThoai.Text.Replace("+840", "0");
            txDienThoai.Text = txDienThoai.Text.Replace("+84", "0");
            if (IsValidPhoneNumber(txDienThoai.Text))
            {
                flag = true;
                nguoiDung = new NguoiDung();
                nguoiDung.DienThoai = txDienThoai.Text.Trim();
                nguoiDung = nguoiDungClient.GetByDienThoai(nguoiDung);
                if (nguoiDung != null)
                {
                    ShowNguoDung(nguoiDung);
                }
                else
                {
                    ShowNguoDung(new NguoiDung());
                }
            }
            else
            {
                ShowNguoDung(new NguoiDung());
                MessageBox.Show("Sai số điện thoại");
                txDienThoai.Focus();
                flag = false;
            }
        }
        public void ShowNguoDung(NguoiDung tmp)
        {
            try
            {
                dtNgaySinh.Value = tmp.NgaySinh;
            }
            catch
            {

            }
            txHoTen.Text = tmp.HoTen;
            dtNgaySinh_ValueChanged(null, null);
        }


        private void dtNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime ngaySinh = dtNgaySinh.Value;

                // Tính tuổi
                int tuoi = DateTime.Now.Year - ngaySinh.Year;

                // Kiểm tra xem đã qua sinh nhật chưa để quyết định cộng thêm 1
                if (DateTime.Now < ngaySinh.AddYears(tuoi))
                {
                    tuoi--;
                }

                // Hiển thị tuổi
                txTuoi.Text = tuoi.ToString();
            }
            catch
            {
                txTuoi.Text = "0";
            }
        }

        private void frMain_Load(object sender, EventArgs e)
        {
            // Tạo một NumericUpDown control

            // Thiết lập giá trị tối thiểu và tối đa
            txDatCuoc.Minimum = 0;
            txDatCuoc.Maximum = 9;
            // (Tùy chọn) Đăng ký sự kiện ValueChanged nếu bạn muốn xử lý sự thay đổi giá trị
            txDatCuoc.ValueChanged += NumericUpDown_ValueChanged;

        }
        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Lấy giá trị mới khi giá trị thay đổi
            int newValue = (int)((NumericUpDown)sender).Value;
            Console.WriteLine($"New value: {newValue}");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                BaoCao tmp = new BaoCao();
                tmp.UserID = nguoiDung.ID.ToString();

                txLuotTiepTheio.Text = "Lượt quay tiếp theo: "+ baoCaoClient.LuotQuaySoTiepTheo(tmp);
            }
            catch (Exception ex)
            {
                txLuotTiepTheio.Text = "Máy chủ đang xử lý ...";
            }
        }
    }
}
