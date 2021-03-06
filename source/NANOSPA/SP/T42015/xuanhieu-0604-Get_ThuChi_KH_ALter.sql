
ALTER FUNCTION [dbo].[Get_ThuChi_KH](@uId_Khachhang uniqueidentifier)
RETURNS float
as
Begin
	Declare @ValReturn float
	--Lay tien phieu dich vu
	SET @ValReturn = isnull((SELECT sum(ptc.[f_Sotien])
	--	FROM QLTC_Phieuthuchi tc INNER JOIN QLCN_CONGNO_THANHTOAN cntt ON tc.uId_Phieuthuchi = cntt.uId_Phieuthuchi
	--	LEFT JOIN TNTP_PHIEUDICHVU pdv ON cntt.uId_Phieuno = pdv.uId_Phieudichvu --Ban 2015 thay = uId_Phieuno
	--where  pdv.uId_Khachhang = @uId_Khachhang)
	from QLTC_Phieuthuchi ptc, QLCN_CONGNO_THANHTOAN cntt,  TNTP_PHIEUDICHVU pdv, CRM_DM_Khachhang kh
	where ptc.uId_Phieuthuchi=cntt.uId_Phieuthuchi 
	and cntt.uId_Phieuno=pdv.uId_Phieudichvu 
	and pdv.uId_Khachhang=kh.uId_Khachhang
	and pdv.uId_Khachhang=@uId_Khachhang),0)
	-- lay tien phieu xuat
	SET @ValReturn += isnull((SELECT sum(ptc.[f_Sotien])
	--	FROM QLTC_Phieuthuchi tc INNER JOIN QLCN_CONGNO_THANHTOAN cntt ON tc.uId_Phieuthuchi = cntt.uId_Phieuthuchi
	--	LEFT JOIN QLMH_PHIEUXUAT px ON cntt.uId_Phieuno = px.uId_Phieuxuat --Ban 2015 thay = uId_Phieuno
	--where  px.uId_Khachhang = @uId_Khachhang)
	from QLTC_Phieuthuchi ptc, QLCN_CONGNO_THANHTOAN cntt,  QLMH_PHIEUXUAT px, CRM_DM_Khachhang kh
	where ptc.uId_Phieuthuchi=cntt.uId_Phieuthuchi 
	and cntt.uId_Phieuno=px.uId_Phieuxuat 
	and px.uId_Khachhang=kh.uId_Khachhang and px.uId_Khachhang=@uId_Khachhang),0)
	return ISNULL(@ValReturn,0)
End
