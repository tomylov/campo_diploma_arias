CREATE DATABASE campo_diploma
GO
USE campo_diploma

create table Clientes(
dni int primary key, 
nombre varchar(60),
email varchar(60),
ra varchar(10),
telefono varchar(20)
)

create table Cuentas_Corrientes(
id_cc int primary key identity, 
saldo decimal(15,2),
plazo datetime,
dni int references Clientes(dni)
)

create table Ventas(
id_venta int primary key identity, 
fecha datetime,
estado int,
dni int references Clientes(dni)
)


create table Productos(
id_prod int primary key identity, 
nombre varchar(60),
stock int,
precio decimal(15,2)
)

create table Detalle_ventas(
id_detalle int primary key identity, 
cantidad int,
precio decimal(15,2),
id_prod int references Productos(id_prod),
id_venta int references Ventas(id_venta)
)

Create table Comprobantes(
id_comp int primary key identity,
tipo int,
numero int)

create table Movimientos(
id_mov int primary key identity, 
tipo int,
fecha datetime,
monto decimal(15,2),
id_cc int references Cuentas_Corrientes(id_cc),
id_comp int references Comprobantes(id_comp)
)

create table Notas_debitos(
numero int primary key identity,
monto decimal(15,2),
fecha datetime,
id_cc int references Cuentas_Corrientes(id_cc))

create table Pagos(
numero int primary key identity,
monto decimal(15,2),
fecha datetime,
id_venta int references Ventas(id_venta))

create table Medio_Pagos(
id_med_pago int primary key identity,
descripcion varchar(60))

create table Tipo_Facturas(
id_tipo_fact int primary key identity,
descripcion VARCHAR(60)
)

create table Facturas(
id_factura int primary key identity,
id_med_pagos int references Medio_Pagos(id_med_pago),
id_tipo_fact int references Tipo_Facturas(id_tipo_fact),
id_venta int references Ventas(id_venta),
estado int,
fecha datetime,
total decimal(15,2)
)
--INSERT CLIENTES
insert into Clientes values(1,'Tomas','tomas.arias2001@gmail.com','RA','3413598175')
insert into Clientes values(2,'Juan','tomas.arias2001@gmail.com','RA','3413598175')

--INSERT CLIENTES CC
insert into Cuentas_Corrientes values(0,CONVERT(date,getdate()),1)
insert into Cuentas_Corrientes values(0,CONVERT(date,getdate()),2)

--INSERT VENTAS 
insert into Ventas values(CONVERT(date,getdate()),1,1)
insert into Ventas values(CONVERT(date,getdate()),1,2)
insert into Ventas values(CONVERT(date,getdate()),1,1)
insert into Ventas values(CONVERT(date,getdate()),1,2)

--INSERT PRODUCTOS
insert into Productos values('Mother',100000.00)
insert into Productos values('Grafica',250000.33)
insert into Productos values('Procesador',231346.70)

--INSERT DETALLE VENTA
--VTA 1
INSERT INTO Detalle_ventas values(2,231346.70,3,2)
INSERT INTO Detalle_ventas values(1,250000.33,2,2)
INSERT INTO Detalle_ventas values(1,100000.00,1,2)
--VTA 2
INSERT INTO Detalle_ventas values(1,250000.33,2,1)
INSERT INTO Detalle_ventas values(1,100000.00,1,1)
--VTA 3
INSERT INTO Detalle_ventas values(1,100000.00,1,3)
--VTA 4
INSERT INTO Detalle_ventas values(1,250000.33,2,4)

select * from Ventas 

update Ventas set estado=1 
update Cuentas_Corrientes set saldo=0.00
delete Movimientos
delete Comprobantes
delete Pagos