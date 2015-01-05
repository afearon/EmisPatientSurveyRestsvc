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

Imports System.Net
Imports System.Web.Http

Public Class referralfeedbacksController
    Inherits ApiController
    Private _context As CRMEntities
    Public Sub New()
        _context = New CRMEntities()
    End Sub
    Public Function [Get]() As IEnumerable(Of referralfeedback)
        Return _context.referralfeedbacks.AsEnumerable()
    End Function
    Public Function [Get](ByVal id As Integer) As referralfeedback
        Return _context.referralfeedbacks.Find(id)
    End Function
    Public Function Post(ByVal feed As referralfeedback) As Integer
        _context.referralfeedbacks.Add(feed)

        'check to see if a survey record exsists in the table for this patient based on event or feedid?
        Dim existingPatientSurveysCount = _context.referralfeedbacks.Count(Function(a) a.EventID = feed.EventID)
        ' ok in this instance the sp_REFERRAL_InsUpDFeedback will check if an insert or an update is appropriate and perform each operation
        ' If existingPatientSurveysCount = 0 Then
        'set the created date to now
        feed.feed_CreatedDate = Now

        'add a new record to the table using the built in stored procedure for Madcap
        _context.sp_REFERRAL_InsUpDFeedback(feed.feed_leadid, feed.feed_CreatedBy, feed.feed_feedbackreceived, feed.feed_feedbackcomments, feed.feed_complications, feed.feed_ComplicationDetails, feed.feed_expecteddiagnosis, feed.feed_diagnosiscomments, feed.feed_GPComments)

        'do the below if your only adding a new record to the table directly
        '_context.referralfeedbacks.Add(feed)
        ' Else
        'do the update
        'Put(feed)
        'End If
        Return _context.SaveChanges()
    End Function
    Public Function Put(ByVal feed As referralfeedback) As Integer


        ' ok in this instance the sp_REFERRAL_InsUpDFeedback will check if an insert or an update is appropriate and perform each operation
        ' If existingPatientSurveysCount = 0 Then
        'set the created date to now
        feed.feed_CreatedDate = Now

        'add/update record in the referralfeedback table using the built in stored procedure for Madcap
        _context.sp_REFERRAL_InsUpDFeedback(feed.feed_leadid, feed.feed_CreatedBy, feed.feed_feedbackreceived, feed.feed_feedbackcomments, feed.feed_complications, feed.feed_ComplicationDetails, feed.feed_expecteddiagnosis, feed.feed_diagnosiscomments, feed.feed_GPComments)


        Return _context.SaveChanges()
    End Function
    Public Function Delete(ByVal id As Integer) As Integer
        Dim feedb As referralfeedback = _context.referralfeedbacks.Find(id)
        _context.referralfeedbacks.Remove(feedb)
        Return _context.SaveChanges()
    End Function


    Public Function GetReferralFeedback(ByVal eventid As String) As IEnumerable(Of sp_GetEmisPatientSurveyInfo_Result)


        Dim results As New List(Of sp_GetEmisPatientSurveyInfo_Result)()

        For Each EmisReferralFeedback As sp_GetEmisPatientSurveyInfo_Result In Me._context.sp_GetEmisPatientSurveyInfo(Convert.ToString(eventid)).AsQueryable()


            'localStorage.setItem("Pers_PersonId", data[0].Lead_PrimaryPersonId);
            '   localStorage.setItem("Oppo_CustomerRef", data[0].feed_opportunityid);
            '   localStorage.setItem("furt_EventID", data[0].furt_EventID);
            '   localStorage.setItem("Oppo_OpportunityId", data[0].feed_opportunityid);
            '   localStorage.setItem("Consultant_fullname", data[0].Consultant);
            '   localStorage.setItem("furt_conultantid", data[0].furt_conultantid);
            '   localStorage.setItem("furt_FurtherID", data[0].furt_FurtherID);


            '   //not sure we need these
            '   localStorage.setItem("Pers_FullName", data[0].Lead_PersonName);
            '   localStorage.setItem("oppo_consultdate", data[0].oppo_consultdate)




            results.Add(New sp_GetEmisPatientSurveyInfo_Result() With { _
                .Lead_LeadID = EmisReferralFeedback.Lead_LeadID, _
                .Lead_CreatedBy = EmisReferralFeedback.Lead_CreatedBy, _
                .feed_feedbackreceived = EmisReferralFeedback.feed_feedbackreceived, _
                .feed_feedbackcomments = EmisReferralFeedback.feed_feedbackcomments, _
                .feed_complications = EmisReferralFeedback.feed_complications, _
                .feed_ComplicationDetails = EmisReferralFeedback.feed_ComplicationDetails, _
                .feed_expecteddiagnosis = EmisReferralFeedback.feed_expecteddiagnosis, _
                .feed_diagnosiscomments = EmisReferralFeedback.feed_diagnosiscomments, _
                .feed_GPComments = EmisReferralFeedback.feed_GPComments, _
                .Lead_PrimaryPersonID = EmisReferralFeedback.Lead_PrimaryPersonID, _
                .furt_conultantid = EmisReferralFeedback.furt_conultantid, _
                .Consultant = EmisReferralFeedback.Consultant, _
                .feed_opportunityid = EmisReferralFeedback.feed_opportunityid, _
                .feed_leadid = EmisReferralFeedback.feed_leadid, _
                .lead_gpreference = EmisReferralFeedback.lead_gpreference, _
                .Lead_PersonName = EmisReferralFeedback.Lead_PersonName, _
                .Lead_Description = EmisReferralFeedback.Lead_Description, _
                .oppo_dischargedate = EmisReferralFeedback.oppo_dischargedate, _
                .lead_personmobilenumber = EmisReferralFeedback.lead_personmobilenumber
            })
        Next

        Return results
    End Function

End Class
