Module CommonMD

    ''' <summary>
    ''' 用net use命令连接到远程共享目录上，创建网络共享连接
    ''' </summary>
    ''' <param name="Server">目标ip</param>
    ''' <param name="ShareName">远程共享名</param>
    ''' <param name="Username">远程登录用户</param>
    ''' <param name="Password">远程登录密码</param>
    Public Sub CreateShareNetConnect(ByVal Server As String, ByVal ShareName As String, ByVal Username As String, ByVal Password As String)
        Try
            Dim process As New Process()
            process.StartInfo.FileName = "net.exe"
            process.StartInfo.Arguments = "use \\" & Server & "\" & ShareName & " """ & Password & """ /user:""" & Username & """ "
            process.StartInfo.CreateNoWindow = True
            process.StartInfo.UseShellExecute = False
            process.Start()
            process.WaitForExit()
            process.Close()
            process.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    ''' <summary>
    ''' 用net use delete命令移除网络共享连接
    ''' </summary>
    ''' <param name="Server">目标ip</param>
    ''' <param name="ShareName">远程共享名</param>
    ''' <param name="Username">远程登录用户</param>
    ''' <param name="Password">远程登录密码</param>
    Public Sub RemoveShareNetConnect(ByVal Server As String, ByVal ShareName As String, ByVal Username As String, ByVal Password As String)
        'System.Diagnostics.Process.Start("net.exe", @"use \\" + Server + @"\" + ShareName + " \"" + Password + "\" /user:\"" + Username + "\" ");
        Dim process As New Process()
        process.StartInfo.FileName = "net.exe"
        process.StartInfo.Arguments = "use \\" & Server & "\" & ShareName & " /delete"
        process.StartInfo.CreateNoWindow = True
        process.StartInfo.UseShellExecute = False
        process.Start()
        process.WaitForExit()
        process.Close()
        process.Dispose()
    End Sub

    ''' <summary>
    ''' 连接文件服务器
    ''' </summary>
    ''' <returns></returns>
    Public Function ConnectFileServer() As String()
        Dim server As String = XmlLoad(Application.StartupPath & "\../../../Conf/config.xml", "conf/server")
        Dim userName As String = XmlLoad(Application.StartupPath & "\../../../Conf/config.xml", "conf/username")
        Dim password As String = XmlLoad(Application.StartupPath & "\../../../Conf/config.xml", "conf/password")
        Dim shareFolder As String = XmlLoad(Application.StartupPath & "\../../../Conf/config.xml", "conf/shareFbDocName")
        RemoveShareNetConnect(server, shareFolder, userName, password)
        CreateShareNetConnect(server, shareFolder, userName, password)
        Return New String() {server, shareFolder, userName, password}
    End Function

End Module
