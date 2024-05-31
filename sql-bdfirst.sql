CREATE DATABASE campo_diploma
--drop database campo_diploma
GO
USE campo_diploma

create table Clientes(
--id_cliente int primary key identity,
dni int primary key, 
nombre varchar(60),
email varchar(60),
ra varchar(10),
telefono varchar(20),
estado int
)

create table Cuentas_Corrientes(
id_cc int primary key identity, 
saldo decimal(15,2),
plazo datetime,
id_cliente int references Clientes(id_cliente)
)

create table Ventas(
id_venta int primary key identity, 
fecha datetime,
estado int references Estado_venta(id_estado),
id_cliente int references Clientes(id_cliente),
id_comp int references Comprobantes(id_comp)
)

create table Estado_venta(
id_estado int primary key identity,
descripcion varchar(60)
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

create table tipo_movimientos(
id_tipo_mov int primary key identity,
descripcion varchar(10)
)

/* create table Notas_creditos(
numero int primary key identity,
monto decimal(15,2),
fecha datetime,
id_cc int references Cuentas_Corrientes(id_cc),
id_comp int references Comprobantes(id_comp)
) */

create table Notas_debitos(
numero int primary key identity,
monto decimal(15,2),
fecha datetime,
id_cc int references Cuentas_Corrientes(id_cc),
id_comp int references Comprobantes(id_comp)
)

create table Pagos(
numero int primary key identity,
monto decimal(15,2),
fecha datetime,
id_venta int references Ventas(id_venta),
id_med_pago int references Medio_Pagos(id_med_pago),
id_comp int references Comprobantes(id_comp)
)

create table Medio_Pagos(
id_med_pago int primary key identity,
descripcion varchar(60))

--seguridad
create table Usuarios(
id_usuario int primary key identity,
nombre varchar(60),
apellido varchar(60),
email varchar(60),
clave varchar(60)
)

create table Grupos(
id_grupo int primary key identity,
grupo_nombre varchar(60),
)

create table UsuarioGrupos(
PRIMARY KEY (id_usuario,id_grupo),
id_usuario INT REFERENCES Usuarios(id_usuario),
id_grupo INT REFERENCES Grupos(id_grupo)
)

Create table Modulos(
id_modulo INT PRIMARY KEY IDENTITY,
nombre varchar(20)
)

Create table Formularios(
id_formulario INT PRIMARY KEY IDENTITY,
nombre varchar(30),
id_modulo INT REFERENCES Modulos(id_modulo)
)

CREATE TABLE Permisos (
id_permiso INT PRIMARY KEY IDENTITY,
nombre_permiso VARCHAR(100),
id_formulario INT REFERENCES Formularios(id_formulario)
)

CREATE TABLE PermisoUsuarios (
PRIMARY KEY (id_usuario,id_permiso),
id_usuario INT REFERENCES Usuarios(id_usuario),
id_permiso INT REFERENCES Permisos(id_permiso)
)

CREATE TABLE PermisoGrupos(
PRIMARY KEY (id_permiso,id_grupo),
id_permiso INT REFERENCES Permisos(id_permiso),
id_grupo INT REFERENCES Grupos(id_grupo)
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
insert into Productos values('Mother',1,100000.00)
insert into Productos values('Grafica',4,250000.33)
insert into Productos values('Procesador',100,231346.70)

select * from Productos where nombre like '%mo%'

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
