Imports CefSharp.WinForms
Imports CefSharp
Imports System.ComponentModel

Public Class JCPreviewForm
    Private m_JcId As String
    Private m_SignIdStr As String
    Private m_Flag As Int16 = 0
    Public Property JcId As String
        Get
            Return m_JcId
        End Get
        Set(value As String)
            m_JcId = value
        End Set
    End Property

    Public Property SignIdStr As String
        Get
            Return m_SignIdStr
        End Get
        Set(value As String)
            m_SignIdStr = value
        End Set
    End Property

    Private webBrowser As ChromiumWebBrowser

    Private Sub InitWebBrowser()
        Dim JcUrl As String = XmlLoadMD.XmlLoad(Application.StartupPath & "\../../../Conf/config.xml", "conf/weburl").Trim() & "/jc/" & m_JcId & ".html" 'ConfigurationManager.AppSettings("FileURL").ToString() & m_JcId & ".html"

        'Dim JcUrl As String = "http://10.1.99.77/jc/" & m_JcId & ".html"
        Dim FileUrl As String = XmlLoadMD.XmlLoad(Application.StartupPath & "\../../../Conf/config.xml", "conf/filrurl").Trim() & m_JcId & ".html"
        Me.ModifyFile(m_JcId)
        webBrowser = New ChromiumWebBrowser(JcUrl)

        Dim CertPlugin As CertClass = New CertClass() ' 注册签名插件
        webBrowser.RegisterAsyncJsObject("CertPlugin", CertPlugin)
        'webBrowser.MenuHandler = New ContextMenuHandler()

        Me.Panel_JcPreview.Controls.Add(webBrowser)
        webBrowser.Dock = DockStyle.Fill
        AddHandler Me.webBrowser.IsBrowserInitializedChanged, AddressOf Me.OnIsBrowserInitializedChanged
        AddHandler Me.webBrowser.LoadingStateChanged, AddressOf Me.OnLoadingStateChanged
    End Sub

    Private Sub OnIsBrowserInitializedChanged(sender As Object, args As IsBrowserInitializedChangedEventArgs)
        If args.IsBrowserInitialized Then
            'webBrowser.Reload()
        End If
    End Sub

    Private Sub OnLoadingStateChanged(sender As Object, args As LoadingStateChangedEventArgs)
        If Not args.IsLoading Then
            Dim itemArr() As Object = {GlobalClass.UserObj.UserSignId, GlobalClass.UserObj.UserSignSn} '参数传递
            Dim rtnFromJs As Task(Of CefSharp.JavascriptResponse) = Me.webBrowser.EvaluateScriptAsync("signInfo", itemArr)
        End If
    End Sub

    Private Sub JCPreviewForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        InitWebBrowser()
    End Sub

    Private Sub JCPreviewForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Me.Close()
    End Sub

    ''' <summary>
    ''' 将签名图片插入工卡
    ''' </summary>
    ''' <param name="jcid"></param>
    Private Sub ModifyFile(jcid As String)

        Dim parmArr() As String = {"", "", "", ""}
        parmArr = CommonMD.ConnectFileServer()
        Dim filePath As String = "\\" & parmArr(0) & "\" & parmArr(1) & "\" & jcid & ".html"

        If String.IsNullOrEmpty(m_SignIdStr) Then
            Return
        End If
        If m_SignIdStr.StartsWith(";") Then
            m_SignIdStr = m_SignIdStr.TrimStart(";")
        End If
        'If path.StartsWith("file") Then
        '    path = path.Replace("file:///", "").Replace("/", "\")
        'End If
        Try
            Dim fStream As New IO.FileStream(filePath, IO.FileMode.Open)
            Dim sReader As New IO.StreamReader(fStream, System.Text.Encoding.UTF8)
            Dim fileStrSB As New Text.StringBuilder
            Do
                fileStrSB.AppendLine(sReader.ReadLine())
            Loop While sReader.Peek <> -1
            Dim fileStr = fileStrSB.ToString()

            Dim signIdArr() As String = m_SignIdStr.Split(";")
            Dim pos As Integer = 0
            Dim divPos As Integer = 0
            For i As Integer = 0 To signIdArr.Length - 1
                Dim idArr() As String = signIdArr(i).Split(",")
                If fileStr.Contains(idArr(0)) Then
                    pos = fileStr.IndexOf(idArr(0))
                    divPos = fileStr.IndexOf("</div>", pos)
                    If pos >= divPos Then
                        Continue For
                    End If
                    Dim subStr As String = fileStr.Substring(pos, divPos - pos)
                    If subStr.Contains("img") Then
                        Continue For
                    End If

                    Dim str = "<img style="" width:50px; height:25px;"" src=""" + m_JcId + ".files/" + idArr(1) + ".png"" />"
                    fileStr = fileStr.Insert(divPos - 1, str)

                End If
            Next

            sReader.Close()
            fStream.Close()

            Dim fileWriter As IO.StreamWriter = New IO.StreamWriter(filePath, False, System.Text.Encoding.UTF8)
            fileWriter.Write(fileStr)
            fileWriter.Close()

        Catch ex As Exception
            MessageBox.Show("读取文件失败！" & ex.ToString(), "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

End Class