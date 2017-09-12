Public Class LoyaltyCard_Catelory
    Inherits System.Web.UI.Page
    Private objEnThetichdiem As CM.cls_DM_ThetichdiemEntity
    Private objFcThetichdiem As BO.clsB_TTV_DM_THETICHDIEM
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
        loaddata()
    End Sub
#Region "load du lieu"
    Private Sub loaddata()
        objFcThetichdiem = New BO.clsB_TTV_DM_THETICHDIEM
        Dim uid_cuahang As String
        Dim dt As DataTable
        uid_cuahang = Session("uId_Cuahang")
        Try
            dt = objFcThetichdiem.SelectAllTable(uid_cuahang)
            Grid_LoyaltyCard.DataSource = dt
            Grid_LoyaltyCard.DataBind()
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "Function"
    Private Function checkInsert(mathe As String) As Integer
        Dim dt As DataTable
        objFcThetichdiem = New BO.clsB_TTV_DM_THETICHDIEM
        Dim i As Integer = 0
        dt = objFcThetichdiem.SelectAllTable(Session("uId_Cuahang"))
        Try
            If dt.Rows.Count = 0 Then
                Return i
            Else
                For Each row As DataRow In dt.Rows
                    If mathe = row("v_Mathetichdiem").ToString Then
                        i += 1
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
        Return i
    End Function

    Private Function checkUpdate(mathe As String, uid_thetichdiem As String) As Integer
        Dim dt As DataTable
        objFcThetichdiem = New BO.clsB_TTV_DM_THETICHDIEM
        Dim i As Integer = 0
        Dim k As Integer = 0
        dt = objFcThetichdiem.SelectAllTable(Session("uId_Thetichdiem"))
        Try
            For Each row As DataRow In dt.Rows
                If row("uid_Thetichdiem").ToString = uid_thetichdiem Then
                    If row("v_Mathetichdiem").ToString = mathe Then
                        Return i ' duoc up date ma the giu nguyen
                    Else
                        For j As Integer = 0 To dt.Rows.Count - 1 Step 1
                            If dt.Rows(j)("v_Mathetichdiem").ToString <> mathe Then
                                k += 1
                            End If
                        Next
                        If k < dt.Rows.Count Then
                            i += 1
                        End If
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
        Return i
    End Function
#End Region
#Region "Grid event"
    Protected Sub Grid_LoyaltyCard_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        objEnThetichdiem = New CM.cls_DM_ThetichdiemEntity
        objFcThetichdiem = New BO.clsB_TTV_DM_THETICHDIEM
        Try
            With objEnThetichdiem
                .uId_Cuahang = Session("uId_Cuahang")
                .nv_Tenthetichdiem = e.NewValues("nv_Tenthetichdiem")
                .f_Diemkichhoat = e.NewValues("f_Diemkichhoat")
                '.f_Sotiendoi = e.NewValues("f_Sotiendoi")
                '.i_Sodiemdoi = e.NewValues("i_Sodiemdoi")
                If checkInsert(e.NewValues("v_Mathetichdiem")) = 0 Then
                    .v_Mathetichdiem = e.NewValues("v_Mathetichdiem")
                Else
                    Return
                End If
                .f_Uutien = e.NewValues("f_Uutien")
            End With
            objFcThetichdiem.Insert(objEnThetichdiem)
            Grid_LoyaltyCard.CancelEdit()
            e.Cancel = True
        Catch ex As Exception

        End Try
        loaddata()
    End Sub

    Protected Sub Grid_LoyaltyCard_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        objEnThetichdiem = New CM.cls_DM_ThetichdiemEntity
        objFcThetichdiem = New BO.clsB_TTV_DM_THETICHDIEM
        Dim uId_Thetichdiem As String
        uId_Thetichdiem = e.Keys(0).ToString
        Try
            With objEnThetichdiem
                .uId_Thetichdiem = uId_Thetichdiem
                .uId_Cuahang = Session("uId_Cuahang")
                '.f_Sotiendoi = e.NewValues("f_Sotiendoi")
                '.i_Sodiemdoi = e.NewValues("i_Sodiemdoi")
                If checkUpdate(e.NewValues("v_Mathetichdiem"), uId_Thetichdiem) = 0 Then
                    .v_Mathetichdiem = e.NewValues("v_Mathetichdiem")
                Else
                    Return
                End If
                .nv_Tenthetichdiem = e.NewValues("nv_Tenthetichdiem")
                .f_Diemkichhoat = e.NewValues("f_Diemkichhoat")
                .f_Uutien = e.NewValues("f_Uutien")
            End With
            objFcThetichdiem.Update(objEnThetichdiem)
            Grid_LoyaltyCard.CancelEdit()
            e.Cancel = True
        Catch ex As Exception

        End Try
        loaddata()
    End Sub

    Protected Sub Grid_LoyaltyCard_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFcThetichdiem = New BO.clsB_TTV_DM_THETICHDIEM
        Dim uId_Thetichdiem As String
        uId_Thetichdiem = e.Keys(0).ToString
        Try
            objFcThetichdiem.Delete(uId_Thetichdiem)
            Grid_LoyaltyCard.CancelEdit()
            e.Cancel = True
        Catch ex As Exception

        End Try
        loaddata()
    End Sub
#End Region
   
End Class