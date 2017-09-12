Public Class MKT_CongviecEntity
    Implements IMKT_CongviecEntity

    Private _uId_Congviec As String
    Private _uId_MaCongviec As String
    Private _d_Ngay As DateTime
    Private _d_NgayB As String
    Private _nv_Noidung As String
    Private _uId_KH_Tiemnang As String
    Private _uId_Nhanvien As String
    Private _Tags As String

    Public Property uId_Congviec() As String Implements IMKT_CongviecEntity.uId_Congviec
        Get
            Return _uId_Congviec
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Congviec = String.Empty
            Else
                _uId_Congviec = value.Trim
            End If
        End Set
    End Property

    Public Property uId_MaCongviec() As String Implements IMKT_CongviecEntity.uId_MaCongviec
        Get
            Return _uId_MaCongviec
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_MaCongviec = String.Empty
            Else
                _uId_MaCongviec = value.Trim
            End If
        End Set
    End Property

    Public Property d_Ngay() As DateTime Implements IMKT_CongviecEntity.d_Ngay
        Get
            Return _d_Ngay
        End Get
        Set(ByVal value As DateTime)
            _d_Ngay = value
        End Set
    End Property

    Public Property d_NgayB() As String
        Get
            If (_d_Ngay = Nothing) Then
                Return String.Empty
            Else
                Return CStr(Format(_d_Ngay, "dd/MM/yyyy"))
            End If
        End Get
        Set(ByVal value As String)
            _d_Ngay = value
        End Set
    End Property

    Public Property nv_Noidung() As String Implements IMKT_CongviecEntity.nv_Noidung
        Get
            Return _nv_Noidung
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Noidung = String.Empty
            Else
                _nv_Noidung = value.Trim
            End If
        End Set
    End Property

    Public Property uId_KH_Tiemnang() As String Implements IMKT_CongviecEntity.uId_KH_Tiemnang
        Get
            Return _uId_KH_Tiemnang
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_KH_Tiemnang = String.Empty
            Else
                _uId_KH_Tiemnang = value.Trim
            End If
        End Set
    End Property
    Private _LoaiCuocGoi As String
    Public Property LoaiCuocGoi() As String Implements IMKT_CongviecEntity.LoaiCuocGoi
        Get
            Return _LoaiCuocGoi
        End Get
        Set(ByVal value As String)
            _LoaiCuocGoi = value
        End Set
    End Property
    Private _TrangThaiCongViec As String
    Public Property TrangThaiCongViec() As String Implements IMKT_CongviecEntity.TrangThaiCongViec
        Get
            Return _TrangThaiCongViec
        End Get
        Set(ByVal value As String)
            _TrangThaiCongViec = value
        End Set
    End Property
    Private _DVKHQuantam As String
    Public Property DVKHQuantam() As String Implements IMKT_CongviecEntity.DVKHQuantam
        Get
            Return _DVKHQuantam
        End Get
        Set(ByVal value As String)
            _DVKHQuantam = value
        End Set
    End Property

    Public Property uId_Nhanvien() As String Implements IMKT_CongviecEntity.uId_Nhanvien
        Get
            Return _uId_Nhanvien
        End Get
        Set(ByVal value As String)
            _uId_Nhanvien = value
        End Set
    End Property

    Public Property Tags() As String Implements IMKT_CongviecEntity.Tags
        Get
            Return _Tags
        End Get
        Set(ByVal value As String)
            _Tags = value
        End Set
    End Property
End Class
