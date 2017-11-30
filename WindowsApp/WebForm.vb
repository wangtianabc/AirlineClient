Imports CefSharp
Imports CefSharp.WinForms
'Imports System.Configuration

Public Class WebForm
    Private webBrowser As ChromiumWebBrowser
    Private initFlag As Boolean = False

    Private Sub InitWebBrowser()
        Dim settings As New CefSettings()
        settings.Locale = "zh-CN"
        'settings.CachePath = "/BrowserCache"
        'settings.LogFile = "/LogData"
        'settings.PersistSessionCookies = True
        'settings.UserDataPath = "/UserData"

        settings.LogSeverity = LogSeverity.Verbose
        CefSharp.Cef.Initialize(settings)
        Dim WebURL As String = XmlLoadMD.XmlLoad(Application.StartupPath & "\../../../Conf/config.xml", "conf/weburl").Trim() 'ConfigurationManager.AppSettings("WebURL").ToString()

        webBrowser = New ChromiumWebBrowser(WebURL)
        webBrowser.BrowserSettings.DefaultEncoding = "UTF-8"
        webBrowser.BrowserSettings.WebGl = CefState.Disabled

        'webBrowser = New ChromiumWebBrowser("file:///D:/AirlineClient/WindowsApp/2.html")
        Me.Panel_Web.Controls.Add(webBrowser)
        webBrowser.Dock = DockStyle.Fill
        '注册异步调研组件到JS
        'Dim asyncPlugin As AsyncClass = New AsyncClass()
        'webBrowser.RegisterAsyncJsObject("AsyncPlugin", asyncPlugin)
        Dim CertPlugin As CertClass = New CertClass() ' 注册签名插件
        webBrowser.RegisterAsyncJsObject("CertPlugin", CertPlugin)
        webBrowser.RequestHandler = New RequestHandlerClass()
        webBrowser.MenuHandler = New ContextMenuHandler()

        AddHandler Me.webBrowser.LoadingStateChanged, AddressOf Me.OnLoadingStateChanged
        AddHandler Me.webBrowser.IsBrowserInitializedChanged, AddressOf Me.OnIsBrowserInitializedChanged

    End Sub

    Private Sub ToolStripMenuItem_Exit_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_Exit.Click
        Try
            If initFlag Then
                '        webBrowser.CloseDevTools()
                'webBrowser.GetBrowser().CloseBrowser(True)
                If webBrowser IsNot Nothing Then
                    'Application.Exit()
                    webBrowser.Dispose()
                    'CefSharp.Cef.Shutdown()
                    'webBrowser.GetBrowser().CloseBrowser(True)
                End If
            End If
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub

    Private Sub WebForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.InitWebBrowser()
    End Sub
    ''' <summary>
    ''' 异步调用javascript方法/事件(无返回值)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ToolStripMenuItem_Login_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_Login.Click
        Me.webBrowser.ExecuteScriptAsync("login.click()")
    End Sub


    Private Sub OnLoadingStateChanged(sender As Object, args As LoadingStateChangedEventArgs)

    End Sub

    Private Sub OnIsBrowserInitializedChanged(sender As Object, args As IsBrowserInitializedChangedEventArgs)
        If args.IsBrowserInitialized Then
            initFlag = True
        End If
    End Sub

    ''' <summary>
    ''' 异步调用JS方法(有返回值)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        Dim itemArr() As Object = {"a", "b", "c"} '参数传递
        Dim rtnFromJs As Task(Of CefSharp.JavascriptResponse) = Me.webBrowser.EvaluateScriptAsync("test", itemArr) 'JS 方法名：function test(x,y,z)
        While Not rtnFromJs.IsCompleted
            rtnFromJs.Wait()
        End While

        If rtnFromJs.Result.Success Then
            MessageBox.Show(rtnFromJs.Result.Result.ToString())
        End If

        'Dim rtnFromJs As Task(Of CefSharp.JavascriptResponse) = Me.GetJsRtn()
        'If rtnFromJs.Result.Success Then
        '    MessageBox.Show(rtnFromJs.Result.Result.ToString())
        'End If
    End Sub

    Async Function GetJsRtn() As Task(Of CefSharp.JavascriptResponse)
        Dim itemArr() As Object = {"a", "b", "c"} '参数传递
        Dim rtnFromJs As JavascriptResponse = Await Me.webBrowser.EvaluateScriptAsync("test", itemArr)
        Return rtnFromJs
    End Function

    Private Sub ToolStripMenuItem_Refresh_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_Refresh.Click
        Me.webBrowser.Reload()
    End Sub

    Private Sub ToolStripMenuItem_Sqlite_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_Sqlite.Click
        Dim obj As New SqliteForm
        obj.Show()
    End Sub

End Class
