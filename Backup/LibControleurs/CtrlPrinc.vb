Imports System.Windows.Forms

Public Class CtrlPrinc

    Dim base As donnees

    Public Sub New()

        base = New donnees

    End Sub

    Public Function GetCtrlFilms() As CtrlFilms

        Return New CtrlFilms(base)

    End Function

    Public Function GetCtrlJeux() As CtrlJeux

        Return New CtrlJeux(base)

    End Function

    Public Function GetCtrlPrets() As CtrlPrets

        Return New CtrlPrets(base)

    End Function


End Class
