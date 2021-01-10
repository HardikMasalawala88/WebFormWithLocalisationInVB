Imports System.Globalization
Imports System.Threading
Imports Microsoft.VisualBasic

Public Class BasePage
    Inherits System.Web.UI.Page

    Protected Overrides Sub InitializeCulture()
        Dim language As String = "en-us"

        If HttpContext.Current.Request.Cookies("Language") IsNot Nothing Then
            Dim cookie As HttpCookie = HttpContext.Current.Request.Cookies("Language")

            If cookie IsNot Nothing Then
                language = cookie.Value.Split("="c)(1)
            End If
        End If


        'Check if PostBack is caused by Language DropDownList.
        If Request.Form("__EVENTTARGET") IsNot Nothing AndAlso Request.Form("__EVENTTARGET").Contains("ddlLanguages") Then
            'Set the Language.
            language = Request.Form(Request.Form("__EVENTTARGET"))
        End If


        'Set the Culture.
        Thread.CurrentThread.CurrentCulture = New CultureInfo(language)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(language)
    End Sub

End Class
