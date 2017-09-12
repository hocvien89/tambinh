Public Interface IAppointmentsEntity

    Property UniqueID() As Int32

    Property Type() As Int32

    Property StartDate() As DateTime

    Property EndDate() As DateTime

    Property AllDay() As Boolean

    Property Subject() As String

    Property Location() As String

    Property Description() As String

    Property Status() As Int32

    Property Label() As Int32

    Property ResourceID() As Int32

    Property ResourceIDs() As String

    Property ReminderInfo() As String

    Property RecurrenceInfo() As String

    Property CustomField1() As String


    Property uId_Nhanvien() As String

    Property uId_Cuahang() As String

    Property dt_Sys() As DateTime

    Property uId_Phieudichvu_Chitiet As String

End Interface