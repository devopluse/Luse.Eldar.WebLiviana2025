Imports Newtonsoft.Json

Public Class Rapipago

End Class
Public Class FormasPago
    Public Property PES As String
End Class

Public Class datosFormulario
End Class

Public Class ItemEnviar
    Public Property barra As String
    Public Property idMod As String
    Public Property codEmp As String
    Public Property Empresa As String
    Public Property fechaHoraLectura As String
    Public Property importeItem As String
    Public Property idItem As String
    Public Property formasPago As FormasPago
    Public Property datosFormulario As datosFormulario
End Class

Public Class CabeceraEnviar
    Public Property items As ItemEnviar()
    Public Property codPuesto As String
    Public Property idMobile As String
    Public Property importeTotal As String
    Public Property idTrxAnterior As String
End Class
Public Class GrillaResponse
    Private mBarra As String
    Public Property Barra() As String
        Get
            Return mBarra
        End Get
        Set(ByVal value As String)
            mBarra = value
        End Set
    End Property
    Private mImporte As String
    Public Property Importe() As String
        Get
            Return mImporte
        End Get
        Set(ByVal value As String)
            mImporte = value
        End Set
    End Property
    Private mNombre As String
    Public Property Nombre() As String
        Get
            Return mNombre
        End Get
        Set(ByVal value As String)
            mNombre = value
        End Set
    End Property
    Private mDni As String
    Public Property Dni() As String
        Get
            Return mDni
        End Get
        Set(ByVal value As String)
            mDni = value
        End Set
    End Property
    Private mcodResul As String
    Public Property codResul() As String
        Get
            Return mcodResul
        End Get
        Set(ByVal value As String)
            mcodResul = value
        End Set
    End Property
    Private mdescResul As String
    Public Property descResul() As String
        Get
            Return mdescResul
        End Get
        Set(ByVal value As String)
            mdescResul = value
        End Set
    End Property
End Class

Public Class Pago
    Public Property codPuesto As Integer
    Public Property items() As New List(Of Item)
    Public Property codResul As Integer
    Public Property descResul As String
    Public Property idTrx As String
End Class


Public Class Item
    Public Property barra As String
    Public Property tic() As New List(Of String)
    Public Property codResulItem As Integer
    Public Property descResulItem As String
    Public Property idItem As String
    Public Property Empresa As String
    Public Property Importe As String
End Class

Public Class Grilla
    Public Property codPuesto As Integer
    Public Property codResul As Integer
    Public Property descResul As String
    Public Property titulo As String
    Public Property camposGrilla As List(Of Camposgrilla)
    Public Property valoresGri() As New List(Of Valoresgrilla)
    Public Property codEmp As String
End Class

Public Class UltimaTransaccion
    Public Property codPuesto As Integer
    Public Property idUltimaTrxPendiente As Object
    Public Property idUltimaTrxConfirmada As String
    Public Property existeTrxEnProceso As Boolean
    Public Property codResul As Integer
    Public Property descResul As String
End Class

Public Class Camposgrilla
    Public Property codCampo As String
    Public Property descCampo As String
End Class

Public Class Valoresgrilla
    Public Property codCampo As String
    Public Property valor As String


End Class

Public Class RequestSaleRapi
    Public Property codPuesto As String
    Public Property idCliente As String
    Public Property codEmp As String
    Public Property idMod As String
    Public Property fechaHoraLectura As String
    Public Property formasPago As FormasPago
    Public Property importe As String
    Public Property idRecarga As String
    Public Property idTrxAnterior As Object
End Class


Public Class Empresas
    Private mtopes As List(Of topes)
    Public Property topes() As List(Of topes)
        Get
            Return mtopes
        End Get
        Set(ByVal value As List(Of topes))
            mtopes = value
        End Set
    End Property

    Private mcodEmp As String
    Public Property codEmp() As String
        Get
            Return mcodEmp
        End Get
        Set(ByVal value As String)
            mcodEmp = value
        End Set
    End Property

    Private mdescEmp As String
    Public Property descEmp() As String
        Get
            Return mdescEmp
        End Get
        Set(ByVal value As String)
            mdescEmp = value
        End Set
    End Property

    Private mmodalidades As List(Of Modalidades)
    Public Property modalidades() As List(Of Modalidades)
        Get
            Return mmodalidades
        End Get
        Set(ByVal value As List(Of Modalidades))
            mmodalidades = value
        End Set
    End Property
End Class

Public Class Modalidades
    Private manula As String
    Public Property anula() As String
        Get
            Return manula
        End Get
        Set(ByVal value As String)
            manula = value
        End Set
    End Property

    Private mdescMod As String
    Public Property descMod() As String
        Get
            Return mdescMod
        End Get
        Set(ByVal value As String)
            mdescMod = value
        End Set
    End Property

    Private mesCobroOnline As String
    Public Property esCobroOnline() As String
        Get
            Return mesCobroOnline
        End Get
        Set(ByVal value As String)
            mesCobroOnline = value
        End Set
    End Property

    Private mesPago As String
    Public Property esPago() As String
        Get
            Return mesPago
        End Get
        Set(ByVal value As String)
            mesPago = value
        End Set
    End Property

    Private mesRecarga As String
    Public Property esRecarga() As String
        Get
            Return mesRecarga
        End Get
        Set(ByVal value As String)
            mesRecarga = value
        End Set
    End Property

    Private midMod As String
    Public Property idMod() As String
        Get
            Return midMod
        End Get
        Set(ByVal value As String)
            midMod = value
        End Set
    End Property

    Private mtipoCobranza As String
    Public Property tipoCobranza() As String
        Get
            Return mtipoCobranza
        End Get
        Set(ByVal value As String)
            mtipoCobranza = value
        End Set
    End Property

End Class
Public Class CabeceraEmpresas
    Private mcodPuesto As String
    Public Property codPuesto() As String
        Get
            Return mcodPuesto
        End Get
        Set(ByVal value As String)
            mcodPuesto = value
        End Set
    End Property

    Private mcodResul As Integer
    Public Property codResul() As Integer
        Get
            Return mcodResul
        End Get
        Set(ByVal value As Integer)
            mcodResul = value
        End Set
    End Property

    Private mdescResul As String
    Public Property descResul() As String
        Get
            Return mdescResul
        End Get
        Set(ByVal value As String)
            mdescResul = value
        End Set
    End Property

    Private mempresas As List(Of Empresas)
    Public Property empresas() As List(Of Empresas)
        Get
            Return mempresas
        End Get
        Set(ByVal value As List(Of Empresas))
            mempresas = value
        End Set
    End Property

End Class


Public Class Formulario
    Public Property codPuesto As Integer
    Public Property titulo As String
    Public Property campos As List(Of Campos)
    Public Property codResul As Integer
    Public Property descResul As String
    Public Property comision As String
End Class

Public Class Campos
    Public Property etiqueta As String
    Public Property nombre As String
    Public Property tipo As String
    Public Property longitud As Integer
    Public Property listaValores() As Listavalores
    Public Property tipoComponenteVisual As String
    Public Property idFormaSeparacionCampos As String
End Class

Public Class Listavalores
    <JsonProperty("1")>
    Public Property _1 As String
    <JsonProperty("2")>
    Public Property _2 As String
    <JsonProperty("3")>
    Public Property _3 As String
End Class

Public Class facturas



    Public Property anula As String

    Public Property barra As String

    Public Property codEmp As String

    Public Property codResulItem As Integer


    Public Property codTI As String

    Public Property descEmp As String

    Public Property descMod As String

    Public Property descResulItem As String


    Public Property descTI As String

    Public Property idMod As String

    Public Property importe As String

    Public Property tipoCobranza As String

    Public Property topes As List(Of topes)

End Class

Public Class topes


    Public Property maximoNegativo As String

    Public Property maximoPositivo As String

    Public Property minimoNegativo As String

    Public Property minimoPositivo As String


End Class

Public Class ParametrosRapiPago

    Private midTrxAnterior As String

    Public Property idTrxAnterior() As String
        Get

            Return midTrxAnterior
        End Get
        Set(ByVal value As String)
            midTrxAnterior = value
        End Set
    End Property
    Private midMod As String
    Public Property idMod() As String
        Get
            Return midMod
        End Get
        Set(ByVal value As String)
            midMod = value
        End Set
    End Property

    Private mcodEmpresa As String
    Public Property codEmpresa() As String
        Get
            Return mcodEmpresa
        End Get
        Set(ByVal value As String)
            mcodEmpresa = value
        End Set
    End Property

    Private mcodPuesto As String
    Public Property codPuesto() As String
        Get
            Return mcodPuesto
        End Get
        Set(ByVal value As String)
            mcodPuesto = value
        End Set
    End Property

    Private mCodBarra As String
    Public Property CodBarra() As String
        Get
            Return mCodBarra
        End Get
        Set(ByVal value As String)
            mCodBarra = value
        End Set
    End Property

    Private mNroOrdenComercial As String
    Public Property NroOrdenComercial() As String
        Get
            Return mNroOrdenComercial
        End Get
        Set(ByVal value As String)
            mNroOrdenComercial = value
        End Set
    End Property

    Private mUser As String
    Public Property User() As String
        Get
            Return mUser
        End Get
        Set(ByVal value As String)
            mUser = value
        End Set
    End Property

    Private mPass As String
    Public Property Pass() As String
        Get
            Return mPass
        End Get
        Set(ByVal value As String)
            mPass = value
        End Set
    End Property


    Private mNroRecibo As Long
    Public Property NroRecibo() As Long
        Get
            Return mNroRecibo
        End Get
        Set(ByVal value As Long)
            mNroRecibo = value
        End Set
    End Property


    Private mMonto As Integer
    Public Property Monto() As Integer
        Get
            Return mMonto
        End Get
        Set(ByVal value As Integer)
            mMonto = value
        End Set
    End Property

    Private mMontoDecimal As Decimal
    Public Property MontoDecimal() As Decimal
        Get
            Return mMontoDecimal
        End Get
        Set(ByVal value As Decimal)
            mMontoDecimal = value
        End Set
    End Property

    Private mNroComercio As String
    Public Property NroComercio() As String
        Get
            Return mNroComercio
        End Get
        Set(ByVal value As String)
            mNroComercio = value
        End Set
    End Property

    Private mLotes As String
    Public Property Lotes() As String
        Get
            Return mLotes
        End Get
        Set(ByVal value As String)
            mLotes = value
        End Set
    End Property

    Private mFecha As String
    Public Property Fecha() As String
        Get
            Return mFecha
        End Get
        Set(ByVal value As String)
            mFecha = value
        End Set
    End Property

    Private mdatosFormulario As String
    Public Property datosFormulario() As String
        Get
            Return mdatosFormulario
        End Get
        Set(ByVal value As String)
            mdatosFormulario = value
        End Set
    End Property

    Private mModalidad As String
    Public Property Modalidad() As String
        Get
            Return mModalidad
        End Get
        Set(ByVal value As String)
            mModalidad = value
        End Set
    End Property
    Public Sub New()

    End Sub
End Class

Public Class RespuestaRapipago


    Public Property errorcode As String

    Public Property message As String

    Public Property dataObject As String

    Public Property statusCode() As String

    Public Property cantColisiones As Integer?

    Public Property codPuesto As String

    Public Property codResul As Integer

    Public Property descResul As String
    Public Property comision As String
    Public Property facturas As New List(Of facturas)

End Class

Public Class TicketRapipagoNew
    Public Property barra As String
    Public Property tic As String()
    Public Property codResulItem As Integer
    Public Property descResulItem As String
    Public Property idItem As String
    Public Property Empresa As Object
    Public Property Importe As Object
End Class


