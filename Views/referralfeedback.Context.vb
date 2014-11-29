﻿'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Linq

Partial Public Class CRMEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=CRMEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Property referralfeedbacks() As DbSet(Of referralfeedback)

    Public Overridable Function sp_GetEmisPatientSurveyInfo(eventID As String) As ObjectResult(Of sp_GetEmisPatientSurveyInfo_Result)
        Dim eventIDParameter As ObjectParameter = If(eventID IsNot Nothing, New ObjectParameter("EventID", eventID), New ObjectParameter("EventID", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_GetEmisPatientSurveyInfo_Result)("sp_GetEmisPatientSurveyInfo", eventIDParameter)
    End Function

    Public Overridable Function sp_REFERRAL_InsUpDFeedback(leadId As Nullable(Of Integer), createdBy As Nullable(Of Integer), feedBackReceived As String, feedBackComments As String, complications As String, complicationDetails As String, expectedDiagnosis As String, diagnosisComments As String, gPComments As String) As Integer
        Dim leadIdParameter As ObjectParameter = If(leadId.HasValue, New ObjectParameter("LeadId", leadId), New ObjectParameter("LeadId", GetType(Integer)))

        Dim createdByParameter As ObjectParameter = If(createdBy.HasValue, New ObjectParameter("CreatedBy", createdBy), New ObjectParameter("CreatedBy", GetType(Integer)))

        Dim feedBackReceivedParameter As ObjectParameter = If(feedBackReceived IsNot Nothing, New ObjectParameter("FeedBackReceived", feedBackReceived), New ObjectParameter("FeedBackReceived", GetType(String)))

        Dim feedBackCommentsParameter As ObjectParameter = If(feedBackComments IsNot Nothing, New ObjectParameter("FeedBackComments", feedBackComments), New ObjectParameter("FeedBackComments", GetType(String)))

        Dim complicationsParameter As ObjectParameter = If(complications IsNot Nothing, New ObjectParameter("Complications", complications), New ObjectParameter("Complications", GetType(String)))

        Dim complicationDetailsParameter As ObjectParameter = If(complicationDetails IsNot Nothing, New ObjectParameter("ComplicationDetails", complicationDetails), New ObjectParameter("ComplicationDetails", GetType(String)))

        Dim expectedDiagnosisParameter As ObjectParameter = If(expectedDiagnosis IsNot Nothing, New ObjectParameter("ExpectedDiagnosis", expectedDiagnosis), New ObjectParameter("ExpectedDiagnosis", GetType(String)))

        Dim diagnosisCommentsParameter As ObjectParameter = If(diagnosisComments IsNot Nothing, New ObjectParameter("DiagnosisComments", diagnosisComments), New ObjectParameter("DiagnosisComments", GetType(String)))

        Dim gPCommentsParameter As ObjectParameter = If(gPComments IsNot Nothing, New ObjectParameter("GPComments", gPComments), New ObjectParameter("GPComments", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_REFERRAL_InsUpDFeedback", leadIdParameter, createdByParameter, feedBackReceivedParameter, feedBackCommentsParameter, complicationsParameter, complicationDetailsParameter, expectedDiagnosisParameter, diagnosisCommentsParameter, gPCommentsParameter)
    End Function

End Class
