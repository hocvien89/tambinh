
ALTER proc [dbo].[spTTV_DM_THETICHDIEM_SelectAllTable]
@uId_Cuahang as nvarchar(50)='24E1A59B-F645-4240-9A31-D91A90E58793'
as
begin
	if @uId_Cuahang	is null
		select uId_Thetichdiem,
			nv_Tenthetichdiem,
			f_Diemkichhoat,
			ch.nv_Tencuahang_vn,
			v_Mathetichdiem ,
			f_Sotiendoi,
			i_Sodiemdoi
		from TTV_DM_THETICHDIEM ttd, QT_DM_CUAHANG ch
	else 
		select uId_Thetichdiem,
			nv_Tenthetichdiem,
			f_Diemkichhoat,
			ch.nv_Tencuahang_vn, 
			v_Mathetichdiem,
			f_Sotiendoi,
			i_Sodiemdoi 
		from TTV_DM_THETICHDIEM ttd, QT_DM_CUAHANG ch 
		where ttd.uId_Cuahang=@uId_Cuahang and 
			ttd.uId_Cuahang = ch.uId_Cuahang
end