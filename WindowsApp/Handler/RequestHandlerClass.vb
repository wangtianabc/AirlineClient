Imports System.Security.Cryptography.X509Certificates
Imports CefSharp

Public Class RequestHandlerClass
    Implements IRequestHandler
    Private filter As New ResponseFilterClass

    Public Sub OnPluginCrashed(browserControl As IWebBrowser, browser As IBrowser, pluginPath As String) Implements IRequestHandler.OnPluginCrashed

    End Sub

    Public Sub OnRenderProcessTerminated(browserControl As IWebBrowser, browser As IBrowser, status As CefTerminationStatus) Implements IRequestHandler.OnRenderProcessTerminated

    End Sub

    Public Sub OnResourceRedirect(browserControl As IWebBrowser, browser As IBrowser, frame As IFrame, request As IRequest, response As IResponse, ByRef newUrl As String) Implements IRequestHandler.OnResourceRedirect

    End Sub

    Public Sub OnRenderViewReady(browserControl As IWebBrowser, browser As IBrowser) Implements IRequestHandler.OnRenderViewReady
        
    End Sub

    Public Sub OnResourceLoadComplete(browserControl As IWebBrowser, browser As IBrowser, frame As IFrame, request As IRequest, response As IResponse, status As UrlRequestStatus, receivedContentLength As Long) Implements IRequestHandler.OnResourceLoadComplete

    End Sub

    Public Function OnBeforeBrowse(browserControl As IWebBrowser, browser As IBrowser, frame As IFrame, request As IRequest, isRedirect As Boolean) As Boolean Implements IRequestHandler.OnBeforeBrowse
        Return False
    End Function

    Public Function OnOpenUrlFromTab(browserControl As IWebBrowser, browser As IBrowser, frame As IFrame, targetUrl As String, targetDisposition As WindowOpenDisposition, userGesture As Boolean) As Boolean Implements IRequestHandler.OnOpenUrlFromTab
        Throw New NotImplementedException()
    End Function

    Public Function OnCertificateError(browserControl As IWebBrowser, browser As IBrowser, errorCode As CefErrorCode, requestUrl As String, sslInfo As ISslInfo, callback As IRequestCallback) As Boolean Implements IRequestHandler.OnCertificateError
        Throw New NotImplementedException()
    End Function

    Public Function OnBeforeResourceLoad(browserControl As IWebBrowser, browser As IBrowser, frame As IFrame, request As IRequest, callback As IRequestCallback) As CefReturnValue Implements IRequestHandler.OnBeforeResourceLoad
        Return CefReturnValue.Continue
    End Function

    Public Function GetAuthCredentials(browserControl As IWebBrowser, browser As IBrowser, frame As IFrame, isProxy As Boolean, host As String, port As Integer, realm As String, scheme As String, callback As IAuthCallback) As Boolean Implements IRequestHandler.GetAuthCredentials
        Throw New NotImplementedException()
    End Function

    Public Function OnSelectClientCertificate(browserControl As IWebBrowser, browser As IBrowser, isProxy As Boolean, host As String, port As Integer, certificates As X509Certificate2Collection, callback As ISelectClientCertificateCallback) As Boolean Implements IRequestHandler.OnSelectClientCertificate
        Throw New NotImplementedException()
    End Function

    Public Function OnQuotaRequest(browserControl As IWebBrowser, browser As IBrowser, originUrl As String, newSize As Long, callback As IRequestCallback) As Boolean Implements IRequestHandler.OnQuotaRequest
        Throw New NotImplementedException()
    End Function

    Public Function OnProtocolExecution(browserControl As IWebBrowser, browser As IBrowser, url As String) As Boolean Implements IRequestHandler.OnProtocolExecution
        Throw New NotImplementedException()
    End Function

    Public Function OnResourceResponse(browserControl As IWebBrowser, browser As IBrowser, frame As IFrame, request As IRequest, response As IResponse) As Boolean Implements IRequestHandler.OnResourceResponse
        Try
            Dim contentLength As Int16 = CInt(response.ResponseHeaders("Content-Length"))
            If Me.filter IsNot Nothing Then
                Me.filter.SetContentLength(contentLength)
            End If
        Catch ex As Exception

        End Try
        Return False
    End Function

    Public Function GetResourceResponseFilter(browserControl As IWebBrowser, browser As IBrowser, frame As IFrame, request As IRequest, response As IResponse) As IResponseFilter Implements IRequestHandler.GetResourceResponseFilter
        Return Me.filter
    End Function
End Class
