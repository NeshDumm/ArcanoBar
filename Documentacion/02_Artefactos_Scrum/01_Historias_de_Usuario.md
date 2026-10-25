# Historias de Usuario - ArcanosBar

**Proyecto:** ArcanosBar - Sistema de Gestión de Bar Karaoke  
**Asignatura:** Diseño de Aplicaciones y Servicios para Internet (ITID803)  
**Marco de Trabajo:** Scrum  
**Product Owner:** Ing. Jose Naranjo  
**Scrum Master:** Óscar Ortega  
**Development Team:** Anaela Pozo, Estefanía Belén Tenorio  
**Tablero Jira:** [Tablero Scrum ArcanosBar](https://anaelapozo192.atlassian.net/jira/software/projects/SCRUM/boards/1)

---

## Índice de Épicas

- [EP-01: Gestión de Catálogo y Combos](#ep-01-gestión-de-catálogo-y-combos)
- [EP-02: Gestión de Espacios y Reservas](#ep-02-gestión-de-espacios-y-reservas)
- [EP-03: Flujo de Pedidos en Mesa/Sala](#ep-03-flujo-de-pedidos-en-mesasala)
- [EP-04: Cuentas, Cobros y Cierre](#ep-04-cuentas-cobros-y-cierre)
- [EP-05: Seguridad y Roles de Usuario](#ep-05-seguridad-y-roles-de-usuario)

---

## EP-01: Gestión de Catálogo y Combos

### **US-01: Visualización del catálogo de combos y productos**
* **Código:** US-01
* **Rol:** Cliente / Visitante
* **Descripción:**
  > **Como** cliente o comensal del bar,  
  > **quiero** consultar la lista de bebidas, comidas y combos con sus respectivos precios, y al seleccionar uno ver su detalle,  
  > **para** conocer la oferta gastronómica y decidir qué consumir antes o durante mi estadía.
* **Criterios de Aceptación:**
  1. El sistema debe presentar una sección destacada con los **combos disponibles** (ej. *Combo Alitas + Cervezas*).
  2. Los productos y combos deben organizarse por categorías claras (*Bebidas con/sin alcohol*, *Comidas*, *Combos*).
  3. Cada elemento debe mostrar su nombre, precio promocional o unitario e indicador de disponibilidad (*"Disponible"* o *"Agotado"*).
  4. **Al seleccionar/hacer clic en un combo o producto, debe desplegarse una vista de detalle** con la descripción completa, los componentes o ingredientes incluidos y el estado de disponibilidad (*nota: en el Sprint 1 se presenta la lista y el detalle interactivo se desarrollará en el siguiente incremento*).
  5. Esta historia conecta con el entregable del **Sprint 1** a través del endpoint `/api/combos` y la pantalla de inicio en Blazor.

---

### **US-02: Administración de productos y combos**
* **Código:** US-02
* **Rol:** Administrador
* **Descripción:**
  > **Como** administrador del bar,  
  > **quiero** crear, modificar y deshabilitar productos y combos en el catálogo digital,  
  > **para** mantener actualizados los precios, descripciones y la disponibilidad real de insumos.
* **Criterios de Aceptación:**
  1. Permite registrar nombre, descripción, precio, categoría y la lista de artículos que componen un combo.
  2. Permite marcar un producto como *"Agotado"* de manera inmediata para evitar que se solicite en mesas o salas.
  3. Permite actualizar precios y ofertas temporales.

---

## EP-02: Gestión de Espacios y Reservas

### **US-03: Consulta de disponibilidad de salas y mesas**
* **Código:** US-03
* **Rol:** Cliente / Cajero
* **Descripción:**
  > **Como** cliente o cajero/recepcionista,  
  > **quiero** seleccionar una fecha, hora y tipo de espacio (Mesa de comedor o Sala de Karaoke mediana/grande),  
  > **para** verificar si existe disponibilidad antes de iniciar una solicitud de reserva.
* **Criterios de Aceptación:**
  1. Muestra un calendario con los horarios de atención y la disponibilidad de los espacios.
  2. Filtra por tipo de espacio: Salas de karaoke (Mediana o Grande) y Mesas de comedor (capacidad 4 personas).
  3. Bloquea la selección de espacios que ya cuentan con reservas confirmadas en el rango horario elegido para evitar solapamientos.

---

### **US-04: Registro de reserva con anticipo del 25%**
* **Código:** US-04
* **Rol:** Cliente
* **Descripción:**
  > **Como** cliente interesado en visitar el bar,  
  > **quiero** registrar mis datos de contacto (Cédula, Nombre completo, Teléfono) y agendar una sala o mesa,  
  > **para** asegurar mi lugar y conocer el valor del anticipo que debo abonar.
* **Criterios de Aceptación:**
  1. Solicita obligatoriamente: Cédula, Nombre completo y Teléfono de contacto.
  2. Si la reserva es para una sala de karaoke, calcula automáticamente el **anticipo del 25%** sobre la tarifa base de las horas reservadas.
  3. El sistema registra la reserva en estado inicial **"Pendiente de Confirmación"**.
  4. El 25% queda tipificado como un **abono previo** que se acreditará a la cuenta final de consumo.
  5. Se emite un código identificador único de reserva para el cliente.

---

### **US-05: Administración y confirmación de reservas**
* **Código:** US-05
* **Rol:** Cajero / Administrador
* **Descripción:**
  > **Como** cajero del bar,  
  > **quiero** revisar la lista de reservas recibidas, validar el abono del anticipo y registrar reservas telefónicas o presenciales,  
  > **para** formalizar la agenda del bar y garantizar la atención a los clientes.
* **Criterios de Aceptación:**
  1. Permite cambiar el estado de la reserva de *"Pendiente"* a *"Confirmada"* tras validar el pago del 25%.
  2. Permite al personal crear directamente una reserva a nombre de un cliente que solicita por llamada telefónica o en persona.
  3. Permite cancelar una reserva liberando el espacio en caso de inasistencia o solicitud del cliente.

---

### **US-06: Configuración de espacios físicos**
* **Código:** US-06
* **Rol:** Administrador
* **Descripción:**
  > **Como** administrador,  
  > **quiero** dar de alta y configurar las salas de karaoke y las mesas del bar con sus nombres y tarifas,  
  > **para** mantener reflejada la capacidad física del establecimiento en la plataforma.
* **Criterios de Aceptación:**
  1. Permite parametrizar las 6 salas de karaoke (2 grandes y 4 medianas) y las 10 mesas de comedor.
  2. Permite asignar nombres identificativos (ej. *Sala Rock 1*, *Mesa 04*) y capacidad máxima de personas.
  3. Permite configurar la tarifa base por hora para cada sala de karaoke.
  4. Permite inhabilitar temporalmente un espacio por mantenimiento.

---

## EP-03: Flujo de Pedidos en Mesa/Sala

### **US-07: Vinculación a mesa o sala mediante código QR**
* **Código:** US-07
* **Rol:** Cliente
* **Descripción:**
  > **Como** cliente presente en el local,  
  > **quiero** escanear el código QR ubicado físicamente en mi mesa o sala de karaoke,  
  > **para** abrir el menú digital y vincular mi dispositivo a la sesión activa de mi espacio físico sin registros complejos.
* **Criterios de Aceptación:**
  1. El escaneo del código QR abre la app web e identifica automáticamente el número de mesa o nombre de la sala.
  2. **Persistencia de sesión:** La sesión iniciada se mantiene activa durante toda la estancia del grupo, asociando a esa misma cuenta todos los pedidos que se hagan posteriormente (US-08 y US-09).
  3. Si el espacio físico no tiene una sesión o reserva abierta, la app muestra un mensaje solicitando al cliente que pida su habilitación al mesero o cajero.

---

### **US-08: Registro y envío de pedidos desde la app web**
* **Código:** US-08
* **Rol:** Cliente
* **Descripción:**
  > **Como** cliente en la mesa o sala de karaoke con sesión vinculada,  
  > **quiero** seleccionar productos y combos, indicar cantidades u observaciones y enviar el pedido,  
  > **para** que el bar y la cocina preparen mi orden y se acumule a la cuenta de mi mesa o sala.
* **Criterios de Aceptación:**
  1. Permite agregar múltiples productos o combos al pedido actual.
  2. Permite incluir notas u observaciones por ítem (ej. *"hamburguesa sin cebolla"*, *"bebida bien fría"*).
  3. Al confirmar el envío, los ítems se registran asociados a la **sesión activa** del espacio físico bajo el estado **"Pendiente"**.
  4. Los comensales pueden enviar pedidos de forma continua durante toda su permanencia en el local sin cerrar la orden general.

---

### **US-09: Toma de pedidos presencial por el Mesero**
* **Código:** US-09
* **Rol:** Mesero
* **Descripción:**
  > **Como** mesero del bar,  
  > **quiero** registrar pedidos desde mi dispositivo móvil o terminal seleccionando la mesa o sala correspondiente,  
  > **para** atender a los clientes que prefieran realizar su orden de forma verbal.
* **Criterios de Aceptación:**
  1. El mesero puede seleccionar cualquier mesa o sala que tenga una sesión activa.
  2. Los productos y combos ingresados por el mesero se incorporan inmediatamente a la misma sesión y cuenta activa del espacio físico.
  3. Los ítems quedan registrados en estado **"Pendiente"** para la cocina o barra.

---

### **US-10: Gestión de pedidos en Cocina y Barra (Cocinero / Barman)**
* **Código:** US-10
* **Rol:** Cocinero / Barman
* **Descripción:**
  > **Como** cocinero o encargado de barra,  
  > **quiero** visualizar en pantalla los pedidos entrantes clasificados por mesa o sala y actualizar su avance,  
  > **para** coordinar la preparación de comidas y bebidas de manera secuencial y ordenada.
* **Criterios de Aceptación:**
  1. Pantalla operativa que lista los pedidos pendientes ordenados cronológicamente con su mesa/sala y observaciones.
  2. El cocinero/barman puede cambiar el estado de un pedido a **"En Preparación"** al iniciar el trabajo.
  3. El cocinero/barman cambia el estado a **"Listo para Servir"** cuando los platos o bebidas están terminados.
  4. El cocinero o mesero puede marcar un pedido en estado **"Cancelado"** (con justificación, ej. falta de insumo) antes de que empiece la preparación.

---

### **US-11: Seguimiento de estado y cancelación de pedidos**
* **Código:** US-11
* **Rol:** Cliente / Mesero
* **Descripción:**
  > **Como** cliente en la mesa/sala (o mesero a cargo),  
  > **quiero** consultar en tiempo real el estado de cada pedido enviado,  
  > **para** conocer los tiempos de atención y saber cuándo los productos están listos, entregados o si fueron cancelados.
* **Criterios de Aceptación:**
  1. La interfaz muestra el listado de pedidos enviados con sus estados:  
     - **Pendiente**  
     - **En Preparación**  
     - **Listo para Servir**  
     - **Entregado**  
     - **Cancelado**
  2. El cliente puede solicitar la **cancelación** de un ítem únicamente mientras su estado permanezca en *"Pendiente"*.
  3. El mesero marca el pedido como **"Entregado"** una vez llevado a la mesa o sala.
  4. Los pedidos con estado *"Cancelado"* no se suman al total acumulado de la cuenta.

---

## EP-04: Cuentas, Cobros y Cierre

### **US-12: Consulta de precuenta y regla de consumo de Karaoke**
* **Código:** US-12
* **Rol:** Cliente / Cajero
* **Descripción:**
  > **Como** cliente o cajero,  
  > **quiero** visualizar el desglose de consumos de la mesa o sala en tiempo real antes de pagar,  
  > **para** conocer el monto exacto acumulado y verificar los ítems consumidos.
* **Criterios de Aceptación:**
  1. En mesas de comedor, calcula únicamente el total de los productos entregados.
  2. En salas de karaoke, aplica la **regla de negocio:**
     - Si el consumo en alimentos y bebidas es **>= $50.00**, el costo por horas de karaoke se fija en **$0.00**.
     - Si el consumo es **< $50.00**, se suma al total el valor de las horas de sala utilizadas (`Horas * TarifaHora`).
  3. Descuenta automáticamente el valor del **anticipo del 25%** abonado en la reserva.
  4. Muestra claramente la fórmula: `Total a Pagar = (Consumo + Costo Karaoke) - Anticipo Abonado`.

---

### **US-13: Cobro y registro del método de pago**
* **Código:** US-13
* **Rol:** Cajero
* **Descripción:**
  > **Como** cajero del bar,  
  > **quiero** registrar el pago de la cuenta seleccionando el método utilizado (Efectivo, Transferencia DeUna/Pichincha, Tarjeta de crédito o débito),  
  > **para** liquidar el saldo pendiente y cerrar financieramente la atención.
* **Criterios de Aceptación:**
  1. Permite seleccionar el método de pago con el que cancela el cliente (Efectivo, Transferencia DeUna, Tarjeta).
  2. Permite registrar pagos mixtos si fuera necesario (ej. parte efectivo, parte transferencia).
  3. Si es transferencia, permite registrar el número de referencia o comprobante.
  4. Marca la cuenta como **"Pagada"**.

---

### **US-14: Emisión de comprobante y liberación de espacio**
* **Código:** US-14
* **Rol:** Cajero / Cliente
* **Descripción:**
  > **Como** cajero (y cliente),  
  > **quiero** generar el comprobante detallado de consumo y dar por finalizada la sesión de la mesa o sala,  
  > **para** entregar un respaldo físico o digital al cliente y liberar el espacio para la siguiente reserva.
* **Criterios de Aceptación:**
  1. Genera un comprobante digital descargable o imprimible con el detalle de consumos, horas de karaoke (si aplica), anticipo acreditado, método de pago y total final.
  2. Finaliza formalmente la sesión del espacio físico.
  3. El espacio físico (mesa o sala) cambia su estado a **"Disponible"** en el mapa del local.

---

## EP-05: Seguridad y Roles de Usuario

### **US-15: Autenticación del personal del bar**
* **Código:** US-15
* **Rol:** Empleado del bar (Admin, Cajero, Mesero, Cocinero)
* **Descripción:**
  > **Como** empleado del bar,  
  > **quiero** iniciar sesión con mi correo electrónico y contraseña,  
  > **para** acceder a las funciones del sistema según mi puesto de trabajo de forma segura.
* **Criterios de Aceptación:**
  1. El sistema valida las credenciales y genera una sesión autenticada.
  2. Muestra un mensaje de error claro en caso de credenciales incorrectas.
  3. Permite cerrar sesión en cualquier momento protegiendo la terminal o dispositivo.

---

### **US-16: Control de accesos y vistas según el rol**
* **Código:** US-16
* **Rol:** Empleado del bar
* **Descripción:**
  > **Como** empleado del bar autenticado,  
  > **quiero** que el sistema me presente únicamente las opciones y pantallas que corresponden a mis responsabilidades,  
  > **para** trabajar de forma enfocada sin interferir en módulos ajenos a mi labor.
* **Criterios de Aceptación:**
  1. **Administrador:** Acceso irrestricto (configuración de espacios, menú/combos, usuarios y reportes).
  2. **Cajero:** Acceso a gestión de reservas, apertura/cierre de cuentas, cobros y comprobantes.
  3. **Mesero:** Acceso a mapa de mesas/salas activas, toma de pedidos y entrega de órdenes.
  4. **Cocinero / Barman:** Acceso exclusivo a la pantalla operativa de comandas y pedidos entrantes para cambio de estados.
  5. **Cliente:** Acceso público al catálogo y reservas; acceso al pedido de mesa/sala mediante escaneo de QR.
