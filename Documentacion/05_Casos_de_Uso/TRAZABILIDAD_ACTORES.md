# Trazabilidad de actores de los casos de uso


El actor de cada caso de uso se tomó del rol «Como…» de la historia correspondiente en backlog_datos.py. Los actores Pasarela de pagos y Surtidor RFID son sistemas externos o dispositivos: no aparecen en el backlog como rol de historia, pero son necesarios para modelar el pago y la dispensación.

| Caso de uso | Historia | Rol en el backlog | Actores en el diagrama |
|---|---|---|---|
| CU-01 Iniciar sesión | HU-01 | empleado | Personal (Administrador, Mesero, Cajero y Encargado de Karaoke lo heredan) |
| CU-02 Administrar usuarios y roles | HU-02 | administrador | Administrador |
| CU-03 Administrar salas y bloques | HU-04 | administrador | Administrador |
| CU-04 Consultar disponibilidad | HU-05 | cliente | Cliente |
| CU-05 Registrar reserva | HU-06 | cliente | Cliente |
| CU-06 Pagar anticipo | HU-07 | cliente | Cliente; Pasarela de pagos |
| CU-07 Consultar o cancelar reserva | HU-08 | cliente | Cliente |
| CU-08 Validar llegada y abrir sesión | HU-09 | cajero | Cajero |
| CU-09 Asociar o desactivar RFID | HU-10 | cajero | Cajero |
| CU-10 Acceder por QR | HU-11 | cliente | Cliente |
| CU-11 Administrar menú | HU-12 | administrador | Administrador |
| CU-12 Pedir comida | HU-13 | cliente | Cliente; Mesero (ver nota 1) |
| CU-13 Atender pedidos | HU-14 | mesero | Mesero |
| CU-14 Configurar bebidas e inventario | HU-15, HU-17 | administrador | Administrador |
| CU-15 Autorizar y registrar dispensación | HU-16 | cliente | Cliente; Surtidor RFID |
| CU-16 Buscar o solicitar canción | HU-19 | cliente | Cliente |
| CU-17 Adquirir premium | HU-20 | cliente | Cliente |
| CU-18 Gestionar cola | HU-21 | encargado de karaoke | Encargado de Karaoke |
| CU-19 Consultar cuenta | HU-22 | cliente o cajero | Cliente; Cajero |
| CU-20 Cobrar y cerrar cuenta | HU-23 | cajero | Cajero |
| CU-21 Emitir comprobante | HU-24 | cliente | Cliente; Cajero (ver nota 2) |
| CU-22 Ajustes y devoluciones | HU-25 | administrador | Administrador |
| CU-23 Consultar o exportar reportes | HU-26, HU-27 | administrador | Administrador |
| CU-24 Configurar promociones | HU-28 | administrador | Administrador |
| CU-25 Consultar bitácora y conciliación | HU-03, HU-18 | administrador | Administrador |

Notas:

1. El backlog define HU-13 solo para el cliente. El Mesero se mantiene en CU-12 porque el documento indica que usa la misma aplicación; si el PO decide que el mesero no toma pedidos en nombre del cliente, se elimina esa asociación.
2. Corrección aplicada: CU-21 solo tenía al Cajero, pero HU-24 está escrita para el cliente. Se agregó el Cliente; el Cajero se conserva porque emite el comprobante al cerrar la cuenta (HU-23).
3. HU-29 (interfaces móviles y tablets) y HU-30 (despliegue y recuperación) son requisitos transversales y no tienen caso de uso propio. Se cubren con los mockups (T-13), la arquitectura y el plan de sprints.
