alter proc BaoCaoDichvu_Thang
	@d_Ngay_tim date
as
BEGIN
SET ANSI_NULLS OFF
	begin
	create table #Baocaothang(
		v_Sophieu varchar(20),      --
		v_Makhachhang varchar(50),	--
		d_Ngay date,				--
		nv_Hoten nvarchar(30),      --
		nv_Diachi nvarchar(50),		--
		v_SDT varchar(20),			--
		nv_Tendichvu nvarchar(50),  --
		i_Solan float,				--
		f_Giamgia float,			--
		f_Tienmat float,			--
		f_card float,				--
		nv_Tuvanvien nvarchar(30),	--
		nv_Kithuatvien nvarchar(30),--
		f_no float					--
	)
	end
	begin
	declare @cr_test cursor
	declare @uId_Phieudichvu_Chitiet varchar(50)
	
	set @cr_test = CURSOR for
	(
		select  uId_Phieudichvu_Chitiet
		from TNTP_PHIEUDICHVU_CHITIET
	)
	OPEN @cr_test
	
	FETCH next from @cr_test into @uId_Phieudichvu_Chitiet
	while @@FETCH_STATUS = 0
	BEGIN
		--bảng phiếu dịch vụ chi tiết
		begin
		declare @f_Solan float
		set @f_Solan = (select f_Solan from TNTP_PHIEUDICHVU_CHITIET where uId_Phieudichvu_Chitiet = @uId_Phieudichvu_Chitiet)
		declare @f_Giamgia float
		set @f_Giamgia = (select f_Giamgia from TNTP_PHIEUDICHVU_CHITIET where uId_Phieudichvu_Chitiet = @uId_Phieudichvu_Chitiet)
		declare @giatien float
		set @giatien = (select f_Dongia  from TNTP_PHIEUDICHVU_CHITIET where uId_Phieudichvu_Chitiet = @uId_Phieudichvu_Chitiet)
		--bảng phiếu dịch vụ
		
		declare @uId_Phieudichvu varchar(50)
		set @uId_Phieudichvu = (select uId_Phieudichvu from TNTP_PHIEUDICHVU_CHITIET where uId_Phieudichvu_Chitiet = @uId_Phieudichvu_Chitiet)
		declare @v_Sophieu varchar(20)
		set @v_Sophieu =(select v_Sophieu from TNTP_PHIEUDICHVU where uId_Phieudichvu = @uId_Phieudichvu)
		declare @d_Ngay datetime
		set @d_Ngay = (select d_Ngay from TNTP_PHIEUDICHVU where uId_Phieudichvu = @uId_Phieudichvu)
		declare @uId_Khachhang varchar(50)
		set @uId_Khachhang = (select uId_Khachhang from TNTP_PHIEUDICHVU where uId_Phieudichvu = @uId_Phieudichvu)
		declare @uId_TVV varchar(50)
		set @uId_TVV = (select uId_Nhanvien from TNTP_PHIEUDICHVU where uId_Phieudichvu = @uId_Phieudichvu)
		declare @uId_LoaiTT varchar(50)
		set @uId_LoaiTT = (select uId_LoaiTT from TNTP_PHIEUDICHVU where uId_Phieudichvu = @uId_Phieudichvu)
		
		
		--bảng loại hình thanh toán
		declare @f_Tienmat float
		declare @f_card float
		if @uId_LoaiTT = (select uId_LoaiTT from QLTC_LoaiHinhTT where v_MaLoaiTT = 'TM') 
			set @f_Tienmat = @giatien
		else
			set @f_card = @giatien
			
		--bảng dịch vụ
		
		declare @uId_Dichvu varchar(50)
		set @uId_Dichvu = (select uId_Dichvu from TNTP_PHIEUDICHVU_CHITIET where uId_Phieudichvu_Chitiet = @uId_Phieudichvu_Chitiet)
		declare @nv_TenDV nvarchar(50)
		set @nv_TenDV =(select nv_Tendichvu_vn from TNTP_DM_DICHVU where uId_Dichvu = @uId_Dichvu)
		if @nv_TenDV = null
			set @nv_TenDV =(select nv_Tendichvu_en from TNTP_DM_DICHVU where uId_Dichvu = @uId_Dichvu)
			
		--bảng khách hàng
		declare @v_Makhachhang varchar(50)
		set @v_Makhachhang = (select v_Makhachang from CRM_DM_Khachhang where uId_Khachhang = @uId_Khachhang)
		declare @nv_Hoten nvarchar(50)
		set @nv_Hoten = (select nv_Hoten_vn from CRM_DM_Khachhang where uId_Khachhang = @uId_Khachhang)
			if @nv_Hoten = null
				set @nv_Hoten = (select nv_Hoten_en from CRM_DM_Khachhang where uId_Khachhang = @uId_Khachhang)
		declare @v_SDT varchar(20)
		set @v_SDT = (select v_DienthoaiDD from CRM_DM_Khachhang where uId_Khachhang = @uId_Khachhang)
			if @v_SDT = null
				set @v_SDT = (select v_Dienthoaikhac from CRM_DM_Khachhang where uId_Khachhang = @uId_Khachhang)
		declare @nv_Diachi nvarchar(50)
		set @nv_Diachi = (select nv_Diachi_vn from CRM_DM_Khachhang where uId_Khachhang = @uId_Khachhang)
			if @nv_Diachi = null
				set @nv_Diachi = (select nv_Diachi_en from CRM_DM_Khachhang where uId_Khachhang = @uId_Khachhang)	
		
		--bảng điều trị
		declare @uId_KTV varchar(50)
		set @uId_KTV = (select uId_Nhanvien from TNTP_QT_Dieutri where uId_Phieudichvu_Chitiet = @uId_Phieudichvu_Chitiet)
		
		--Bảng nhân viên
		declare @nv_Tuvanvien nvarchar(30)
		set @nv_Tuvanvien = (select nv_Hoten_vn  from QT_DM_NHANVIEN where uId_Nhanvien = @uId_TVV)
			if @nv_Tuvanvien = null
				set @nv_Tuvanvien = (select nv_Hoten_en  from QT_DM_NHANVIEN where uId_Nhanvien = @uId_TVV)
		declare @nv_Kithuatvien nvarchar(30)
		set @nv_Kithuatvien = (select nv_Hoten_vn from QT_DM_NHANVIEN where uId_Nhanvien = @uId_KTV)
			if @nv_Kithuatvien = null
				set @nv_Kithuatvien = (select nv_Hoten_en from QT_DM_NHANVIEN where uId_Nhanvien = @uId_KTV)
		
		--Bảng Congno
		
		declare @f_no float
		set @f_no = (select f_Sotien from QLCN_CONGNO where uId_Phieudichvu = @uId_Phieudichvu_Chitiet)
		
		--insert bảng baocaothang
			
		insert into #Baocaothang(v_Sophieu,v_SDT,v_Makhachhang,nv_Tuvanvien,nv_Tendichvu,nv_Kithuatvien,nv_Hoten,nv_Diachi,i_Solan,f_no,f_card,f_Tienmat,f_Giamgia,d_Ngay)	
		values(@v_Sophieu,@v_SDT,@v_Makhachhang,@nv_Tuvanvien,@nv_TenDV,@nv_Kithuatvien,@nv_Hoten,@nv_Diachi,@f_Solan,@f_no,@f_card,@f_Tienmat,@f_Giamgia,@d_Ngay)
		
		end
		FETCH NEXT From @cr_test into @uId_Phieudichvu_Chitiet
	END
	close @cr_test
	deallocate @cr_test
	end
	select * from #Baocaothang where DATEDIFF(Month,@d_Ngay_tim,#Baocaothang.d_Ngay)=0 and DATEDIFF(YEAR,@d_Ngay_tim,#Baocaothang.d_Ngay)=0
END


execute BaoCaoDichvu_Thang '04/01/2015'



----------------------------------------test
