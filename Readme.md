
Tên dự án: Xổ số kiến thiết Con Gà Trống 
I. 	Dịch vụ trên server
1. Dịch vụ Quay số trên server mỗi giờ quay 1 lần lưu kết quả chạy trên IIS 	DONE
2. Các hàm khác lưu kết quả hoặc trả kết quả, báo cáo của người dùng, quay số, 		DONE


II.	App trên clients
1. Đăng ký người dùng mới DONE
2. Trả về thông tin người dùng cũ khi vào số điện thoại 	DONE
3. Nhập số đặt cược từ 0 đến 9 nhập sai tự động trả lại số 9 hoặc 0		DONE
4. Trả lại báo cáo số đã cược và kết quả		DONE
5. Kiến trúc app: client side là một app winform, viết bằng C#. DONE

III.	Các dự án unit test

IV. Kiến trúc dự án
1. Sử dụng mô hình 3 lớp
2. Sử dụng WCF triển khai làm API dịch vụ
3. Sử dụng MS SQL lưu CSDL
4. Sử dụng Redis lưu cache các kết quả tối ưu hiệu năng
5. Sử dụng IIS làm server


V. Hướng dẫn triển khai
1. Chạy các Unittest
2. Build ứng dụng 
	- Sửa chuỗi kết nối CSDL trong class /Dao/_code/Conection.cs , bao gồm SQL, và Redis
	- Tạo Data Log riêng hoặc chung
	- File scrip sql kèm theo dự án /data/data.sql, /data/log.sql
3. Cài đặt môi trường iis windows server, 
	- Cài netframework version=v4.0 vào IIS, ( phải kích hoạt để IIS chạy được netframework 4.0)
	- Cài Redis for windows 
	- Cài MS SQL
	- public dịch ra môi trường internet hoặc trả về tên miền dịch vụ ví dụ: http://localhoost/
4. Build dự án Wcf kèm theo lên server IIS
	- Sau khi build xong chạy dịch vụ http://localhoost/HourlyService.svc/DoHourlyTask  đây là dịch vụ quay số liên tục trả về thời gian của lần quya số thiếp theo
5. Build app cho Client
	- Sửa url kết nối trong  file xml trong  /Chicken/maincode.xml build app gửi khách hàng cần mua số

CHÚ Ý: Build dự án ở chế độ Release.

Liên hệ Nguyễn Minh Khôi
0866 592 512 
nếu gặp khos khăn



