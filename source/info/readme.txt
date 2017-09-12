info pk_phung gia duong
- phong kham duoc nang cap tu ban tmv len
- phieu xuat duoc doi thanh don thuoc( mỗi phiếu xuất là 1 thang thuốc)
	+ thêm thông tin số lượng thang cho mỗi phiếu xuât(đơn thuốc)
	+ mỗi đơn thuốc kê cho 1 lần điều trị(hoặc nhiều lần hay là tạo thành mẫu cho lần điều trị sau)
	+ trong TNTP_QT_DIEUTRI trường nv_Noidung lưu id đơn thuốc(nếu có)
	+ trong QLMH_PHIEUXUAT 	trường b_Dathanhtoan lưu trạng thái thanh toán hay chưa(nếu thanh toán sẽ trừ vào tồn kho còn không sẽ chỉ là phiếu kê)
							trường nv_Noidungxuat_en lưu số lượng thang
				>>> trừ tồn (f_Soluongnhonhat*nv_Noidungxuat_en)
	+ thêm trường dữ liệu 	TypeGia(CHON: giá tự nhập vào cho 1 thang thuốc,DM: giá được tính theo danh mục)
							f_Gia(đơn giá khi thanh toán của 1 thang thuốc)
							i_Soluong(số thang của đơn thuốc đó dùng cho tính tiền)
	+ trạng thái của b_Iskhoa thể hiện đơn thuốc thuộc kiểu mua(false:trừ tồn) và chỉ kê(true:không trừ tồn)
- cần thực hiện 
	+	chuyển trạng thái phiếu khám trong danh sách chờ điều trị khi đơn thuốc được chuyển qua thanh toán 
	+	hồ sơ bệnh án (thông tin bệnh nhân, và các lần điều trị có liên quan đến bác sĩ)
	+	báo cáo
	+	bệnh sử làm theo mẫu đã được lấy về