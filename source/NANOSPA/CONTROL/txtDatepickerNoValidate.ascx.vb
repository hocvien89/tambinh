Public Partial Class txtDatepickerNoValidate
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Property Text() As String
        Get
            Return txtDatePicker.Text.Trim()
        End Get
        Set(ByVal value As String)
            txtDatePicker.Text = value
        End Set
    End Property

    Public Property Width() As Unit
        Get
            Return txtDatePicker.Width
        End Get
        Set(ByVal value As Unit)
            txtDatePicker.Width = value
        End Set
    End Property

    Public ReadOnly Property IsValidDate() As Boolean
        Get
            If [String].IsNullOrEmpty(txtDatePicker.Text.Trim()) Then
                Return False
            End If

            Try
                Dim month As String() = New String() {"Jan", "Feb", "Mar", "Apr", "May", "Jun", _
                 "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
                Dim [date] As String() = txtDatePicker.Text.Trim().Split("/"c)

                Dim temp As DateTime = Convert.ToDateTime([date](0) & " " & month(Convert.ToInt32([date](1)) - 1) & " " & [date](2))
            Catch
                Return False
            End Try
            Return True
        End Get
    End Property

    Public Property SelectedDate() As DateTime
        Get
            Try
                Dim month As String() = New String() {"Jan", "Feb", "Mar", "Apr", "May", "Jun", _
                 "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
                Dim [date] As String() = txtDatePicker.Text.Trim().Split("/"c)

                Return Convert.ToDateTime([date](0) & " " & month(Convert.ToInt32([date](1)) - 1) & " " & [date](2))
            Catch
                Return DateTime.MinValue
            End Try
        End Get
        Set(ByVal value As DateTime)
            If value <> DateTime.MinValue Then
                txtDatePicker.Text = value.ToString("dd/MM/yyyy")
            Else
                txtDatePicker.Text = ""
            End If
        End Set
    End Property

    Public Sub SetReadOnly(ByVal stt As Boolean)
        txtDatePicker.ReadOnly = stt
    End Sub

End Class