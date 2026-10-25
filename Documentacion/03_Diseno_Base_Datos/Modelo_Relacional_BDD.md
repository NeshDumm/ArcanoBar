# Modelo Relacional de Base de Datos - ArcanosBar

**Proyecto:** ArcanosBar - Sistema de Gestión de Bar Karaoke  
**Motor de Base de Datos:** Microsoft SQL Server  
**ORM:** Entity Framework Core  
**Asignatura:** Diseño de Aplicaciones y Servicios para Internet (ITID803)  

---

## 1. Diagrama Entidad - Relación (Mermaid)

```mermaid
erDiagram
  ROL ||--o{ USUARIO : tiene
  USUARIO ||--o{ PEDIDO : toma_mesero

  ESPACIO ||--o{ RESERVA : recibe
  ESPACIO ||--o{ SESION_ESPACIO : aloja
  RESERVA |o--o| SESION_ESPACIO : origina

  CATEGORIA ||--o{ PRODUCTO : clasifica
  PRODUCTO ||--o{ PRODUCTO_DETALLE : contiene

  SESION_ESPACIO ||--o{ PEDIDO : genera
  PEDIDO ||--o{ PEDIDO_DETALLE : incluye
  PRODUCTO ||--o{ PEDIDO_DETALLE : se_pide_en

  SESION_ESPACIO ||--|| CUENTA : liquida
  CUENTA ||--o{ PAGO : registra

  ROL {
    int RolId PK
    string Nombre UK
  }

  USUARIO {
    int UsuarioId PK
    int RolId FK
    string NombreCompleto
    string Email UK
    string PasswordHash
    bool Activo
    datetime FechaCreacion
  }

  ESPACIO {
    int EspacioId PK
    string Nombre UK
    string TipoEspacio "Mesa | SalaKaraoke"
    string Subtipo "Grande | Mediana | Estandar"
    int CapacidadPersonas
    decimal TarifaPorHora
    string Estado "Disponible | Ocupado | Mantenimiento"
  }

  RESERVA {
    int ReservaId PK
    int EspacioId FK
    string ClienteCedula
    string ClienteNombre
    string ClienteTelefono
    datetime FechaHoraInicio
    datetime FechaHoraFin
    decimal MontoAnticipo "25% calculado"
    string Estado "Pendiente | Confirmada | Cancelada | Finalizada"
    string CodigoReserva UK
    datetime FechaRegistro
  }

  CATEGORIA {
    int CategoriaId PK
    string Nombre UK
    string Descripcion
    bool Activa
  }

  PRODUCTO {
    int ProductoId PK
    int CategoriaId FK
    string Nombre
    string Descripcion
    decimal Precio
    bool EsCombo
    bool Disponible
    string ImagenUrl
  }

  PRODUCTO_DETALLE {
    int ProductoDetalleId PK
    int ProductoId FK
    string NombreComponente "Articulo o ingrediente detallado"
    string Descripcion "Detalles, acompañamientos o especificaciones"
    int Cantidad
    bool EsOpcional
  }

  SESION_ESPACIO {
    int SesionEspacioId PK
    int EspacioId FK
    int ReservaId FK "nullable"
    datetime FechaApertura
    datetime FechaCierre "nullable"
    string TokenQR UK "Token para vinculacion web por QR"
    string Estado "Activa | Cerrada"
  }

  PEDIDO {
    int PedidoId PK
    int SesionEspacioId FK
    int UsuarioId FK "nullable (asignado si lo tomo el mesero)"
    datetime FechaHora
    string Estado "Pendiente | EnPreparacion | Listo | Entregado | Cancelado"
    string ObservacionGeneral "nullable"
  }

  PEDIDO_DETALLE {
    int PedidoDetalleId PK
    int PedidoId FK
    int ProductoId FK
    int Cantidad
    decimal PrecioUnitario
    decimal Subtotal
    string NotasItem "nullable (ej. sin cebolla)"
  }

  CUENTA {
    int CuentaId PK
    int SesionEspacioId FK,UK
    decimal SubtotalConsumo
    decimal HorasKaraoke
    decimal CostoKaraoke "Regla: 0 si SubtotalConsumo >= 50"
    decimal AnticipoAcreditado "25% abonado en reserva previa"
    decimal TotalAPagar "(SubtotalConsumo + CostoKaraoke) - Anticipo"
    string Estado "Abierta | Pagada"
    datetime FechaLiquidacion "nullable"
  }

  PAGO {
    int PagoId PK
    int CuentaId FK
    string MetodoPago "Efectivo | DeUna | Tarjeta"
    decimal MontoPagado
    string ReferenciaComprobante "nullable"
    datetime FechaPago
  }
```

---

## 2. Diccionario de Datos y Módulos

### 2.1 Módulo de Seguridad y Usuarios
* **`ROL`**: Almacena los perfiles de acceso autorizados (*Administrador, Cajero, Mesero, Cocinero*).
* **`USUARIO`**: Credenciales y datos del personal del bar con contraseñas encriptadas mediante hash y validación de estado activo.

### 2.2 Módulo de Espacios y Reservas
* **`ESPACIO`**: Modela las 6 salas de karaoke (2 grandes, 4 medianas) y las 10 mesas de comedor para 4 comensales. Incluye su tarifa horaria y estado físico.
* **`RESERVA`**: Contiene la solicitud de agendamiento del cliente (Cédula, Nombre, Teléfono), el rango de horas, el cálculo del **anticipo del 25%** y su código único de seguimiento.

### 2.3 Módulo de Menú y Catálogo
* **`CATEGORIA`**: Agrupación del catálogo (*Bebidas con alcohol, Bebidas sin alcohol, Comidas, Combos*).
* **`PRODUCTO`**: Artículos y combos comercializados con su precio base, indicador booleano `EsCombo` y disponibilidad en barra/cocina.
* **`PRODUCTO_DETALLE`**: Desglosa los componentes o ingredientes tanto de combos como de platos de comida (ej. qué incluye una hamburguesa o los productos que conforman un combo).

### 2.4 Módulo Operativo de Pedidos
* **`SESION_ESPACIO`**: Representa la estancia activa de un grupo en una mesa o sala. Genera un `TokenQR` para que los comensales accedan al menú sin registro de credenciales.
* **`PEDIDO`**: Cabecera de la comanda/orden enviada por la app web o tomada por el mesero. Maneja los estados: *Pendiente, En Preparación, Listo para Servir, Entregado, Cancelado*.
* **`PEDIDO_DETALLE`**: Desglose de productos, cantidades pedidas, precios históricos y notas específicas del comensal.

### 2.5 Módulo de Cuentas y Cobro
* **`CUENTA`**: Liquidación consolidada de la sesión. Implementa la regla de negocio de exoneración de horas de karaoke si el consumo de alimentos y bebidas alcanza o supera los **$50.00**, y resta el **25% de anticipo** abonado previamente.
* **`PAGO`**: Registro de las transacciones de liquidación soportando Efectivo, Transferencias digitales (DeUna, Banco) y Tarjetas de crédito/débito.
