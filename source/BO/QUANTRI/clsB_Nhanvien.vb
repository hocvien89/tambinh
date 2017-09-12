Public Class clsB_Nhanvien
    Dim IQT_DM_NHANVIEN As DB.iClisD_Nhanvien = New DB.clsD_Nguoidung

    Public Function SelectAll_Admin_QT_DM_NHANVIEN() As DataTable
        Return IQT_DM_NHANVIEN.SelectAll_Admin
    End Function

    Public Function SelectAllQT_DM_NHANVIEN() As DataTable
        Return IQT_DM_NHANVIEN.SelectAll
    End Function

    Public Function InsertQT_DM_NHANVIEN(ByVal QT_DM_NHANVIEN As CM.cls_Nhanvien) As Boolean
        Return IQT_DM_NHANVIEN.Insert(QT_DM_NHANVIEN)
    End Function

    Public Function UpdateQT_DM_NHANVIEN(ByVal QT_DM_NHANVIEN As CM.cls_Nhanvien) As Boolean
        Return IQT_DM_NHANVIEN.Update(QT_DM_NHANVIEN)
    End Function

    Public Function DeleteQT_DM_NHANVIENByID(ByVal uId_Nhanvien As String) As Boolean
        Return IQT_DM_NHANVIEN.DeleteByID(uId_Nhanvien)
    End Function

    Public Function SelectQT_DM_NHANVIENByID(ByVal uId_Nhanvien As String) As CM.cls_Nhanvien
        Return IQT_DM_NHANVIEN.SelectByID(uId_Nhanvien)
    End Function

#Region "NMT- Kiem tra dang nhap"
    Public Function chk_CheckLogin(ByVal oCls_Nhansu As CM.cls_Nhanvien)
        'Create by: Minh Thang, 2011.09.01
        'NMT - Fun: Ham check mot user co quyen dang nhap hay khong
        'Update by: 
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Dim bKT As Boolean = False

        Dim DR() As DataRow = SelectAll_Admin_QT_DM_NHANVIEN().Select("v_Tendangnhap='" & oCls_Nhansu.v_Tendangnhap & "' and v_Matkhau='" & oCls_Nhansu.v_Matkhau & "'")
        If DR.Length > 0 Then bKT = True
        Return bKT

    End Function

    Public Function chk_CheckIDDangky(ByVal oCls_Nhansu As CM.cls_Nhanvien)

        Dim bKT As Boolean = False

        Dim DR() As DataRow = SelectAllQT_DM_NHANVIEN().Select("v_Tendangnhap='" & oCls_Nhansu.v_Tendangnhap & "'")
        If DR.Length > 0 Then bKT = True
        Return bKT

    End Function

    Public Function chk_CheckEmailDangky(ByVal oCls_Nhansu As CM.cls_Nhanvien)

        Dim bKT As Boolean = False

        Dim DR() As DataRow = SelectAllQT_DM_NHANVIEN().Select("v_Email='" & oCls_Nhansu.v_Email & "'")
        If DR.Length > 0 Then bKT = True
        Return bKT

    End Function

    Public Function chk_GetIDLogin(ByVal oCls_Nhansu As CM.cls_Nhanvien)
        'Create by: Minh Thang, 2011.09.01
        'NMT - Fun: Ham check mot user co quyen dang nhap hay khong
        'Update by: 
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Dim id As String = ""

        Dim DR() As DataRow = SelectAll_Admin_QT_DM_NHANVIEN().Select("v_Tendangnhap='" & oCls_Nhansu.v_Tendangnhap & "' and v_Matkhau='" & oCls_Nhansu.v_Matkhau & "'")
        If DR.Length > 0 Then
            id = DR(0).Item(0).ToString()
        End If
        Return id
    End Function


    Public Function chk_GetIDCuahangLogin(ByVal oCls_Nhansu As CM.cls_Nhanvien)
        'Create by: Minh Thang, 2011.09.01
        'NMT - Fun: Ham check mot user co quyen dang nhap hay khong
        'Update by: 
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        Dim id As String = ""

        Dim DR() As DataRow = SelectAll_Admin_QT_DM_NHANVIEN().Select("v_Tendangnhap='" & oCls_Nhansu.v_Tendangnhap & "' and v_Matkhau='" & oCls_Nhansu.v_Matkhau & "'")
        If DR.Length > 0 Then
            id = DR(0).Item("uId_Cuahang").ToString()
        End If
        Return id
    End Function


#End Region


End Class
