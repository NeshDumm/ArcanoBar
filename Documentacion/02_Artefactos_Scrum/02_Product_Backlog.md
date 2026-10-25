# Product Backlog - ArcanosBar

**Proyecto:** ArcanosBar - Sistema de Gestión de Bar Karaoke  
**Asignatura:** Diseño de Aplicaciones y Servicios para Internet (ITID803)  
**Metodología:** Scrum  
**Product Owner:** Ing. Jose Naranjo  
**Scrum Master:** Óscar Ortega  
**Development Team:** Anaela Pozo, Estefanía Belén Tenorio  
**Tablero Jira:** [Tablero Scrum ArcanosBar](https://anaelapozo192.atlassian.net/jira/software/projects/SCRUM/boards/1)

---

## 1. Definición y Criterios del Backlog

El **Product Backlog** es el inventario centralizado y priorizado de todos los requisitos del sistema ArcanosBar.
- **Priorización MoSCoW:**
  - **Must have (Debe tener):** Requisitos críticos sin los cuales el sistema no puede operar.
  - **Should have (Debería tener):** Requisitos de alto valor que complementan la operativa esencial.
  - **Could have (Podría tener):** Mejoras deseables si el tiempo y recursos lo permiten.
- **Estimación:** Secuencia de Fibonacci en Story Points (1, 2, 3, 5, 8).
- **Trazabilidad:** Cada ítem hace referencia directa al documento de [01_Historias_de_Usuario.md](file:///d:/achte%20semmester/Itinerario/AcanoBar/Documentacion/02_Artefactos_Scrum/01_Historias_de_Usuario.md).

---

## 2. Tabla Consolidada del Product Backlog

| ID | Historia / Tarea | Épica / Módulo | Rol Principal | Prioridad | Story Points | Sprint Planificado |
| :--- | :--- | :--- | :--- | :---: | :---: | :---: |
| **PBI-01** | Configuración de entorno (.NET 8, Web API, Blazor, SQL Server, Git) | Técnica / Base | Todo el Equipo | **Must have** | 3 | **Sprint 1 (Actual)** |
| **US-01** | Visualización de catálogo y combos (Endpoint `/api/combos` y Blazor) | EP-01: Catálogo | Cliente / Visitante | **Must have** | 5 | **Sprint 1 (Actual)** |
| **US-02** | Administración de productos y combos (Crear, Editar, Agotar) | EP-01: Catálogo | Administrador | **Must have** | 5 | Sprint 2 |
| **US-06** | Configuración de espacios físicos (6 salas karaoke, 10 mesas, tarifas) | EP-02: Reservas | Administrador | **Must have** | 3 | Sprint 2 |
| **US-15** | Autenticación del personal del bar (Login empleados) | EP-05: Seguridad | Empleado del Bar | **Must have** | 5 | Sprint 2 |
| **US-16** | Control de accesos y vistas según el rol del usuario | EP-05: Seguridad | Empleado del Bar | **Should have**| 5 | Sprint 3 |
| **US-03** | Consulta de disponibilidad de salas y mesas | EP-02: Reservas | Cliente / Cajero | **Must have** | 8 | Sprint 3 |
| **US-04** | Registro de reserva con cálculo de anticipo del 25% | EP-02: Reservas | Cliente | **Must have** | 8 | Sprint 4 |
| **US-05** | Confirmación y administración de reservas (Cajero/Admin) | EP-02: Reservas | Cajero / Admin | **Should have**| 5 | Sprint 4 |
| **US-07** | Vinculación a mesa/sala por código QR con sesión persistente | EP-03: Pedidos | Cliente | **Must have** | 5 | Sprint 5 |
| **US-08** | Registro y envío continuo de pedidos desde la app web | EP-03: Pedidos | Cliente | **Must have** | 8 | Sprint 5 |
| **US-09** | Toma de pedidos presencial por Mesero | EP-03: Pedidos | Mesero | **Should have**| 5 | Sprint 6 |
| **US-10** | Pantalla operativa de cocina/barra y avance de estados | EP-03: Pedidos | Cocinero / Barman | **Must have** | 5 | Sprint 6 |
| **US-11** | Seguimiento de estados y cancelación de pedidos | EP-03: Pedidos | Cliente / Mesero | **Should have**| 5 | Sprint 7 |
| **US-12** | Precuenta con regla de Karaoke (gratis >= $50) y abono 25% | EP-04: Cuentas | Cliente / Cajero | **Must have** | 8 | Sprint 7 |
| **US-13** | Cobro y registro de métodos de pago (Efectivo, DeUna, Tarjeta) | EP-04: Cuentas | Cajero | **Must have** | 5 | Sprint 8 |
| **US-14** | Emisión de comprobante y liberación de espacios físicos | EP-04: Cuentas | Cajero / Cliente | **Should have**| 3 | Sprint 8 |

---

## 3. Sprint 1 Backlog (Entregable Práctica 01)

* **Objetivo del Sprint 1:** Establecer la base de desarrollo (arquitectura cliente-servidor con ASP.NET Core Web API y Blazor WebAssembly), configurar Swagger, CORS, control de versiones y publicar el primer catálogo inicial funcional de combos consumido desde el backend.
* **Capacidad del Sprint 1:** 8 Story Points.
* **Historias Seleccionadas:**
  1. **PBI-01: Configuración de Entorno y Proyecto (3 SP)**
     - Solución de Visual Studio con proyectos `BarAPI` y `BarCliente`.
     - Configuración de Swagger y documentación de API.
     - Configuración de política CORS (`PermitirBlazor`) en Web API.
     - Repositorio GitHub con ramas de desarrollo y README oficial.
  2. **US-01: Visualización del Catálogo Inicial de Combos (5 SP)**
     - Endpoint funcional en `BarAPI/Controllers/CombosController.cs` (`GET /api/combos`).
     - Componente Blazor en `BarCliente/Pages/Home.razor` que consume el endpoint mediante `HttpClient` y despliega la lista interactiva.
