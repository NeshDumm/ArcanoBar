# Entrevista de Levantamiento de Requerimientos - ArcanosBar

**Proyecto:** ArcanosBar - Sistema de Gestión de Bar Karaoke  
**Asignatura:** Diseño de Aplicaciones y Servicios para Internet (ITID803)  
**Fecha:** 24 de Octubre de 2026  
**Participantes:**
- **Entrevistado (Rol Cliente / Negocio):** Dueño de ArcanosBar
- **Entrevistador (Equipo Scrum):** Óscar Ortega (Scrum Master), Anaela Pozo (Dev), Estefanía Belén Tenorio (Dev)
- **Product Owner Académico:** Ing. Jose Naranjo

---

## 1. Resumen Ejecutivo del Negocio

**ArcanosBar** es un establecimiento híbrido de entretenimiento y gastronomía (Bar-Karaoke) que ofrece dos modalidades principales de servicio:
1. **Consumo en Sala de Karaoke:** Espacio privado para cantar y consumir alimentos y bebidas.
2. **Consumo en Mesas de Comedor:** Espacio tradicional de bar/restaurante para comer y beber.

Ambas modalidades operan bajo un modelo de **reserva previa**, garantizando aforo y una experiencia ordenada para los clientes.

---

## 2. Registro Detallado de la Entrevista

### Bloque 1: Espacios y Capacidad Física

| Pregunta Guía | Respuesta del Negocio | Comprensión del Requerimiento |
| :--- | :--- | :--- |
| **¿Cuántas salas y mesas componen el bar?** | Se cuenta con 6 salas de karaoke (2 grandes y 4 medianas) y 10 mesas de comedor para 4 personas cada una. | El sistema debe diferenciar entre mesas de comedor y salas de karaoke, considerando sus capacidades y permitiendo identificarlas con nombres claros para facilitar su gestión. |
| **¿Cómo se gestiona el tiempo de las salas de karaoke?** | Se reservan por bloques de horas o la noche completa. Habrá promociones ocasionales. | El sistema debe controlar el horario de inicio y fin de cada reserva para evitar cruces o sobreventa en una misma sala o mesa. |
| **¿Cómo se asegura la reserva?** | Se exige un adelanto/anticipo del 25% del valor base para confirmar la reserva. Se registran obligatoriamente: Cédula, Nombre completo y Teléfono. | El 25% actúa como un abono previo que se acreditará a la cuenta final. Se requieren datos de contacto básicos del cliente para registrar la reserva. |
| **¿Quién registra la reserva?** | Principalmente el cliente desde la aplicación web. También el cajero o administrador si el cliente reserva por llamada telefónica o presencial. | La funcionalidad de reserva debe estar disponible tanto para clientes en la web como para el personal en el bar. |

---

### Bloque 2: Menú, Combos y Flujo de Pedidos

| Pregunta Guía | Respuesta del Negocio | Comprensión del Requerimiento |
| :--- | :--- | :--- |
| **¿Qué productos ofrece el menú?** | Bebidas alcohólicas, cócteles, bebidas sin alcohol (aguas, jugos), hamburguesas, alitas y comida para picar (nachos, papas fritas, carnitas). | Se requiere un catálogo organizado por categorías (bebidas, comidas y combos) con información visible de precios y disponibilidad. |
| **¿Cómo funcionan los combos?** | Son paquetes cerrados de productos con precio promocional (más económico que la suma individual). El cliente también puede pedir productos sueltos. | El menú debe destacar paquetes de combos cerrados a precio especial, permitiendo además la venta individual de cualquier artículo. |
| **¿Cómo realiza el pedido el cliente en la mesa/sala?** | El cliente accede desde la app web escaneando un código QR ubicado físicamente en la mesa o sala. | El cliente puede consultar el menú y enviar pedidos directamente desde su dispositivo al escanear el QR de su mesa/sala. |
| **¿Cómo es el flujo de estados del pedido?** | El cliente puede consultar el estado de su orden y continuar agregando más pedidos durante su estancia. | Los pedidos deben pasar por estados visibles (Pendiente, En Preparación, Listo, Entregado) para que el cliente y el personal puedan dar seguimiento. |

---

### Bloque 3: Cuentas, Reglas de Consumo y Pagos

| Pregunta Guía | Respuesta del Negocio | Comprensión del Requerimiento / Regla de Negocio |
| :--- | :--- | :--- |
| **¿Cómo se calcula el cobro de la sala de karaoke?** | Se cobra un valor por hora de uso, **a menos que** el consumo en comida y bebida alcance o supere los **$50.00**. Si llega a $50.00, la estadía en la sala es gratis ($0.00). | **Regla de Negocio:** Si el consumo acumulado en alimentos y bebidas es de $50 o más, el costo por hora de la sala de karaoke se exonera ($0). Si no alcanza los $50, se cobra la tarifa por hora correspondiente. |
| **¿Cómo se calcula el cobro en mesas?** | En las mesas de comedor únicamente se factura lo efectivamente consumido en alimentos y bebidas. | En mesas tradicionales no aplica tarifa por tiempo de estancia. |
| **¿Cómo se aplica el anticipo?** | El 25% abonado en la reserva se resta del total acumulado a pagar. | El valor pagado como anticipo se descuenta del total final que el cliente cancela al retirarse. |
| **¿Qué métodos de pago se aceptan?** | Efectivo, transferencias digitales (ej. DeUna, Banco Pichincha) y tarjetas de crédito o débito. | Se debe poder registrar el medio con el que se liquida la cuenta y generar el comprobante correspondiente para la mesa o sala. |

---

### Bloque 4: Roles y Actores del Sistema

| Rol | Responsabilidades en ArcanosBar |
| :--- | :--- |
| **Cliente** | Consulta catálogo/combos, reserva mesas o salas, escanea QR en sala/mesa para pedir y consulta el estado de su orden. |
| **Administrador** | Gestiona el menú, precios, combos, salas/mesas y visualiza reportes generales de ventas y ocupación. |
| **Cajero** | Registra reservas presenciales o telefónicas, valida llegada de clientes, cobra la cuenta final y emite comprobantes. |
| **Mesero** | Atiende mesas/salas físicamente, puede registrar pedidos a solicitud del cliente y entrega los pedidos listos. |
| **Cocinero / Barman** | Visualiza pedidos en cola, actualiza el estado a `En Preparación` y `Listo`. |

---

## 3. Trazabilidad con la Guía de la Asignatura (DASI Práctica 01)

1. **Sprint 1 - Entregable Técnico:**
   - Proyecto backend ASP.NET Core Web API con endpoint `/api/combos`.
   - Proyecto frontend Blazor WebAssembly consumiendo `/api/combos`.
   - Documentación en `README.md`.
2. **Entregable Metodológico:**
   - Product Backlog organizado con Historias de Usuario y Criterios de Aceptación.
   - Diagrama de Casos de Uso (UML).
   - Diagrama de Arquitectura inicial.
   - Tablero de Jira estructurado.
