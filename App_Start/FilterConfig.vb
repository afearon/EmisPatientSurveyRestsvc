' Developer Express Code Central Example:
' How to implement the Rest service based on an ASP.NET WebAPI application
' 
' This example demonstrates how to implement the Rest service based on an ASP.NET
' WebAPI application.
' See also:
' http://www.devexpress.com/scid=KA18633
' Creating
' a REST service using ASP.NET Web API
' (http://www.codeproject.com/Articles/426769/Creating-a-REST-service-using-ASP-NET-Web-API)
' An
' Introduction To RESTful Services With WCF
' (http://msdn.microsoft.com/en-us/magazine/dd315413.aspx)
' http://www.devexpress.com/scid=E4816
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E4462

Imports System.Web
Imports System.Web.Mvc

Public Class FilterConfig
    Public Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
        filters.Add(New HandleErrorAttribute())
    End Sub
End Class