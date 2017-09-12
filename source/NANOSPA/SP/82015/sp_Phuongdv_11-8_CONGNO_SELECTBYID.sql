create proc sp_QLTC_CONGNO_TT_SelectByID_PDV
	@uId_Phieudichvu nvarchar(50)
as
select Sum(cn.f_Sotien_Nolai) as f_Sotien from QLCN_CONGNO_THANHTOAN cn inner join TNTP_PHIEUDICHVU pdv on cn.uId_Phieuno = pdv.uId_Phieudichvu where uId_Phieudichvu=@uId_Phieudichvu
