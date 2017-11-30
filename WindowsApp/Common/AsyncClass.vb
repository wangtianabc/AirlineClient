Imports CefSharp
Imports System.Threading
''' <summary>
''' 在JS中调用方法时，首字母必须要小写
''' </summary>
Public Class AsyncClass

    Private random As New Random()
    ''' <summary>
    ''' 异步回调
    ''' </summary>
    ''' <param name="successCallback"></param>
    ''' <param name="errorCallback"></param>
    Public Sub doSomething(ByVal successCallback As IJavascriptCallback, ByVal errorCallback As IJavascriptCallback)
        If random.Next() Mod 2 = 0 Then
            Thread.Sleep(2000)
            successCallback.ExecuteAsync()
        Else
            Thread.Sleep(2000)
            errorCallback.ExecuteAsync("1", "2", "3")
        End If
    End Sub
    ''' <summary>
    ''' 参数传递
    ''' </summary>
    ''' <param name="SuccessCallback"></param>
    ''' <param name="ErrorCallback"></param>
    ''' <param name="val"></param>
    Public Sub testRtn(ByVal SuccessCallback As IJavascriptCallback, ByVal ErrorCallback As IJavascriptCallback, ByVal val As Integer)
        SuccessCallback.ExecuteAsync(val + 2)
    End Sub
    ''' <summary>
    ''' 无参调用
    ''' </summary>
    Public Sub msg(ByVal text As String)
        MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
