Public Interface iclsD_MKT_SALES
    Function Insert(obj As CM.icls_MKT_SALES) As Boolean
    Function Select_All_Table() As DataTable

    Function DeleteByID(uId_Sale As String) As Boolean

    Function Select_ByID(uId_Sale As String) As DataTable

    Function Update(obj As CM.icls_MKT_SALES) As Boolean

    Function Search_By_Date(d_Tungay As Date, d_Denngay As Date) As DataTable

    Function Select_Khuyenmai_Defualt() As DataTable

End Interface
