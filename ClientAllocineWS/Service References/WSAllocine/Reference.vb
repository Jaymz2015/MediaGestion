﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Ce code a été généré par un outil.
'     Version du runtime :2.0.50727.4214
'
'     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
'     le code est régénéré.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Runtime.Serialization

Namespace WSAllocine
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0"),  _
     System.Runtime.Serialization.DataContractAttribute(Name:="FicheAllocine", [Namespace]:="http://allocinews.org/"),  _
     System.SerializableAttribute()>  _
    Partial Public Class FicheAllocine
        Inherits Object
        Implements System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
        
        <System.NonSerializedAttribute()>  _
        Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private TitreField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private URLField As String
        
        <Global.System.ComponentModel.BrowsableAttribute(false)>  _
        Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set
                Me.extensionDataField = value
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false)>  _
        Public Property Titre() As String
            Get
                Return Me.TitreField
            End Get
            Set
                If (Object.ReferenceEquals(Me.TitreField, value) <> true) Then
                    Me.TitreField = value
                    Me.RaisePropertyChanged("Titre")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false)>  _
        Public Property URL() As String
            Get
                Return Me.URLField
            End Get
            Set
                If (Object.ReferenceEquals(Me.URLField, value) <> true) Then
                    Me.URLField = value
                    Me.RaisePropertyChanged("URL")
                End If
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute([Namespace]:="http://allocinews.org/", ConfigurationName:="WSAllocine.ServiceSoap")>  _
    Public Interface ServiceSoap
        
        'CODEGEN : La génération du contrat de message depuis le nom d’élément HelloWorldResult de l’espace de noms http://allocinews.org/ n’est pas marqué nillable
        <System.ServiceModel.OperationContractAttribute(Action:="http://allocinews.org/HelloWorld", ReplyAction:="*")>  _
        Function HelloWorld(ByVal request As WSAllocine.HelloWorldRequest) As WSAllocine.HelloWorldResponse
        
        'CODEGEN : La génération du contrat de message depuis le nom d’élément pCritere de l’espace de noms http://allocinews.org/ n’est pas marqué nillable
        <System.ServiceModel.OperationContractAttribute(Action:="http://allocinews.org/RechercheAllocine", ReplyAction:="*")>  _
        Function RechercheAllocine(ByVal request As WSAllocine.RechercheAllocineRequest) As WSAllocine.RechercheAllocineResponse
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class HelloWorldRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="HelloWorld", [Namespace]:="http://allocinews.org/", Order:=0)>  _
        Public Body As WSAllocine.HelloWorldRequestBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As WSAllocine.HelloWorldRequestBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"),  _
     System.Runtime.Serialization.DataContractAttribute()>  _
    Partial Public Class HelloWorldRequestBody
        
        Public Sub New()
            MyBase.New
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class HelloWorldResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="HelloWorldResponse", [Namespace]:="http://allocinews.org/", Order:=0)>  _
        Public Body As WSAllocine.HelloWorldResponseBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As WSAllocine.HelloWorldResponseBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://allocinews.org/")>  _
    Partial Public Class HelloWorldResponseBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public HelloWorldResult As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal HelloWorldResult As String)
            MyBase.New
            Me.HelloWorldResult = HelloWorldResult
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class RechercheAllocineRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="RechercheAllocine", [Namespace]:="http://allocinews.org/", Order:=0)>  _
        Public Body As WSAllocine.RechercheAllocineRequestBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As WSAllocine.RechercheAllocineRequestBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://allocinews.org/")>  _
    Partial Public Class RechercheAllocineRequestBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public pCritere As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal pCritere As String)
            MyBase.New
            Me.pCritere = pCritere
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class RechercheAllocineResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="RechercheAllocineResponse", [Namespace]:="http://allocinews.org/", Order:=0)>  _
        Public Body As WSAllocine.RechercheAllocineResponseBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As WSAllocine.RechercheAllocineResponseBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://allocinews.org/")>  _
    Partial Public Class RechercheAllocineResponseBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public RechercheAllocineResult() As WSAllocine.FicheAllocine
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal RechercheAllocineResult() As WSAllocine.FicheAllocine)
            MyBase.New
            Me.RechercheAllocineResult = RechercheAllocineResult
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")>  _
    Public Interface ServiceSoapChannel
        Inherits WSAllocine.ServiceSoap, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")>  _
    Partial Public Class ServiceSoapClient
        Inherits System.ServiceModel.ClientBase(Of WSAllocine.ServiceSoap)
        Implements WSAllocine.ServiceSoap
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function WSAllocine_ServiceSoap_HelloWorld(ByVal request As WSAllocine.HelloWorldRequest) As WSAllocine.HelloWorldResponse Implements WSAllocine.ServiceSoap.HelloWorld
            Return MyBase.Channel.HelloWorld(request)
        End Function
        
        Public Function HelloWorld() As String
            Dim inValue As WSAllocine.HelloWorldRequest = New WSAllocine.HelloWorldRequest
            inValue.Body = New WSAllocine.HelloWorldRequestBody
            Dim retVal As WSAllocine.HelloWorldResponse = CType(Me,WSAllocine.ServiceSoap).HelloWorld(inValue)
            Return retVal.Body.HelloWorldResult
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function WSAllocine_ServiceSoap_RechercheAllocine(ByVal request As WSAllocine.RechercheAllocineRequest) As WSAllocine.RechercheAllocineResponse Implements WSAllocine.ServiceSoap.RechercheAllocine
            Return MyBase.Channel.RechercheAllocine(request)
        End Function
        
        Public Function RechercheAllocine(ByVal pCritere As String) As WSAllocine.FicheAllocine()
            Dim inValue As WSAllocine.RechercheAllocineRequest = New WSAllocine.RechercheAllocineRequest
            inValue.Body = New WSAllocine.RechercheAllocineRequestBody
            inValue.Body.pCritere = pCritere
            Dim retVal As WSAllocine.RechercheAllocineResponse = CType(Me,WSAllocine.ServiceSoap).RechercheAllocine(inValue)
            Return retVal.Body.RechercheAllocineResult
        End Function
    End Class
End Namespace