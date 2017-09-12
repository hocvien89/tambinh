Imports System
Imports System.IO
Imports System.Data
Imports System.Web
Public Class Util
    Public Shared Function FormatDateTime(ByVal dt As Object) As String
        Return String.Format("{0:dd/MM/yyyy | HH:mm}", dt)
    End Function
    Public Shared Function FormatNearTime(ByVal dt As Object) As String
        Dim ts As New TimeSpan()
        ts = DateTime.Now - Convert.ToDateTime(dt)
        If ts.Days > 0 AndAlso ts.Days <= 1 Then
            Return "Hôm qua"
        Else
            If ts.Days > 1 Then
                Return FormatDateTime(dt)
            Else
                If ts.Minutes + ts.Hours * 60 > 60 Then
                    Return ts.Hours & " giờ trước"
                Else

                    Return ts.Minutes & " phút trước"
                End If
            End If
        End If
    End Function
#Region "[Cắt chuỗi không mất từ]"
    Public Shared Function SplipText(ByVal text As String, ByVal length As Integer) As String
        Dim cat As String = text
        Dim khoangcach As Integer = 0
        If cat.Length > length Then
            Dim i As Integer = 0
            While i < cat.Length
                If cat(i) = " "c Then
                    If i <= length Then
                        khoangcach = i
                    Else
                        Exit While
                    End If
                End If
                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
            End While
            If khoangcach <> 0 Then
                cat = cat.Substring(0, khoangcach) + "..."
            Else
                cat = cat.Substring(0, length) + "..."

            End If
        End If
        Return cat
    End Function
#End Region
    Public Shared Function ConvertDateTime(ByVal text As String) As DateTime
        Dim str As String = ""
        If text Is Nothing OrElse text = "" Then
            str = DateTime.Now.ToString()
        Else
            str = text.Split("/"c)(1).ToString() + "/" + text.Split("/"c)(0).ToString() + "/" + text.Split("/"c)(2).ToString()
        End If
        Return Convert.ToDateTime(str)
    End Function
    Public Shared Function ConvertDateTimeWithHour(ByVal text As String) As DateTime
        Dim str As String = ""
        Dim time As String = ""
        Dim TT As String = ""
        If text Is Nothing OrElse text = "" Then
            str = DateTime.Now.ToString()
        Else
            time = text.Substring(11, 5)
            TT = text.Substring(16, 2)
            If TT = "PM" Then

            End If
            text = text.Substring(0, 10)
            str = text.Split("/"c)(1).ToString() + "/" + text.Split("/"c)(0).ToString() + "/" + text.Split("/"c)(2).ToString()
            str = str & " " & time
        End If
        Return Convert.ToDateTime(str)
    End Function
    Public Shared Function IsDouble(ByVal input As String) As Double
        Dim str As String = ""
        If input Is Nothing OrElse input = "" Then
            str = "0"
        Else
            str = input
        End If
        Return Val(str)
    End Function
    Public Shared Function IsString(ByVal input As String) As String
        Dim str As String = ""
        If input Is Nothing Then
            str = ""
        Else
            str = input
        End If
        Return str
    End Function
End Class
