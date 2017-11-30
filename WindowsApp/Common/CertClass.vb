Imports CefSharp
Imports System.Threading

Public Class CertClass
    Private iTrusPTA As New PTALib.iTrusPTA
    Public ErrorMsg As String = ""
    Private initCert As PTALib.Certificate

    ''' <summary>
    ''' 检查是否有用户的签名证书
    ''' </summary>
    ''' <param name="serialNumber">来自JS查询</param>
    Public Sub checkUSBAuthor(ByVal successCallback As IJavascriptCallback, ByVal errorCallback As IJavascriptCallback, ByVal serialNumber As String)
        ErrorMsg = ""
        Dim signature As String = ""
        'MsgBox("PTALib.iTrusPTA Before")
        iTrusPTA = New PTALib.iTrusPTA

        Dim cert As PTALib.Certificate = getCert(serialNumber)

        If cert Is Nothing Then
            errorCallback.ExecuteAsync("0")
            Exit Sub
        End If
        '签名一个任意数据，要求用户输入PIN码
        Try
            signature = cert.SignMessage("aaa")
        Catch ex As Exception
            errorCallback.ExecuteAsync("0")
            Exit Sub
        End Try
        If String.IsNullOrEmpty(signature) Then
            errorCallback.ExecuteAsync("0")
            Exit Sub
        End If

        successCallback.ExecuteAsync()
    End Sub

    ''' <summary>
    ''' 检查是否有用户的签名证书,以确定用户已经插入了USBKey,并确定USBKey中包含当前用户的证书
    ''' </summary>
    ''' <param name="serialNumber"></param>
    ''' <returns></returns>
    Public Function CheckUSBKey(ByVal serialNumber As String) As Boolean
        iTrusPTA = New PTALib.iTrusPTA
        ErrorMsg = ""

        If getCert(serialNumber) Is Nothing Then
            Return False
        End If
        Return True
    End Function

    Public Sub InitialCert(ByVal serialNumber As String)
        initCert = getCert(serialNumber)
    End Sub

    Public Sub DisposeCert()
        initCert = Nothing
    End Sub

    ''' <summary>
    ''' 从USB-Key中获取本人的证书
    ''' </summary>
    ''' <param name="serialNumber"></param>
    ''' <returns></returns>
    Private Function getCert(ByVal serialNumber As String) As PTALib.Certificate

        If String.IsNullOrEmpty(serialNumber) Then
            ErrorMsg = "调用错误,缺少memberid参数"
            Return Nothing
        End If

        Dim Certs As PTALib.Certificates = iTrusPTA.MyCertificates
        Dim resultCert As PTALib.Certificate = Nothing
        For i As Integer = 1 To Certs.Count
            Dim curSerial As String = CType(Certs(i), PTALib.Certificate).SerialNumber
            If curSerial.ToLower = serialNumber.PadLeft(curSerial.Length, "0").ToLower Then
                resultCert = Certs(i)
            End If
        Next
        '未找到匹配的证书
        If resultCert Is Nothing Then
            ErrorMsg = "没有查找到USB-Key中的签名证书(No cert found in USB-Key)! " & vbCrLf & "SN=" & serialNumber
            Return Nothing
        End If
        Return resultCert
    End Function

    ''' <summary>
    ''' 使用USB-Key中本人的证书签名数据
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <param name="serialNumber"></param>
    Public Sub signMessage(ByVal successCallback As IJavascriptCallback, ByVal errorCallback As IJavascriptCallback, ByVal msg As String, ByVal serialNumber As String)
        iTrusPTA = New PTALib.iTrusPTA
        ErrorMsg = ""
        '从USB-Key中查找到相应的
        Dim signature As String = ""

        Dim cert As PTALib.Certificate
        If initCert Is Nothing Then
            cert = getCert(serialNumber)
        Else
            cert = initCert
        End If

        If cert Is Nothing Then
            errorCallback.ExecuteAsync()
            Return
        End If
        '签名信息
        Try
            signature = cert.SignMessage(msg)
        Catch ex As Exception
            ErrorMsg = ex.Message
            errorCallback.ExecuteAsync()
            Return
        End Try

        successCallback.ExecuteAsync(signature)
    End Sub

    '利用委托解决线程调用问题
    Delegate Sub OpenPreviewFmCallBack(jcid As String, signIdStr As String)

    Public Sub jcPreview(ByVal jcid As String, ByVal signIdStr As String)
        Dim jcPreviewTS As ThreadStart = New ThreadStart(Sub() OpenPreviewFm(jcid, signIdStr)) '(AddressOf OpenPreviewFm)
        Dim previewThread As Thread = New Thread(jcPreviewTS, jcid)
        previewThread.Name = "PreviewJC"
        previewThread.Start()
    End Sub

    Private Sub OpenPreviewFm(jcid As String, signIdStr As String)
        Open(jcid, signIdStr)
    End Sub

    Private Sub Open(ByVal jcid As String, ByVal signIdStr As String)
        Dim PreviewObj As New JCPreviewForm
        If PreviewObj.InvokeRequired Then
            Dim previewCallBack As OpenPreviewFmCallBack = New OpenPreviewFmCallBack(AddressOf Open)
            previewCallBack.Invoke(jcid, signIdStr)
        Else
            PreviewObj.JcId = jcid
            PreviewObj.SignIdStr = signIdStr
            PreviewObj.ShowDialog()
        End If
    End Sub
End Class