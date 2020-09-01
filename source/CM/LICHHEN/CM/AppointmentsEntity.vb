Public Class AppointmentsEntity
    Implements IAppointmentsEntity


    Private _UniqueID As Int32
    Private _Type As Int32
    Private _StartDate As DateTime
    Private _StartDateB As String
    Private _EndDate As DateTime
    Private _EndDateB As String
    Private _AllDay As Boolean
    Private _Subject As String
    Private _Location As String
    Private _Description As String
    Private _Status As Int32
    Private _Label As Int32
    Private _ResourceID As String
    Private _ResourceIDs As String
    Private _ReminderInfo As String
    Private _RecurrenceInfo As String
    Private _CustomField1 As String
    Private _dt_Sys As DateTime
    Private _uId_Nhanvien As String
    Private _uId_Cuahang As String
    Private _uId_Phieudichvu_Chitiet As String

    Public Property UniqueID() As Int32 Implements IAppointmentsEntity.UniqueID
        Get
            Return _UniqueID
        End Get
        Set(ByVal value As Int32)
            _UniqueID = value
        End Set
    End Property

    Public Property Type() As Int32 Implements IAppointmentsEntity.Type
        Get
            Return _Type
        End Get
        Set(ByVal value As Int32)
            _Type = value
        End Set
    End Property

    Public Property StartDate() As DateTime Implements IAppointmentsEntity.StartDate
        Get
            Return _StartDate
        End Get
        Set(ByVal value As DateTime)
            _StartDate = value
        End Set
    End Property

    Public Property StartDateB() As String
        Get
            If (_StartDate = Nothing) Then
                Return String.Empty
            Else
                Return CStr(Format(_StartDate, "dd/MM/yyyy"))
            End If
        End Get
        Set(ByVal value As String)
            _StartDate = value
        End Set
    End Property

    Public Property EndDate() As DateTime Implements IAppointmentsEntity.EndDate
        Get
            Return _EndDate
        End Get
        Set(ByVal value As DateTime)
            _EndDate = value
        End Set
    End Property

    Public Property EndDateB() As String
        Get
            If (_EndDate = Nothing) Then
                Return String.Empty
            Else
                Return CStr(Format(_EndDate, "dd/MM/yyyy"))
            End If
        End Get
        Set(ByVal value As String)
            _EndDate = value
        End Set
    End Property

    Public Property AllDay() As Boolean Implements IAppointmentsEntity.AllDay
        Get
            Return _AllDay
        End Get
        Set(ByVal value As Boolean)
            _AllDay = value
        End Set
    End Property

    Public Property Subject() As String Implements IAppointmentsEntity.Subject
        Get
            Return _Subject
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _Subject = String.Empty
            Else
                _Subject = value.Trim
            End If
        End Set
    End Property

    Public Property Location() As String Implements IAppointmentsEntity.Location
        Get
            Return _Location
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _Location = String.Empty
            Else
                _Location = value.Trim
            End If
        End Set
    End Property

    Public Property Description() As String Implements IAppointmentsEntity.Description
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _Description = String.Empty
            Else
                _Description = value.Trim
            End If
        End Set
    End Property

    Public Property Status() As Int32 Implements IAppointmentsEntity.Status
        Get
            Return _Status
        End Get
        Set(ByVal value As Int32)
            _Status = value
        End Set
    End Property

    Public Property Label() As Int32 Implements IAppointmentsEntity.Label
        Get
            Return _Label
        End Get
        Set(ByVal value As Int32)
            _Label = value
        End Set
    End Property

    Public Property ResourceID() As String Implements IAppointmentsEntity.ResourceID
        Get
            Return _ResourceID
        End Get
        Set(ByVal value As String)
            _ResourceID = value
        End Set
    End Property

    Public Property ResourceIDs() As String Implements IAppointmentsEntity.ResourceIDs
        Get
            Return _ResourceIDs
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _ResourceIDs = String.Empty
            Else
                _ResourceIDs = value.Trim
            End If
        End Set
    End Property

    Public Property ReminderInfo() As String Implements IAppointmentsEntity.ReminderInfo
        Get
            Return _ReminderInfo
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _ReminderInfo = String.Empty
            Else
                _ReminderInfo = value.Trim
            End If
        End Set
    End Property

    Public Property RecurrenceInfo() As String Implements IAppointmentsEntity.RecurrenceInfo
        Get
            Return _RecurrenceInfo
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _RecurrenceInfo = String.Empty
            Else
                _RecurrenceInfo = value.Trim
            End If
        End Set
    End Property

    Public Property CustomField1() As String Implements IAppointmentsEntity.CustomField1
        Get
            Return _CustomField1
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _CustomField1 = String.Empty
            Else
                _CustomField1 = value.Trim
            End If
        End Set
    End Property

    Public Property dt_Sys() As Date Implements IAppointmentsEntity.dt_Sys
        Get
            Return _dt_Sys
        End Get
        Set(value As Date)
            _dt_Sys = value
        End Set
    End Property

    Public Property uId_Cuahang() As String Implements IAppointmentsEntity.uId_Cuahang
        Get
            Return _uId_Cuahang
        End Get
        Set(value As String)
            _uId_Cuahang = value
        End Set
    End Property
    Public Property uId_Nhanvien() As String Implements IAppointmentsEntity.uId_Nhanvien
        Get
            Return _uId_Nhanvien
        End Get
        Set(value As String)
            _uId_Nhanvien = value
        End Set
    End Property

    Public Property uId_Phieudichvu_Chitiet As String Implements IAppointmentsEntity.uId_Phieudichvu_Chitiet
        Get
            Return _uId_Phieudichvu_Chitiet
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Phieudichvu_Chitiet = String.Empty
            Else
                _uId_Phieudichvu_Chitiet = value.Trim
            End If
        End Set
    End Property
End Class
