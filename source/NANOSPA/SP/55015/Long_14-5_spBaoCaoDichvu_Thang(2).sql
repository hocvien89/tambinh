alter proc BaoCaoDichvu_Thang
	@d_Ngay_bd date = '04/10/2015',
	@d_Ngay_tim date = '04/13/2015'
as
BEGIN
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
	declare @uId_Phieudichvu varchar(50)
	
	set @cr_test = CURSOR for
	(
		select  uId_Phieudichvu
		from TNTP_PHIEUDICHVU
	)
	OPEN @cr_test
	
	FETCH next from @cr_test into @uId_Phieudichvu
	while @@FETCH_STATUS = 0
	BEGIN
		begin
		--PhieuDV
			declare @v_Sophieu varchar(20)
			set @v_Sophieu =(select v_Sophieu from TNTP_PHIEUDICHVU where uId_Phieudichvu = @uId_Phieudichvu)
			declare @d_Ngay datetime
			set @d_Ngay = (select d_Ngay from TNTP_PHIEUDICHVU where uId_Phieudichvu = @uId_Phieudichvu)
			declare @uId_TVV varchar(50)
			set @uId_TVV = (select uId_Nhanvien from TNTP_PHIEUDICHVU where uId_Phieudichvu = @uId_Phieudichvu)
			declare @uId_LoaiTT varchar(50)
			set @uId_LoaiTT = (select uId_LoaiTT from TNTP_PHIEUDICHVU where uId_Phieudichvu = @uId_Phieudichvu)
			declare @f_no float
			set @f_no = (select f_Sotien from QLCN_CONGNO where uId_Phieudichvu = @uId_Phieudichvu)
		
		--thong tin  khach hang
			declare @uId_Khachhang varchar(50)
			set @uId_Khachhang = (select uId_Khachhang from TNTP_PHIEUDICHVU where uId_Phieudichvu = @uId_Phieudichvu)
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
		--so sanh giam gia
			declare @f_Giamgia float
			declare @giatien float
			declare @f_phantramgiam float
			declare @f_Tienmat float
			declare @f_card float
			set @f_Giamgia = (select f_Giamgia from TNTP_PHIEUDICHVU where uId_Phieudichvu = @uId_Phieudichvu)
			if @f_Giamgia <> 0
			begin
				set @giatien = (select sum(f_Dongia)  from TNTP_PHIEUDICHVU_CHITIET where uId_Phieudichvu = @uId_Phieudichvu)
				set @f_phantramgiam = ROUND(@f_Giamgia/@giatien*100,0)
				set @giatien = @giatien-@f_Giamgia
				if @uId_LoaiTT = (select uId_LoaiTT from QLTC_LoaiHinhTT where v_MaLoaiTT = 'TM') 
				set @f_Tienmat = @giatien
				else
				set @f_card = @giatien
			end
			insert into #Baocaothang(v_Sophieu,v_SDT,v_Makhachhang,nv_Tuvanvien,nv_Tendichvu,nv_Kithuatvien,nv_Hoten,nv_Diachi,i_Solan,f_no,f_card,f_Tienmat,f_Giamgia,d_Ngay)	
			values(@v_Sophieu,@v_SDT,@v_Makhachhang,'','','',@nv_Hoten,@nv_Diachi,null,@f_no,@f_card,@f_Tienmat,@f_phantramgiam,@d_Ngay)
		--lap		
		begin
			declare @cr_test_1 cursor
			declare @uId_Phieudichvu_Chitiet varchar(50)
			set @cr_test_1 = CURSOR for
			(
				select  uId_Phieudichvu_chitiet
				from TNTP_PHIEUDICHVU_CHITIET where uId_Phieudichvu = @uId_Phieudichvu
			)
			OPEN @cr_test_1
			FETCH next from @cr_test_1 into @uId_Phieudichvu_Chitiet
			while @@FETCH_STATUS = 0
			BEGIN
				begin
					declare @uId_Dichvu varchar(50)
					set @uId_Dichvu = (select uId_Dichvu from TNTP_PHIEUDICHVU_CHITIET where uId_Phieudichvu_Chitiet = @uId_Phieudichvu_Chitiet)
					declare @nv_TenDV nvarchar(50)
					set @nv_TenDV =(select nv_Tendichvu_vn from TNTP_DM_DICHVU where uId_Dichvu = @uId_Dichvu)
					if @nv_TenDV = null
					set @nv_TenDV =(select nv_Tendichvu_en from TNTP_DM_DICHVU where uId_Dichvu = @uId_Dichvu)
					declare @uId_KTV varchar(50)
					set @uId_KTV = (select top 1 uId_Nhanvien from TNTP_QT_Dieutri where uId_Phieudichvu_Chitiet = @uId_Phieudichvu_Chitiet)
					declare @nv_Tuvanvien nvarchar(30)
						set @nv_Tuvanvien = (select nv_Hoten_vn  from QT_DM_NHANVIEN where uId_Nhanvien = @uId_TVV)
					if @nv_Tuvanvien = null
						set @nv_Tuvanvien = (select nv_Hoten_en  from QT_DM_NHANVIEN where uId_Nhanvien = @uId_TVV)
					declare @nv_Kithuatvien nvarchar(30)
						set @nv_Kithuatvien = (select nv_Hoten_vn from QT_DM_NHANVIEN where uId_Nhanvien = @uId_KTV)
					if @nv_Kithuatvien = null
						set @nv_Kithuatvien = (select nv_Hoten_en from QT_DM_NHANVIEN where uId_Nhanvien = @uId_KTV)
					declare @f_Solan float
					set @f_Solan = (select f_Solan from TNTP_PHIEUDICHVU_CHITIET where uId_Phieudichvu_Chitiet = @uId_Phieudichvu_Chitiet)
					declare @f_Giamgia_1 float
					set @f_Giamgia_1 = (select f_Giamgia from TNTP_PHIEUDICHVU_CHITIET where uId_Phieudichvu_Chitiet = @uId_Phieudichvu_Chitiet)
					set @giatien = (select f_Dongia from TNTP_PHIEUDICHVU_CHITIET where uId_Phieudichvu_Chitiet = @uId_Phieudichvu_Chitiet)
					set @f_phantramgiam = ROUND(@f_Giamgia_1/@giatien*100,0)
					set @giatien = @giatien-@f_Giamgia_1
					if @uId_LoaiTT = (select uId_LoaiTT from QLTC_LoaiHinhTT where v_MaLoaiTT = 'TM') 
						set @f_Tienmat = @giatien
					else
						set @f_card = @giatien
					if @f_Giamgia = 0
					insert into #Baocaothang(v_Sophieu,v_SDT,v_Makhachhang,nv_Tuvanvien,nv_Tendichvu,nv_Kithuatvien,nv_Hoten,nv_Diachi,i_Solan,f_no,f_card,f_Tienmat,f_Giamgia,d_Ngay)	
					values(@v_Sophieu,'','',@nv_Tuvanvien,@nv_TenDV,@nv_Kithuatvien,'','',@f_Solan,'',@f_card,@f_Tienmat,@f_phantramgiam,@d_Ngay)
					else
					insert into #Baocaothang(v_Sophieu,v_SDT,v_Makhachhang,nv_Tuvanvien,nv_Tendichvu,nv_Kithuatvien,nv_Hoten,nv_Diachi,i_Solan,f_no,f_card,f_Tienmat,f_Giamgia,d_Ngay)	
					values(@v_Sophieu,'','',@nv_Tuvanvien,@nv_TenDV,@nv_Kithuatvien,'','',@f_Solan,'','','','',@d_Ngay)
					set @f_Giamgia_1 = null
					set @f_Tienmat = null
					set @f_Solan=null
					set @f_card = null
					set @f_phantramgiam = null
					set @giatien = null 
				end
			FETCH NEXT From @cr_test_1 into @uId_Phieudichvu_Chitiet
			END
			close @cr_test_1
			deallocate @cr_test_1
				set @f_Giamgia = null
				set @f_Tienmat = null
				set @f_card = null
				set @f_phantramgiam = null
				set @giatien = null
		end
		end
		FETCH NEXT From @cr_test into @uId_Phieudichvu
	END
	close @cr_test
	deallocate @cr_test
	end
	
	
	--Mat hang
	begin
	--declare @cr_test cursor
	declare @uId_Phieuxuat varchar(50)
	
	set @cr_test = CURSOR for
	(
		select uId_Phieuxuat from QLMH_Phieuxuat
	)
	OPEN @cr_test
	
	FETCH next from @cr_test into @uId_Phieuxuat
	while @@FETCH_STATUS = 0
	BEGIN
		begin
		--PhieuDV
			--declare @v_Sophieu varchar(20)
			set @v_Sophieu =(select v_Maphieuxuat from QLMH_PHIEUXUAT where uId_Phieuxuat = @uId_Phieuxuat)
			--declare @d_Ngay datetime
			set @d_Ngay = (select d_Ngayxuat from QLMH_PHIEUXUAT where uId_Phieuxuat = @uId_Phieuxuat)
			--declare @uId_TVV varchar(50)
			set @uId_TVV = (select uId_Nhanvien from QLMH_PHIEUXUAT where uId_Phieuxuat = @uId_Phieuxuat)
			--declare @uId_LoaiTT varchar(50)
			set @uId_LoaiTT = (select uId_LoaiTT from QLMH_PHIEUXUAT where uId_Phieuxuat = @uId_Phieuxuat)
			--declare @f_no float
			set @f_no = (select f_Sotien from QLCN_CONGNO_SP where uId_Phieuxuat = @uId_Phieuxuat)
		
		--thong tin  khach hang
			--declare @uId_Khachhang varchar(50)
			set @uId_Khachhang = (select uId_Khachhang from QLMH_PHIEUXUAT where uId_Phieuxuat = @uId_Phieuxuat)
			--declare @v_Makhachhang varchar(50)
			set @v_Makhachhang = (select v_Makhachang from CRM_DM_Khachhang where uId_Khachhang = @uId_Khachhang)
			--declare @nv_Hoten nvarchar(50)
			set @nv_Hoten = (select nv_Hoten_vn from CRM_DM_Khachhang where uId_Khachhang = @uId_Khachhang)
				if @nv_Hoten = null
					set @nv_Hoten = (select nv_Hoten_en from CRM_DM_Khachhang where uId_Khachhang = @uId_Khachhang)
			--declare @v_SDT varchar(20)
			set @v_SDT = (select v_DienthoaiDD from CRM_DM_Khachhang where uId_Khachhang = @uId_Khachhang)
				if @v_SDT = null
					set @v_SDT = (select v_Dienthoaikhac from CRM_DM_Khachhang where uId_Khachhang = @uId_Khachhang)
			--declare @nv_Diachi nvarchar(50)
			set @nv_Diachi = (select nv_Diachi_vn from CRM_DM_Khachhang where uId_Khachhang = @uId_Khachhang)
				if @nv_Diachi = null
					set @nv_Diachi = (select nv_Diachi_en from CRM_DM_Khachhang where uId_Khachhang = @uId_Khachhang)
		--so sanh giam gia
			--declare @f_Giamgia float
			--declare @giatien float
			--declare @f_phantramgiam float
			--declare @f_Tienmat float
			--declare @f_card float
			set @f_Giamgia = (select f_Giamgia from QLMH_PHIEUXUAT where uId_Phieuxuat = @uId_Phieuxuat)
			if @f_Giamgia <> 0
			begin
				set @giatien = (select sum(f_Dongia)  from QLMH_PHIEUXUAT_CHITIET where uId_Phieuxuat = @uId_Phieuxuat)
				set @f_phantramgiam = ROUND(@f_Giamgia/@giatien*100,0)
				set @giatien = @giatien-@f_Giamgia
				if @uId_LoaiTT = (select uId_LoaiTT from QLTC_LoaiHinhTT where v_MaLoaiTT = 'TM') 
				set @f_Tienmat = @giatien
				else
				set @f_card = @giatien
			end
			insert into #Baocaothang(v_Sophieu,v_SDT,v_Makhachhang,nv_Tuvanvien,nv_Tendichvu,nv_Kithuatvien,nv_Hoten,nv_Diachi,i_Solan,f_no,f_card,f_Tienmat,f_Giamgia,d_Ngay)	
			values(@v_Sophieu,@v_SDT,@v_Makhachhang,'','','',@nv_Hoten,@nv_Diachi,null,@f_no,@f_card,@f_Tienmat,@f_phantramgiam,@d_Ngay)
		--lap		
		begin
			--declare @cr_test_1 cursor
			declare @uId_Phieuxuat_Chitiet varchar(50)
			set @cr_test_1 = CURSOR for
			(
				select  uId_Phieuxuat_Chitiet
				from QLMH_PHIEUXUAT_CHITIET where uId_Phieuxuat = @uId_Phieuxuat
			)
			OPEN @cr_test_1
			FETCH next from @cr_test_1 into @uId_Phieuxuat_Chitiet
			while @@FETCH_STATUS = 0
			BEGIN
				begin
					--declare @uId_Dichvu varchar(50)
					set @uId_Dichvu = (select uId_Mathang from QLMH_PHIEUXUAT_CHITIET where uId_Phieuxuat_Chitiet = @uId_Phieuxuat_Chitiet)
					--declare @nv_TenDV nvarchar(50)
					set @nv_TenDV =(select nv_TenMathang_vn from QLMH_DM_MATHANG where uId_Mathang = @uId_Dichvu)
					if @nv_TenDV = null
					set @nv_TenDV =(select nv_TenMathang_en from QLMH_DM_MATHANG where uId_Mathang = @uId_Dichvu)
					--declare @nv_Tuvanvien nvarchar(30)
						set @nv_Tuvanvien = (select nv_Hoten_vn  from QT_DM_NHANVIEN where uId_Nhanvien = @uId_TVV)
					if @nv_Tuvanvien = null
						set @nv_Tuvanvien = (select nv_Hoten_en  from QT_DM_NHANVIEN where uId_Nhanvien = @uId_TVV)
					--declare @f_Solan float
					set @f_Solan = (select f_Soluong from QLMH_PHIEUXUAT_CHITIET where uId_Phieuxuat_Chitiet = @uId_Phieuxuat_Chitiet)
					--declare @f_Giamgia_1 float
					set @f_Giamgia_1 = (select f_Giamgia from QLMH_PHIEUXUAT_CHITIET where uId_Phieuxuat_Chitiet = @uId_Phieuxuat_Chitiet)
					set @giatien = (select f_Dongia from QLMH_PHIEUXUAT_CHITIET where uId_Phieuxuat_Chitiet = @uId_Phieuxuat_Chitiet)
					set @f_phantramgiam = ROUND(@f_Giamgia_1/@giatien*100,0)
					set @giatien = @giatien-@f_Giamgia_1
					if @uId_LoaiTT = (select uId_LoaiTT from QLTC_LoaiHinhTT where v_MaLoaiTT = 'TM') 
						set @f_Tienmat = @giatien
					else
						set @f_card = @giatien
					if @f_Giamgia = 0
					insert into #Baocaothang(v_Sophieu,v_SDT,v_Makhachhang,nv_Tuvanvien,nv_Tendichvu,nv_Kithuatvien,nv_Hoten,nv_Diachi,i_Solan,f_no,f_card,f_Tienmat,f_Giamgia,d_Ngay)	
					values(@v_Sophieu,'','',@nv_Tuvanvien,@nv_TenDV,@nv_Kithuatvien,'','',@f_Solan,'',@f_card,@f_Tienmat,@f_phantramgiam,@d_Ngay)
					else
					insert into #Baocaothang(v_Sophieu,v_SDT,v_Makhachhang,nv_Tuvanvien,nv_Tendichvu,nv_Kithuatvien,nv_Hoten,nv_Diachi,i_Solan,f_no,f_card,f_Tienmat,f_Giamgia,d_Ngay)	
					values(@v_Sophieu,'','',@nv_Tuvanvien,@nv_TenDV,@nv_Kithuatvien,'','',@f_Solan,'','','','',@d_Ngay)
					set @f_Giamgia_1 = null
					set @f_Tienmat = null
					set @f_Solan=null
					set @f_card = null
					set @f_phantramgiam = null
					set @giatien = null 
				end
			FETCH NEXT From @cr_test_1 into @uId_Phieudichvu_Chitiet
			END
			close @cr_test_1
			deallocate @cr_test_1
				set @f_Giamgia = null
				set @f_Tienmat = null
				set @f_card = null
				set @f_phantramgiam = null
				set @giatien = null
		end
		end
		FETCH NEXT From @cr_test into @uId_Phieudichvu
	END
	close @cr_test
	deallocate @cr_test
	end
	if @d_Ngay_tim is not null and @d_Ngay_bd is null
	select  v_Sophieu,v_Makhachhang,CONVERT(varchar(10),d_Ngay,103) as 'd_Ngay',nv_Hoten,nv_Diachi,v_SDT,nv_Tendichvu,i_Solan,CAST(f_Giamgia as nvarchar(50))+'%' as 'f_Giamgia',f_Tienmat,f_card,nv_Tuvanvien,nv_Kithuatvien,f_no  from #Baocaothang where DATEDIFF(day,@d_Ngay_tim,#Baocaothang.d_Ngay) <=0 order by #Baocaothang.d_Ngay,#Baocaothang.v_Sophieu ASC
	else if @d_Ngay_tim is null and @d_Ngay_bd is not null
	select  v_Sophieu,v_Makhachhang,CONVERT(varchar(10),d_Ngay,103) as 'd_Ngay',nv_Hoten,nv_Diachi,v_SDT,nv_Tendichvu,i_Solan,CAST(f_Giamgia as nvarchar(50))+'%'as 'f_Giamgia' ,f_Tienmat,f_card,nv_Tuvanvien,nv_Kithuatvien,f_no  from #Baocaothang where DATEDIFF(day,@d_Ngay_bd,#Baocaothang.d_Ngay) >=0 order by #Baocaothang.d_Ngay,#Baocaothang.v_Sophieu ASC
	else if @d_Ngay_tim is not null and @d_Ngay_bd is not null
	select  v_Sophieu,v_Makhachhang,CONVERT(varchar(10),d_Ngay,103) as 'd_Ngay',nv_Hoten,nv_Diachi,v_SDT,nv_Tendichvu,i_Solan,CAST(f_Giamgia as nvarchar(50))+'%' as 'f_Giamgia',f_Tienmat,f_card,nv_Tuvanvien,nv_Kithuatvien,f_no  from #Baocaothang where DATEDIFF(day,@d_Ngay_bd,#Baocaothang.d_Ngay) >=0 and DATEDIFF(day,@d_Ngay_tim,#Baocaothang.d_Ngay) <=0 order by #Baocaothang.d_Ngay,#Baocaothang.v_Sophieu ASC

END

--execute BaoCaoDichvu_Thang '04/01/2015'

