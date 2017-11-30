Imports CefSharp

Public Class ContextMenuHandler
    Implements IContextMenuHandler

    Public Sub OnBeforeContextMenu(browserControl As IWebBrowser, browser As IBrowser, frame As IFrame, parameters As IContextMenuParams, model As IMenuModel) Implements IContextMenuHandler.OnBeforeContextMenu
        model.Clear()
        model.AddItem(CefMenuCommand.ViewSource, "Dev Tools")
    End Sub

    Public Sub OnContextMenuDismissed(browserControl As IWebBrowser, browser As IBrowser, frame As IFrame) Implements IContextMenuHandler.OnContextMenuDismissed
        'Throw New NotImplementedException()
    End Sub

    Public Function OnContextMenuCommand(browserControl As IWebBrowser, browser As IBrowser, frame As IFrame, parameters As IContextMenuParams, commandId As CefMenuCommand, eventFlags As CefEventFlags) As Boolean Implements IContextMenuHandler.OnContextMenuCommand
        If commandId = CefMenuCommand.ViewSource Then
            browserControl.ShowDevTools()
        End If
        Return True
    End Function

    Public Function RunContextMenu(browserControl As IWebBrowser, browser As IBrowser, frame As IFrame, parameters As IContextMenuParams, model As IMenuModel, callback As IRunContextMenuCallback) As Boolean Implements IContextMenuHandler.RunContextMenu
        'Throw New NotImplementedException()
        Return False
    End Function

End Class
