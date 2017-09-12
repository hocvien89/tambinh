drop proc [spQT_DM_NHANVIEN_DoanhThu_Thuchien]
go 
create proc [spQT_DM_NHANVIEN_DoanhThu_Thuchien]
(
@TuNgay as datetime = '11/17/2014',
@DenNgay as datetime = '11/24/2015',
@uId_Nhanvien AS VARCHAR(50) = '0'
)
as
begin 
	create table #Nhanvien(uId_Nhanvien nvarchar(50), uId_Dichvu nvarchar(50))
	create table #Temp(uId_Nhanvien nvarchar(50), uId_Dichvu nvarchar(50))
	create table #HoahongNVC
	(
		uId_Nhanvien nvarchar(50),
		uId_Dichvu nvarchar(50),
		f_Hoahong_NVC float,
		i_Solan_NVC integer,
		f_Hoahong_NVP float,
		i_Solan_NVP integer,
	)	
	create table #HoahongNVP
	(
		uId_Nhanvien nvarchar(50),
		uId_Dichvu nvarchar(50),
		f_Hoahong_NVP float,
		i_Solan_NVP integer
	)			
	begin
		insert into #Temp
		select distinct qtdt.uId_Nhanvien, uId_Dichvu from TNTP_QT_Dieutri qtdt, TNTP_PHIEUDICHVU_CHITIET pct
		where @TuNgay<=d_Ngaydieutri and d_Ngaydieutri<=@DenNgay and qtdt.uId_Nhanvien=(case @uId_Nhanvien when '0' then qtdt.uId_Nhanvien else @uId_Nhanvien end)
		and qtdt.uId_Phieudichvu_Chitiet=pct.uId_Phieudichvu_Chitiet
	end
	begin
		insert into #Temp
		select distinct qtdt.nv_Noidung, uId_Dichvu from TNTP_QT_Dieutri qtdt, TNTP_PHIEUDICHVU_CHITIET pct
		where @TuNgay<=d_Ngaydieutri and d_Ngaydieutri<=@DenNgay and qtdt.nv_Noidung=(case @uId_Nhanvien when '0' then nv_Noidung else @uId_Nhanvien end)
		and qtdt.uId_Phieudichvu_Chitiet=pct.uId_Phieudichvu_Chitiet
	end
	begin 
		insert into #Nhanvien 
		select distinct uId_Nhanvien,uId_Dichvu from #Temp
	end
	begin
		insert into #HoahongNVC
		select distinct nv.uId_Nhanvien, nv.uId_Dichvu,
		dbo.Get_Solan_NVC(nv.uId_Nhanvien, nv.uId_Dichvu) *dv.f_PhantramHH_KTV,
		dbo.Get_Solan_NVC(nv.uId_Nhanvien, nv.uId_Dichvu),
		dbo.Get_Solan_NVP(nv.uId_Nhanvien, nv.uId_Dichvu) *dv.f_PhantramHH_NV,
		dbo.Get_Solan_NVP(nv.uId_Nhanvien, nv.uId_Dichvu)
		from #Nhanvien nv, TNTP_DM_DICHVU dv, TNTP_PHIEUDICHVU_CHITIET pct, TNTP_QT_Dieutri dt
		where dv.uId_Dichvu=nv.uId_Dichvu and dt.uId_Phieudichvu_Chitiet=pct.uId_Phieudichvu_Chitiet
		--and nv.uId_Nhanvien=dt.uId_Nhanvien
	end
	begin
		insert into #HoahongNVP
		select distinct nv.uId_Nhanvien, nv.uId_Dichvu,
		dbo.Get_Solan_NVP(nv.uId_Nhanvien, nv.uId_Dichvu) *dv.f_PhantramHH_NV,
		dbo.Get_Solan_NVP(nv.uId_Nhanvien, nv.uId_Dichvu)
		from #Temp nv, TNTP_DM_DICHVU dv, TNTP_PHIEUDICHVU_CHITIET pct, TNTP_QT_Dieutri dt
		where dv.uId_Dichvu=nv.uId_Dichvu and dt.uId_Phieudichvu_Chitiet=pct.uId_Phieudichvu_Chitiet
		and nv.uId_Nhanvien=dt.nv_Noidung
		
	end
	/*begin 
		insert into #Hoahong
		select distinct nv.uId_Nhanvien, pct.uId_Dichvu,
		0,
		0,
		dbo.Get_Solan_NVP(nv.uId_Nhanvien,nv.uId_Dichvu)* dv.f_PhantramHH_NV,
		dbo.Get_Solan_NVP(nv.uId_Nhanvien,nv.uId_Dichvu),
		2
		from #Nhanvien nv, TNTP_DM_DICHVU dv, TNTP_PHIEUDICHVU_CHITIET pct, TNTP_QT_Dieutri dt
		where dv.uId_Dichvu=pct.uId_Dichvu and dt.uId_Phieudichvu_Chitiet=pct.uId_Phieudichvu_Chitiet
		and nv.uId_Nhanvien=dt.nv_Noidung
	end*/
	delete from #HoahongNVC where i_Solan_NVC=0  and i_Solan_NVP=0
	select nv.nv_Hoten_vn, dv.nv_Tendichvu_vn,
	ndv.nv_TennhomDichvu_vn,nv.v_Manhanvien,
	f_Hoahong_NVC,f_Gia, i_Solan_NVC,i_Solan_NVP,f_Hoahong_NVP
	from QT_DM_NHANVIEN nv, TNTP_DM_DICHVU dv, #HoahongNVC hh, TNTP_DM_NHOMDICHVU ndv
	where dv.uId_Nhomdichvu=ndv.uId_Nhomdichvu 
	and hh.uId_Dichvu=dv.uId_Dichvu
	and nv.uId_Nhanvien=hh.uId_Nhanvien
	order by nv_Hoten_vn, nv_Tendichvu_vn
end
go		
	