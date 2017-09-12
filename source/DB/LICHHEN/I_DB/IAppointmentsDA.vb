Public Interface IAppointmentsDA

    Function SelectAll() As List(Of CM.AppointmentsEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal UniqueID As Int32) As CM.AppointmentsEntity

    Function Insert(ByVal obj As CM.AppointmentsEntity) As Boolean

    Function DeleteByID(ByVal UniqueID As Int32) As Boolean

    Function Update(ByVal obj As CM.AppointmentsEntity) As Boolean

    Function SelectWarming(ByVal NumOfTime As Integer) As System.Data.DataTable

    Function SelectByDate(ByVal TuNgay As String, ByVal DenNgay As String, ByVal uId_Cuahang As String, ByVal Trangthai As Integer, nv_tenkhachhang_vn As String, ByVal uId_Phong As String) As System.Data.DataTable

    Function SelectByID_Table(Id As String) As DataTable

    Function Kiemtralichhentrung(Resource As String, dStart As Date, dEnd As Date, uId_Nhanvien As String) As DataTable

    Function Kiemtratrungphongdichvu(Resource As String, dStart As Date, dEnd As Date) As Boolean

    Function Kiemtralichhentrung_Kythuat(Resource As String, dStart As Date, dEnd As Date, uId_Nhanvien As String) As DataTable

End Interface