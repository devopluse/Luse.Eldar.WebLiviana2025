Public Class Parametros

    Private m_responsecaptcha As String
    Public Property responsecaptcha() As String
        Get
            Return m_responsecaptcha
        End Get
        Set(ByVal value As String)
            m_responsecaptcha = value
        End Set
    End Property
    Private mIDAuditoria As Long
    Public Property IDAuditoria() As Long
        Get
            Return mIDAuditoria
        End Get
        Set(ByVal value As Long)
            mIDAuditoria = value
        End Set
    End Property
    Private mIPCliente As String
    Public Property IPCliente() As String
        Get
            Return mIPCliente
        End Get
        Set(ByVal value As String)
            mIPCliente = value
        End Set
    End Property
    Private mMensaje As String
    Public Property Mensaje() As String
        Get
            Return mMensaje
        End Get
        Set(ByVal value As String)
            mMensaje = value
        End Set
    End Property

    Private mEstado As Boolean
    Public Property Estado() As Boolean
        Get
            Return mEstado
        End Get
        Set(ByVal value As Boolean)
            mEstado = value
        End Set
    End Property
    Private mAgente As String
    Public Property Agente() As String
        Get
            Return mAgente
        End Get
        Set(ByVal value As String)
            mAgente = value
        End Set
    End Property
    Private mCodPuestoRP As String
    Public Property CodPuestoRP() As String
        Get
            Return mCodPuestoRP
        End Get
        Set(ByVal value As String)
            mCodPuestoRP = value
        End Set
    End Property
    Private mMensajeCredito As String
    Public Property MensajeCredito() As String
        Get
            Return mMensajeCredito
        End Get
        Set(ByVal value As String)
            mMensajeCredito = value
        End Set
    End Property
    Private mHabilitadoEntregaDinero As Boolean
    Public Property HabilitadoEntregaDinero() As Boolean
        Get
            Return mHabilitadoEntregaDinero
        End Get
        Set(ByVal value As Boolean)
            mHabilitadoEntregaDinero = value
        End Set
    End Property
    Private mSucursal As String
    Public Property Sucursal() As String
        Get
            Return mSucursal
        End Get
        Set(ByVal value As String)
            mSucursal = value
        End Set
    End Property
    Private mAptoCredito As String
    Public Property AptoCredito() As String
        Get
            Return mAptoCredito
        End Get
        Set(ByVal value As String)
            mAptoCredito = value
        End Set
    End Property
    Private mImei As String
    Public Property Imei() As String
        Get
            Return mImei
        End Get
        Set(ByVal value As String)
            mImei = value
        End Set
    End Property
    Private mSaldo As Decimal
    Public Property Saldo() As Decimal
        Get
            Return mSaldo
        End Get
        Set(ByVal value As Decimal)
            mSaldo = value
        End Set
    End Property
    Private mIDVenta As Integer
    Public Property IDVenta() As Integer
        Get
            Return mIDVenta
        End Get
        Set(ByVal value As Integer)
            mIDVenta = value
        End Set
    End Property
    Private mIDAcceso As String
    Public Property IDAcceso() As String
        Get
            Return mIDAcceso
        End Get
        Set(ByVal value As String)
            mIDAcceso = value
        End Set
    End Property

    Private mIDProducto As Integer
    Public Property IDProducto() As Integer
        Get
            Return mIDProducto
        End Get
        Set(ByVal value As Integer)
            mIDProducto = value
        End Set
    End Property
    Private mPassActual As String
    Public Property PassActual() As String
        Get
            Return mPassActual
        End Get
        Set(ByVal value As String)
            mPassActual = value
        End Set
    End Property

    Private mCodPuesto As String
    Public Property CodPuesto() As String
        Get
            Return mCodPuesto
        End Get
        Set(ByVal value As String)
            mCodPuesto = value
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

    Private mDireccionAgencia As String
    Public Property DireccionAgencia() As String
        Get
            Return mDireccionAgencia
        End Get
        Set(ByVal value As String)
            mDireccionAgencia = value
        End Set
    End Property

    Private mNombreAgencia As String
    Public Property NombreAgencia() As String
        Get
            Return mNombreAgencia
        End Get
        Set(ByVal value As String)
            mNombreAgencia = value
        End Set
    End Property

    Private mNombreEmpresa As String
    Public Property NombreEmpresa() As String
        Get
            Return mNombreEmpresa
        End Get
        Set(ByVal value As String)
            mNombreEmpresa = value
        End Set
    End Property

    Private mCodEmpresa As String
    Public Property CodEmpresa() As String
        Get
            Return mCodEmpresa
        End Get
        Set(ByVal value As String)
            mCodEmpresa = value
        End Set
    End Property

    Private mNewPass As String
    Public Property NewPass() As String
        Get
            Return mNewPass
        End Get
        Set(ByVal value As String)
            mNewPass = value
        End Set
    End Property

    Private mRepNewPass As String
    Public Property RepNewPass() As String
        Get
            Return mRepNewPass
        End Get
        Set(ByVal value As String)
            mRepNewPass = value
        End Set
    End Property



    Private mIDAgencia As Long
    Public Property IDAgencia() As Long
        Get
            Return mIDAgencia
        End Get
        Set(ByVal value As Long)
            mIDAgencia = value
        End Set
    End Property

    Private mNroTarjeta As String
    Public Property NroTarjeta() As String
        Get
            Return mNroTarjeta
        End Get
        Set(ByVal value As String)
            mNroTarjeta = value
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

    Private mIDPrestamo As Long
    Public Property IDPrestamo() As Long
        Get
            Return mIDPrestamo
        End Get
        Set(ByVal value As Long)
            mIDPrestamo = value
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

    Private mFecha As String
    Public Property Fecha() As String
        Get
            Return mFecha
        End Get
        Set(ByVal value As String)
            mFecha = value
        End Set
    End Property
    Private mFechaHasta As String
    Public Property FechaHasta() As String
        Get
            Return mFechaHasta
        End Get
        Set(ByVal value As String)
            mFechaHasta = value
        End Set
    End Property


    Private mDestino As String
    Public Property Destino() As String
        Get
            Return mDestino
        End Get
        Set(ByVal value As String)
            mDestino = value
        End Set
    End Property

    Private mSaldoVirtual As String
    Public Property SaldoVirtual() As String
        Get
            Return mSaldoVirtual
        End Get
        Set(ByVal value As String)
            mSaldoVirtual = value
        End Set
    End Property

    Private mSaldoSube As String
    Public Property SaldoSube() As String
        Get
            Return mSaldoSube
        End Get
        Set(ByVal value As String)
            mSaldoSube = value
        End Set
    End Property

    Private mIDPrestamoBase As Integer
    Public Property IDPrestamoBase() As Integer
        Get
            Return mIDPrestamoBase
        End Get
        Set(ByVal value As Integer)
            mIDPrestamoBase = value
        End Set
    End Property
    Private mIDProveedor As Integer
    Public Property IDProveedor() As Integer
        Get
            Return mIDProveedor
        End Get
        Set(ByVal value As Integer)
            mIDProveedor = value
        End Set
    End Property
    Private mDni As Long
    Public Property Dni() As Long
        Get
            Return mDni
        End Get
        Set(ByVal value As Long)
            mDni = value
        End Set
    End Property

    Private mNroReferencia As Long
    Public Property NroReferencia() As Long
        Get
            Return mNroReferencia
        End Get
        Set(ByVal value As Long)
            mNroReferencia = value
        End Set
    End Property
    Public Sub New()

    End Sub

    Private mPrefijo As String
    Public Property Prefijo() As String
        Get
            Return mPrefijo
        End Get
        Set(ByVal value As String)
            mPrefijo = value
        End Set
    End Property
End Class

Public Class Respuesta

    Public Estado As Boolean
    Public Mensaje As String

End Class

Public Class RespuestaRedBus

    Public Estado As String
    Public id As String
    Public proveedor As String
    Public fechaImpacta As String
    Public fechaRecarga As String
    Public estadoRecarga As String
    Public Mensaje As String
    Public importe As String
End Class

Public Class Proveedores

    Public IDProveedor As Long
    Public NombreProveedor As String

End Class

Public Class MontosDisponibles

    Public IDMonto As Long
    Public Descripcion As String

End Class

Public Class ProductoPin

    Public IDProducto As Long
    Public NombreProducto As String

End Class

Public Class RespuestaRecarga

    Public Estado As String
    Public Mensaje As String
    Public IDTransaccion As String
    Public NroTarjeta As String
    Public Monto As String
    Public CantVtas As String
    Public TotalVtas As String
    Public Destino As String
    Public UrlSitio As String
    Public UrlSitioTicket As String
    Public CodigoTicket As String
    Public TemplateTicket As String

End Class

Public Class resCaptcha

    Private msuccess As Boolean
    Public Property success() As Boolean
        Get
            Return msuccess
        End Get
        Set(ByVal value As Boolean)
            msuccess = value
        End Set
    End Property
    Private mchallenge_ts As DateTime
    Public Property challenge_ts() As DateTime
        Get
            Return mchallenge_ts
        End Get
        Set(ByVal value As DateTime)
            mchallenge_ts = value
        End Set
    End Property
    Private mhostname As String
    Public Property hostname() As String
        Get
            Return mhostname
        End Get
        Set(ByVal value As String)
            mhostname = value
        End Set
    End Property
    Private maction As String
    Public Property action() As String
        Get
            Return maction
        End Get
        Set(ByVal value As String)
            maction = value
        End Set
    End Property

End Class


Public Class Data
    Public Property rdo As Boolean
    Public Property idAcceso As Integer
    Public Property idAgencia As Integer
    Public Property idProducto As Integer
    Public Property observaciones As String
    Public Property endPointExterno As String
    Public Property idVenta As Integer
    Public Property saleData As String
    Public Property message As String
    Public Property idTransaccion As String
    Public Property conector As Integer
    Public Property PinNumeroSerie As String
    Public Property PinSeguridad As String
    Public Property PinCAT As String
End Class
Public Class evento

    Private m_Token As String
    Public Property Token() As String
        Get
            Return m_Token
        End Get
        Set(ByVal value As String)
            m_Token = value
        End Set
    End Property
    Private m_SiteKey As String
    Public Property SiteKey() As String
        Get
            Return m_SiteKey
        End Get
        Set(ByVal value As String)
            m_SiteKey = value
        End Set
    End Property
    Private m_ExpectedAction As String
    Public Property ExpectedAction() As String
        Get
            Return m_ExpectedAction
        End Get
        Set(ByVal value As String)
            m_ExpectedAction = value
        End Set
    End Property
End Class
Public Class resEldarSales2
    Public Property data As Data
    Public Property isSuccess As Boolean
    Public Property message As String
    Public Property errors As Object
End Class

Public Class EldarSales2
    Public Property userCode As String
    Public Property passWord As String
    Public Property tipoAcceso As Integer
    Public Property destino As String
    Public Property monto As Integer
    Public Property idProveedor As Integer
    Public Property idProducto As Integer
    Public Property referenciaOperador As String
    Public Property terminal As String
    Public Property PinNumeroSerie As String
    Public Property PinSeguridad As String
    Public Property PinCAT As String
End Class
Public Class ItemTicket
    Public Property barra As String
    Public Property ticket As String()()
    Public Property codResulItem As Integer
    Public Property descResulItem As String
    Public Property idItem As String
End Class

Public Class ResponseSale

    Private _pIdTransacccion As String
    Public Property pIdTransacccion() As String
        Get
            Return _pIdTransacccion
        End Get
        Set(ByVal value As String)
            _pIdTransacccion = value
        End Set
    End Property
    Private _mensaje As String
    Public Property mensaje() As String
        Get
            Return _mensaje
        End Get
        Set(ByVal value As String)
            _mensaje = value
        End Set
    End Property

    Private _estado As String
    Public Property estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)
            _estado = value
        End Set
    End Property
    Private _trama As String
    Public Property trama() As String
        Get
            Return _trama
        End Get
        Set(ByVal value As String)
            _trama = value
        End Set
    End Property
    Private _codError As String
    Public Property codError() As String
        Get
            Return _codError
        End Get
        Set(ByVal value As String)
            _codError = value
        End Set
    End Property



End Class
