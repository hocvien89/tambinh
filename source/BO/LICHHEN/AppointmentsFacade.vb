Public Class AppointmentsFacade


    Dim IAppointments As DB.IAppointmentsDA = New DB.AppointmentsDA

    Public Function SelectAll() As List(Of CM.AppointmentsEntity)
        Return IAppointments.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IAppointments.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.AppointmentsEntity) As Boolean
        Return IAppointments.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.AppointmentsEntity) As Boolean
        Return IAppointments.Update(obj)
    End Function

    Public Function DeleteByID(ByVal UniqueID As Int32) As Boolean
        Return IAppointments.DeleteByID(UniqueID)
    End Function

    Public Function SelectByID(ByVal UniqueID As Int32) As CM.AppointmentsEntity
        Return IAppointments.SelectByID(UniqueID)
    End Function

    Public Function SelectWarming(NumOfTime As Integer) As System.Data.DataTable
        Return IAppointments.SelectWarming(NumOfTime)
    End Function

    Function SelectByDate(ByVal TuNgay As String, ByVal DenNgay As String, ByVal uId_Cuahang As String, ByVal Trangthai As Integer, nv_Tenkhachhang_vn As String, uId_Phong As String) As System.Data.DataTable
        Return IAppointments.SelectByDate(TuNgay, DenNgay, uId_Cuahang, Trangthai, nv_Tenkhachhang_vn, uId_Phong)
    End Function

    Function SelectByID_Table(Id As String) As DataTable
        Return IAppointments.SelectByID_Table(Id)
    End Function

    Function Kiemtralichhentrung(Resource As String, dStart As Date, dEnd As Date, uId_Nhanvien As String) As DataTable
        Return IAppointments.Kiemtralichhentrung(Resource, dStart, dEnd, uId_Nhanvien)
    End Function

    Function Kiemtratrungphongdichvu(Resource As String, dStart As Date, dEnd As Date) As Boolean
        Return IAppointments.Kiemtratrungphongdichvu(Resource, dStart, dEnd)
    End Function

    Function Kiemtralichhentrung_Kythuat(Resource As String, dStart As Date, dEnd As Date, uId_Nhanvien As String) As DataTable
        Return IAppointments.Kiemtralichhentrung_Kythuat(Resource, dStart, dEnd, uId_Nhanvien)
    End Function

End Class