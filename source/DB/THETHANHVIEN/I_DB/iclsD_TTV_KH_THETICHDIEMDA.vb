Public Interface iclsD_TTV_KH_THETICHDIEMDA
    Function SelectAllTable() As DataTable

    Function Insert(objEnKHThe As CM.icls_TTV_KH_ThetichdiemEntity) As String

    Function DeleteById(uId_KH_The As String) As Boolean

    Function Update(objEnKHThe As CM.icls_TTV_KH_ThetichdiemEntity) As Boolean

    Function SelectKHThe(uId_Cuahang As String) As DataTable

    Function CheckKH(uId_Khachhang As String) As DataTable

    Function UpdatePoint(f_Tongtichluy As Double, f_Diemhientai As Double, uid_KHThe As String) As Boolean

    Function CheckMathe() As DataTable

    Function SelectPointById(uid_KH_The As String) As DataTable

    Function Khoathe(uid_kh_the As String, b_trangthai As Boolean) As Boolean

    Function Huythe(uid_kh_the As String, b_isdelete As Boolean) As Boolean

    Function SelectByIdKH(uId_Khachhang As String) As DataTable

    Function SelectName(uId_Khachhang As String) As DataTable

End Interface
