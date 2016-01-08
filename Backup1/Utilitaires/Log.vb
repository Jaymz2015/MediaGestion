Imports log4net
Imports log4net.Config
Imports System.IO

Public Class Log

    Private Shared LeLog As ILog

    Public Enum Niveau
        DEBUT
        FIN
        ERREUR

    End Enum

    Public Shared Function MonitoringLogger() As ILog

        Dim configFile As String

        Try
            If LeLog Is Nothing Then

                If File.Exists("D:\Tracing\MediaGestion\MediaGestion.log") Then
                    File.Delete("D:\Tracing\MediaGestion\MediaGestion.log")
                End If

                'On récupère le chemin du fichier de config
                configFile = Directory.GetCurrentDirectory() + "\log4net.config"

                'on charge la configuration définie dans le fichier log4net.config
                XmlConfigurator.Configure(New FileInfo(configFile))

                LeLog = LogManager.GetLogger("MediaGestionLog")
            End If

            Return LeLog

        Catch ex As Exception
            Return Nothing
        Finally

        End Try
      

    End Function


    Public Shared Function ExceptionLogger() As ILog

        Return LogManager.GetLogger("ExceptionLogger")

    End Function


End Class
