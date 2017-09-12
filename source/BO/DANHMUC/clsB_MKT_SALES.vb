Public Class clsB_MKT_SALES
    Dim ICRM_MKT_SALE As DB.iclsD_MKT_SALES = New DB.clsD_MKT_SALES

    Function Insert(obj As CM.icls_MKT_SALES) As Boolean
        Return ICRM_MKT_SALE.Insert(obj)
    End Function

    Function Select_All_Table() As DataTable
        Return ICRM_MKT_SALE.Select_All_Table()
    End Function

    Function DeleteByID(uId_Sale As String) As Boolean
        Return ICRM_MKT_SALE.DeleteByID(uId_Sale)
    End Function

    Function Select_ByID(uId_Sale As String) As DataTable
        Return ICRM_MKT_SALE.Select_ByID(uId_Sale)
    End Function

    Function Update(obj As CM.icls_MKT_SALES) As Boolean
        Return ICRM_MKT_SALE.Update(obj)
    End Function

    Function Search_By_Date(d_Tungay As Date, d_Denngay As Date) As DataTable
        Return ICRM_MKT_SALE.Search_By_Date(d_Tungay, d_Denngay)
    End Function

    Function Select_Khuyenmai_Defualt() As DataTable
        Return ICRM_MKT_SALE.Select_Khuyenmai_Defualt()
    End Function

End Class
