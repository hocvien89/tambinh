select mkt.uId_KH_Tiemnang, mkt.nv_Hoten_vn, dmp.nv_Tenphong_vn from 
MKT_KH_TIEMNANG mkt,
CRM_DM_Khachhang kh,
QT_DM_NHANVIEN nv,
PQP_NHANVIEN_PHONG pnv,
QLP_DM_PHONG dmp,
PQP_TRANGTHAIKHCHOXULY chosl
where mkt.uId_Khachhang=kh.uId_Khachhang
and mkt.nv_Diachi_en=nv.uId_Nhanvien
and nv.uId_Nhanvien=pnv.uId_Nhanvien
and pnv.uId_Phongban=dmp.uId_Phong

select * from QLP_DM_PHONG

select * from MKT_KH_TIEMNANG
select * from PQP_TRANGTHAIKHCHOXULY
select * from MKT_TRANGTHAIKH where uId_TrangthaiKH='BB9262C9-8993-4D04-9757-963FE5F81AC5'
select * from CRM_DM_TRANGTHAI where uId_Trangthai='715AE9DB-98A3-47B1-9EE5-52D6DB7D895F'

delete from MKT_KH_TIEMNANG
delete from CRM_DM_Khachhang
delete from TNTP_PHIEUDICHVU
delete from TNTP_PHIEUDICHVU_CHITIET
delete from PQP_TRANGTHAIKHCHOXULY
delete from QLCN_CONGNO
delete from QLCN_CONGNO_THANHTOAN
delete from QLTC_Phieuthuchi
delete from TTV_KH_THETICHDIEM
delete from QLMH_PHIEUNHAP
delete from QLMH_PHIEUXUAT_CHITIET
delete from QLMH_PHIEUNHAP_CHITIET
delete from QLMH_PHIEUXUAT
delete from TNTP_CHECKINCHECKOUT
delete from TNTP_KHACHHANG_GOIDICHVU

select * from QT_DM_CUAHANG
