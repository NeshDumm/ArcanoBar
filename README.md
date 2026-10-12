# Sistema de Gestión de Bar - Proyecto Académico de Anaela Pozo, Estefanía Tenorio y Óscar Ortega

Este repositorio contiene el desarrollo del sistema de gestión y administración para el bar **ArcanosBar**, elaborado como parte de la asignatura Diseño de Aplicaciones y Servicios de Internet.

El proyecto se desarrolla usando ASP.NET Core Web API como backend y Blazor WebAssembly como frontend, bajo la metodología ágil Scrum, con entregables funcionales semanales y de forma progresiva a lo largo de 16 semanas.

## Objetivo del Sistema
Diseñar e implementar una aplicación web que permita:
- Registrar productos (bebidas y alimentos)
- Gestionar ventas, pedidos y cuentas por mesa
- Controlar el inventario de insumos
- Generar reportes de ventas
- Administrar roles de usuarios (mesero, administrador, etc.)

## Tecnologías Utilizadas
- **Frontend:** Blazor WebAssembly
- **Backend:** ASP.NET Core WEB API
- **Base de Datos:** SQL Server, Entity Framework Core (SQL Server Management Studio)
- **Herramientas complementarias:** .NET SDK, Visual Studio 2022 o superior, Postman, Git y GitHub

## Equipo Scrum

| Nombre | Rol Scrum |
| :--- | :--- |
| Jose Naranjo | Product Owner |
| Anaela Pozo | Scrum Master / Development Member |
| Estefanía Tenorio | Development Member |
| Óscar Ortega | Development Member |

*(Nota: Pueden cambiar quién de ustedes 3 es el Scrum Master, lo dejé en Anaela como ejemplo).*

## Backlog del Producto
Accede al tablero ágil donde organizamos nuestras User Stories:
[ENLACE AL TABLERO DE TRELLO O JIRA AQUÍ]

## Cómo Ejecutar el Proyecto
1. Clona el repositorio:
   `git clone [URL_DE_TU_REPOSITORIO_AQUI.git]`
2. Abre el proyecto en Visual Studio.

## Estructura del Proyecto
- `/BarAPI` → Backend
- `/BarCliente` → Frontend
- `/Pages` → Interfaces Blazor
- `/Data` → Modelos y DbContext (EF Core)
- `/Shared` → Componentes reutilizables
- `/wwwroot` → Recursos estáticos (CSS, imágenes)
- `/Migrations` → Archivos de migración de la BD

## Avance por Sprint

| Semana | Sprint / Entregable | Estado |
| :--- | :--- | :--- |
| 1 | Configuración de entorno y backlog | Terminado |
| 2 | Diseño general del sistema | En progreso |
| 3 | Registro y gestión de productos | En progreso |
| 4 | Módulo de pedidos | En progreso |

## Notas Adicionales
- Este proyecto es con fines académicos.
- El desarrollo es incremental y está alineado con prácticas ágiles.
- Para reportar errores o mejoras, usa la sección Issues.