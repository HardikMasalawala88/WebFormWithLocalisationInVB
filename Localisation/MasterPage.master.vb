Imports System
Imports System.Web
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not Me.IsPostBack Then
            Dim language As String = "en-us"

            If HttpContext.Current.Request.Cookies("Language") IsNot Nothing Then
                Dim cookie As HttpCookie = HttpContext.Current.Request.Cookies("Language")

                If cookie IsNot Nothing Then
                    language = cookie.Value.Split("="c)(1)
                End If
            End If

            Me.ddlLanguages.Items.FindByValue(language.ToLower()).Selected = True
        End If
    End Sub

    Protected Sub ChangeLanguage(ByVal sender As Object, ByVal e As EventArgs)
        Dim languageCookie As HttpCookie = New HttpCookie("Language")
        languageCookie.Values("LanguageCode") = Me.ddlLanguages.SelectedValue
        languageCookie.Expires = Date.Now.AddDays(30)
        HttpContext.Current.Response.Cookies.Add(languageCookie)
        Me.Response.Redirect(Request.Url.AbsoluteUri)
    End Sub
End Class

