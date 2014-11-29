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

' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802
Imports System.Web.Http
'Imports System.Web.Optimization

Public Class WebApiApplication
    Inherits System.Web.HttpApplication
    Private Shared Sub EnableCrossDomain()
        Dim origin As String = HttpContext.Current.Request.Headers("Origin")
        If String.IsNullOrEmpty(origin) Then
            Return
        End If
        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", origin)
        Dim method As String = HttpContext.Current.Request.Headers("Access-Control-Request-Method")
        If (Not String.IsNullOrEmpty(method)) Then
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", method)
        End If
        Dim headers As String = HttpContext.Current.Request.Headers("Access-Control-Request-Headers")
        If (Not String.IsNullOrEmpty(headers)) Then
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", headers)
        End If
        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Credentials", "true")
        If HttpContext.Current.Request.HttpMethod = "OPTIONS" Then
            HttpContext.Current.Response.StatusCode = 204
            HttpContext.Current.Response.End()
        End If
    End Sub
    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        WebApiConfig.Register(GlobalConfiguration.Configuration)
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
    End Sub
    Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        EnableCrossDomain()
    End Sub
End Class
