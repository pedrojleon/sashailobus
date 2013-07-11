/********************************************* INICIO - CREACION ESQUEMA *******************************************/

USE GD1C2013;
GO
CREATE SCHEMA SASHAILO AUTHORIZATION gd

GO 

/********************************************* FIN - CREACION ESQUEMA **********************************************/


/******************************************** INICIO - CREACION DE TABLAS ******************************************/

CREATE TABLE SASHAILO.Rol(
	ID_ROL int not null IDENTITY,
	NOMBRE varchar(20) not null UNIQUE,
	HABILITADO char(1) not null DEFAULT 'S',
	ELIMINADO char(1) not null DEFAULT 'N'
	PRIMARY KEY (ID_ROL)
) 

GO

CREATE TABLE SASHAILO.Funcion(
	ID_FUNCION int PRIMARY KEY NOT NULL IDENTITY,
	DESCRIPCION nvarchar(255)
) 

GO

CREATE TABLE SASHAILO.FuncionxRol(
    ID_FUNCIONXROL int PRIMARY KEY NOT NULL IDENTITY,
	ID_FUNCION int NOT NULL FOREIGN KEY REFERENCES SASHAILO.Funcion(ID_FUNCION),
	ID_ROL int NOT NULL FOREIGN KEY REFERENCES SASHAILO.Rol(ID_ROL),
	UNIQUE(ID_FUNCION,ID_ROL)
) 

GO

CREATE TABLE SASHAILO.Usuario(
	ID_USUARIO int not null IDENTITY,
	USUARIO varchar(15) not null,
	PASS varchar(64) not null,
	LOGIN_FALLIDOS smallint not null DEFAULT 0,
	BLOQUEADO char(1) not null DEFAULT 'N',
	HABILITADO char(1) not null DEFAULT 'S',
	UNIQUE(USUARIO),
	PRIMARY KEY(ID_USUARIO)
)

GO

CREATE TABLE SASHAILO.RolxUsuario(
	ID_ROLXUSUARIO int PRIMARY KEY NOT NULL IDENTITY,
	ID_ROL int NOT NULL FOREIGN KEY REFERENCES SASHAILO.Rol(ID_ROL),
	ID_USUARIO int NOT NULL FOREIGN KEY REFERENCES SASHAILO.Usuario(ID_USUARIO),
	UNIQUE(ID_ROL,ID_USUARIO)
)

GO

CREATE TABLE SASHAILO.Ciudad(
	ID_CIUDAD int not null IDENTITY,
	NOMBRE_CIUDAD varchar(60) not null,
	HABILITADA char(1) not null DEFAULT 'S',
	UNIQUE(NOMBRE_CIUDAD),
	PRIMARY KEY (ID_CIUDAD)
)

GO

CREATE TABLE SASHAILO.Recorrido_Ciudades(
	ID_RECORRIDO_CIUDADES int not null IDENTITY,
	ID_CIUDAD_ORIGEN int FOREIGN KEY REFERENCES SASHAILO.Ciudad(ID_CIUDAD),
	ID_CIUDAD_DESTINO int FOREIGN KEY REFERENCES SASHAILO.Ciudad(ID_CIUDAD),
	PRECIO_BASE_KG decimal(10,2),
	PRECIO_BASE_PASAJE decimal(10,2),
	PRIMARY KEY (ID_RECORRIDO_CIUDADES)
) 

GO


CREATE TABLE SASHAILO.Tipo_Servicio(
	ID_TIPO_SERVICIO int PRIMARY KEY NOT NULL IDENTITY,
	DESCRIPCION nvarchar(255),
	ADICIONAL decimal(10,2)
) 

GO

/*CREATE TABLE SASHAILO.Recorrido(
	ID_RECORRIDO numeric(18,0) PRIMARY KEY NOT NULL,
	CODIGO_RECORRIDO nvarchar(15),
	ID_CIUDAD_ORIGEN int FOREIGN KEY REFERENCES SASHAILO.Ciudad(ID_CIUDAD),
	ID_CIUDAD_DESTINO int FOREIGN KEY REFERENCES SASHAILO.Ciudad(ID_CIUDAD),
	PRECIO_BASE_KG decimal(10,2),
	PRECIO_BASE_PASAJE decimal(10,2),
	ID_TIPO_SERVICIO int FOREIGN KEY REFERENCES SASHAILO.Tipo_Servicio(ID_TIPO_SERVICIO),
	HABILITADO char(1) not null DEFAULT 'S'
) 

GO*/

CREATE TABLE SASHAILO.Recorrido(
	ID_RECORRIDO numeric(18,0) PRIMARY KEY NOT NULL,
	CODIGO_RECORRIDO nvarchar(15),
	ID_RECORRIDO_CIUDADES int FOREIGN KEY REFERENCES SASHAILO.Recorrido_Ciudades(ID_RECORRIDO_CIUDADES),
	ID_TIPO_SERVICIO int FOREIGN KEY REFERENCES SASHAILO.Tipo_Servicio(ID_TIPO_SERVICIO),
	HABILITADO char(1) not null DEFAULT 'S'
) 

GO

CREATE TABLE SASHAILO.Tipo_Butaca(
	ID_TIPO_BUTACA int PRIMARY KEY NOT NULL IDENTITY,
	DESCRIPCION nvarchar(50)
) 

GO

CREATE TABLE SASHAILO.Marca_Micro(
	ID_MARCA int PRIMARY KEY NOT NULL IDENTITY,
	DESCRIPCION nvarchar(50)
) 

GO

CREATE TABLE SASHAILO.Micro(
	ID_MICRO int not null IDENTITY,
	PATENTE varchar(7) not null,
	ID_MARCA int FOREIGN KEY REFERENCES SASHAILO.Marca_Micro(ID_MARCA),
	MODELO varchar(25) not null,
	ID_TIPO_SERVICIO int FOREIGN KEY REFERENCES SASHAILO.Tipo_Servicio(ID_TIPO_SERVICIO),
	F_ALTA smalldatetime,
	CANT_BUTACAS int,
	CANT_KG numeric(18,0),
	UNIQUE(PATENTE),
	PRIMARY KEY(ID_MICRO)
)

GO

CREATE TABLE SASHAILO.Estado_Micro(
	ID_ESTADO int not null,
	D_ESTADO varchar(50),
	PRIMARY KEY(ID_ESTADO)
)

GO

CREATE TABLE SASHAILO.Log_Estado_Micro(
	ID_LOG int not null IDENTITY,
	ID_MICRO int FOREIGN KEY REFERENCES SASHAILO.Micro(ID_MICRO),
	ID_ESTADO int FOREIGN KEY REFERENCES SASHAILO.Estado_Micro(ID_ESTADO),
	FECHA datetime,
	FECHA_F_SERVICIO datetime,
	FECHA_REINICIO datetime,
	FECHA_BAJA_DEF datetime,
	PRIMARY KEY(ID_LOG)
)

GO

CREATE TABLE SASHAILO.Butaca(
	ID_BUTACA int not null IDENTITY,
	ID_MICRO int FOREIGN KEY REFERENCES SASHAILO.Micro(ID_MICRO),
	NRO_BUTACA int,
	ID_TIPO_BUTACA int FOREIGN KEY REFERENCES SASHAILO.Tipo_Butaca(ID_TIPO_BUTACA),
	NRO_PISO smallint,
	PRIMARY KEY(ID_BUTACA)
)

GO

CREATE TABLE SASHAILO.Cliente(
	ID_CLIENTE int not null IDENTITY,
	NOMBRE nvarchar(255),
	APELLIDO nvarchar(255),
	DNI numeric(18,0) NOT NULL UNIQUE,
	DIRECCION nvarchar(255),
	TELEFONO numeric(18,0),
	MAIL nvarchar(255),
	F_NACIMIENTO datetime,
	SEXO char(1),
	PUNTOS int DEFAULT 0,
	HABILITADO char(1) not null DEFAULT 'S',
	PRIMARY KEY(ID_CLIENTE)
) 

GO

CREATE TABLE SASHAILO.Producto(
	ID_PRODUCTO int not null IDENTITY,
	DESCRIPCION nvarchar(255),
	STOCK int,
	PUNTOS_NECESARIOS int,
	PRIMARY KEY(ID_PRODUCTO)
) 

GO

CREATE TABLE SASHAILO.Canje(
	ID_CANJE int not null IDENTITY,
	ID_CLIENTE int FOREIGN KEY REFERENCES SASHAILO.Cliente(ID_CLIENTE),
	ID_PRODUCTO int FOREIGN KEY REFERENCES SASHAILO.Producto(ID_PRODUCTO),
	CANTIDAD int not null,
	FECHA datetime not null,
	PRIMARY KEY(ID_CANJE)
) 

GO

CREATE TABLE SASHAILO.Viaje(
	ID_VIAJE int not null IDENTITY,
	ID_RECORRIDO numeric(18,0) FOREIGN KEY REFERENCES SASHAILO.Recorrido(ID_RECORRIDO),
	ID_MICRO int FOREIGN KEY REFERENCES SASHAILO.Micro(ID_MICRO),
	F_SALIDA datetime,
	F_LLEGADA_ESTIMADA datetime,
	F_LLEGADA datetime,
	CANCELADO char(1) not null DEFAULT 'N',
	PRIMARY KEY (ID_VIAJE)
) 

GO

CREATE TABLE SASHAILO.Tipo_Tarjeta(
	ID_TIPO_TARJETA int not null IDENTITY,
	DESCRIPCION nvarchar(30) not null,
	CUOTAS int not null,
	PRIMARY KEY (ID_TIPO_TARJETA)
) 

GO

CREATE TABLE SASHAILO.Tarjeta_Credito(
	ID_TARJETA int not null IDENTITY,
	NRO_TARJETA nvarchar(16) not null UNIQUE,
	VENCIMIENTO nvarchar(4) not null,
	CODIGO_SEGURIDAD nvarchar(3) not null,
	ID_TIPO_TARJETA int FOREIGN KEY REFERENCES SASHAILO.Tipo_Tarjeta(ID_TIPO_TARJETA),
	PRIMARY KEY (ID_TARJETA)
) 

GO

CREATE TABLE SASHAILO.Medio_Pago(
	ID_MEDIO_PAGO int not null IDENTITY,
	DESCRIPCION nvarchar(30) not null,
	PRIMARY KEY (ID_MEDIO_PAGO)
) 

GO

CREATE TABLE SASHAILO.Compra(
	ID_COMPRA int PRIMARY KEY not null,
	F_COMPRA datetime not null,
	IMPORTE numeric(18,2) not null,
	ID_CLIENTE int FOREIGN KEY REFERENCES SASHAILO.Cliente(ID_CLIENTE),
	ID_MEDIO_PAGO int FOREIGN KEY REFERENCES SASHAILO.Medio_Pago(ID_MEDIO_PAGO),
	ID_TARJETA int FOREIGN KEY REFERENCES SASHAILO.Tarjeta_Credito(ID_TARJETA)
) 

GO

/*CREATE TABLE SASHAILO.Pasaje_Encomienda(
	ID_PASAJE_ENCOMIENDA numeric(18,0) PRIMARY KEY NOT NULL,
	ID_COMPRA int,
	ID_CLIENTE int FOREIGN KEY REFERENCES SASHAILO.Cliente(ID_CLIENTE),
	ID_VIAJE int FOREIGN KEY REFERENCES SASHAILO.Viaje(ID_VIAJE),
	ID_BUTACA int FOREIGN KEY REFERENCES SASHAILO.Butaca(ID_BUTACA),
	ID_TIPO_PASAJE int FOREIGN KEY REFERENCES SASHAILO.Tipo_Pasaje(ID_TIPO_PASAJE),
	PRECIO numeric(18,2),
	KG numeric(18,0)
) 

GO*/

CREATE TABLE SASHAILO.Pasaje(
	ID_PASAJE numeric(18,0) PRIMARY KEY NOT NULL,
	ID_COMPRA int,
	ID_CLIENTE int FOREIGN KEY REFERENCES SASHAILO.Cliente(ID_CLIENTE),
	ID_VIAJE int FOREIGN KEY REFERENCES SASHAILO.Viaje(ID_VIAJE),
	ID_BUTACA int FOREIGN KEY REFERENCES SASHAILO.Butaca(ID_BUTACA),
	DISCAPACIDAD char(1) not null DEFAULT 'N',
	PRECIO numeric(18,2),
) 

GO

CREATE TABLE SASHAILO.Encomienda(
	ID_ENCOMIENDA numeric(18,0) PRIMARY KEY NOT NULL,
	ID_COMPRA int,
	ID_CLIENTE int FOREIGN KEY REFERENCES SASHAILO.Cliente(ID_CLIENTE),
	ID_VIAJE int FOREIGN KEY REFERENCES SASHAILO.Viaje(ID_VIAJE),
	KG numeric(18,0),
	PRECIO numeric(18,2)
) 

GO

CREATE TABLE SASHAILO.Devolucion(
	ID_DEVOLUCION int not null IDENTITY,
	ID_PASAJE numeric(18,0) FOREIGN KEY REFERENCES SASHAILO.Pasaje(ID_PASAJE),
	ID_ENCOMIENDA numeric(18,0) FOREIGN KEY REFERENCES SASHAILO.Encomienda(ID_ENCOMIENDA),
	F_DEVOLUCION datetime not null,
	MOTIVO nvarchar(255),
	PRIMARY KEY (ID_DEVOLUCION)
) 

GO

CREATE TABLE SASHAILO.Llegada(
	ID_LLEGADA int not null IDENTITY,
	PATENTE varchar(7) not null,
	ID_MICRO int FOREIGN KEY REFERENCES SASHAILO.Micro(ID_MICRO),
	F_LLEGADA datetime not null,
	ID_VIAJE int FOREIGN KEY REFERENCES SASHAILO.Viaje(ID_VIAJE) not null,
	ID_CIUDAD_ORIGEN int FOREIGN KEY REFERENCES SASHAILO.Ciudad(ID_CIUDAD) not null,
	ID_CIUDAD_DESTINO int FOREIGN KEY REFERENCES SASHAILO.Ciudad(ID_CIUDAD) not null,
	D_ERROR varchar(255),
	PRIMARY KEY (ID_LLEGADA)
) 

GO

/*CREATE TABLE SASHAILO.Historial_Puntos(
	ID_HISTORIAL_PUNTOS int not null IDENTITY,
	ID_CLIENTE int FOREIGN KEY REFERENCES SASHAILO.Cliente(ID_CLIENTE),
	ID_PASAJE_ENCOMIENDA numeric(18,0) FOREIGN KEY REFERENCES SASHAILO.Pasaje_Encomienda(ID_PASAJE_ENCOMIENDA),
	PUNTOS int not null,
	FECHA datetime not null,
	PRIMARY KEY (ID_HISTORIAL_PUNTOS)
) 

GO*/

CREATE TABLE SASHAILO.Historial_Puntos(
	ID_HISTORIAL_PUNTOS int not null IDENTITY,
	ID_CLIENTE int FOREIGN KEY REFERENCES SASHAILO.Cliente(ID_CLIENTE),
	ID_PASAJE numeric(18,0) FOREIGN KEY REFERENCES SASHAILO.Pasaje(ID_PASAJE),
	ID_ENCOMIENDA numeric(18,0) FOREIGN KEY REFERENCES SASHAILO.Encomienda(ID_ENCOMIENDA),
	PUNTOS int not null,
	FECHA datetime not null,
	PRIMARY KEY (ID_HISTORIAL_PUNTOS)
) 

GO

CREATE TABLE SASHAILO.Pasaje_Encomienda_Temporal(
	ID_PE_TEMPORAL int PRIMARY KEY NOT NULL IDENTITY,
	ID_VIAJE int FOREIGN KEY REFERENCES SASHAILO.Viaje(ID_VIAJE),
	ID_BUTACA int FOREIGN KEY REFERENCES SASHAILO.Butaca(ID_BUTACA),
	ID_CLIENTE int FOREIGN KEY REFERENCES SASHAILO.Cliente(ID_CLIENTE),
	KG numeric(18,0)
) 

GO

/******************************************** FIN - CREACION DE TABLAS *********************************************/

/******************************************** INICIO - CREACION DE INDICES *********************************************/

CREATE INDEX I_BUTACAS
ON SASHAILO.Butaca(ID_MICRO,NRO_BUTACA)
GO

CREATE INDEX I_VIAJES
ON SASHAILO.Viaje(ID_RECORRIDO,ID_MICRO,F_SALIDA,F_LLEGADA_ESTIMADA,F_LLEGADA)
GO

/******************************************** FIN - CREACION DE INDICES *********************************************/


/******************************************** INICIO - LLENADO DE TABLAS *********************************************/

-- ROLES
INSERT INTO SASHAILO.Rol(NOMBRE)
values ('Administrador');
GO
INSERT INTO SASHAILO.Rol(NOMBRE)
values ('Cliente');
GO

-- ESTADO MICRO
INSERT INTO SASHAILO.Estado_Micro(ID_ESTADO, D_ESTADO)
values (1, 'En uso');
GO
INSERT INTO SASHAILO.Estado_Micro(ID_ESTADO, D_ESTADO)
values (2, 'Fuera de Servicio');
GO
INSERT INTO SASHAILO.Estado_Micro(ID_ESTADO, D_ESTADO)
values (3, 'Fin de Vida Útil');
GO

-- TIPO TARJETA
INSERT INTO SASHAILO.Tipo_Tarjeta(DESCRIPCION, CUOTAS)
values ('Visa', 6);
GO
INSERT INTO SASHAILO.Tipo_Tarjeta(DESCRIPCION, CUOTAS)
values ('Mastercard', 3);
GO

-- MEDIO DE PAGO
INSERT INTO SASHAILO.Medio_Pago(DESCRIPCION)
values ('Efectivo');
GO
INSERT INTO SASHAILO.Medio_Pago(DESCRIPCION)
values ('Tarjeta');
GO

--TARJETAS
INSERT INTO SASHAILO.Tarjeta_Credito(NRO_TARJETA, VENCIMIENTO, CODIGO_SEGURIDAD, ID_TIPO_TARJETA)
VALUES('0394878374678374', '1213', '321', 1)
GO
INSERT INTO SASHAILO.Tarjeta_Credito(NRO_TARJETA, VENCIMIENTO, CODIGO_SEGURIDAD, ID_TIPO_TARJETA)
VALUES('3894895094895712', '1113', '674', 1)
GO
INSERT INTO SASHAILO.Tarjeta_Credito(NRO_TARJETA, VENCIMIENTO, CODIGO_SEGURIDAD, ID_TIPO_TARJETA)
VALUES('9998887376711123', '1213', '934', 2)
GO
INSERT INTO SASHAILO.Tarjeta_Credito(NRO_TARJETA, VENCIMIENTO, CODIGO_SEGURIDAD, ID_TIPO_TARJETA)
VALUES('0011929283674653', '1113', '713', 2)
GO

--FUNCIONES
INSERT INTO SASHAILO.Funcion(DESCRIPCION)
values ('ABM de Rol');
GO
INSERT INTO SASHAILO.Funcion(DESCRIPCION)
values ('ABM de Ciudad');
GO
INSERT INTO SASHAILO.Funcion(DESCRIPCION)
values ('ABM de Recorrido');
GO
INSERT INTO SASHAILO.Funcion(DESCRIPCION)
values ('ABM de Micro');
GO
INSERT INTO SASHAILO.Funcion(DESCRIPCION)
values ('Generación de Viaje');
GO
INSERT INTO SASHAILO.Funcion(DESCRIPCION)
values ('Registro de llegada a Destino');
GO
INSERT INTO SASHAILO.Funcion(DESCRIPCION)
values ('Compra de Pasaje/Encomienda');
GO
INSERT INTO SASHAILO.Funcion(DESCRIPCION)
values ('Devolución/Cancelación de pasaje y/o encomienda');
GO
INSERT INTO SASHAILO.Funcion(DESCRIPCION)
values ('Consulta de puntos de pasajero frecuente');
GO
INSERT INTO SASHAILO.Funcion(DESCRIPCION)
values ('Listado Estadístico');
GO

-- FUNCIONES X ROL
INSERT INTO SASHAILO.FuncionxRol(ID_ROL, ID_FUNCION)
values(1,1)
GO
INSERT INTO SASHAILO.FuncionxRol(ID_ROL, ID_FUNCION)
values(1,2)
GO
INSERT INTO SASHAILO.FuncionxRol(ID_ROL, ID_FUNCION)
values(1,3)

GO
INSERT INTO SASHAILO.FuncionxRol(ID_ROL, ID_FUNCION)
values(1,4)
GO
INSERT INTO SASHAILO.FuncionxRol(ID_ROL, ID_FUNCION)
values(1,5)
GO
INSERT INTO SASHAILO.FuncionxRol(ID_ROL, ID_FUNCION)
values(1,6)
GO
INSERT INTO SASHAILO.FuncionxRol(ID_ROL, ID_FUNCION)
values(1,10)
GO

-- PRODUCTOS
INSERT INTO SASHAILO.Producto(DESCRIPCION, STOCK, PUNTOS_NECESARIOS)
VALUES('Pelota de Futbol', 5, 100)
GO
INSERT INTO SASHAILO.Producto(DESCRIPCION, STOCK, PUNTOS_NECESARIOS)
VALUES('Oso de peluche', 5, 100)
GO
INSERT INTO SASHAILO.Producto(DESCRIPCION, STOCK, PUNTOS_NECESARIOS)
VALUES('Pava Eléctrica', 3, 300)
GO
INSERT INTO SASHAILO.Producto(DESCRIPCION, STOCK, PUNTOS_NECESARIOS)
VALUES('Reproductor de DVD', 4, 200)
GO
INSERT INTO SASHAILO.Producto(DESCRIPCION, STOCK, PUNTOS_NECESARIOS)
VALUES('Afeitadora Eléctrica', 4, 300)
GO
INSERT INTO SASHAILO.Producto(DESCRIPCION, STOCK, PUNTOS_NECESARIOS)
VALUES('Metegol', 4, 3000)
GO
INSERT INTO SASHAILO.Producto(DESCRIPCION, STOCK, PUNTOS_NECESARIOS)
VALUES('Televisor LCD', 4, 5000)
GO

/****************** INICIO - CREACION DE USUARIOS ADMINISTRADORES  *******************/

INSERT INTO SASHAILO.Usuario (USUARIO, PASS)
values('admin1', 'E6-B8-70-50-BF-CB-81-43-FC-B8-DB-01-70-A4-DC-9E-D0-0D-90-4D-DD-3')
GO
INSERT INTO SASHAILO.Usuario (USUARIO, PASS)
values('admin2', 'E6-B8-70-50-BF-CB-81-43-FC-B8-DB-01-70-A4-DC-9E-D0-0D-90-4D-DD-3')
GO
INSERT INTO SASHAILO.Usuario (USUARIO, PASS)
values('admin3', 'E6-B8-70-50-BF-CB-81-43-FC-B8-DB-01-70-A4-DC-9E-D0-0D-90-4D-DD-3')
GO
INSERT INTO SASHAILO.RolxUsuario (ID_ROL, ID_USUARIO)
values(1,1)
GO
INSERT INTO SASHAILO.RolxUsuario (ID_ROL, ID_USUARIO)
values(1,2)
GO
INSERT INTO SASHAILO.RolxUsuario (ID_ROL, ID_USUARIO)
values(1,3)
GO

/******************** FIN - CREACION DE USUARIOS ADMINISTRADORES  *******************/


INSERT INTO SASHAILO.Ciudad(NOMBRE_CIUDAD)
SELECT DISTINCT Recorrido_Ciudad_Origen FROM gd_esquema.Maestra where Recorrido_Ciudad_Origen is not null
GO

INSERT INTO SASHAILO.Tipo_Servicio (DESCRIPCION, ADICIONAL) VALUES ('Común', 1.2)
GO
INSERT INTO SASHAILO.Tipo_Servicio (DESCRIPCION, ADICIONAL) VALUES ('Semi-Cama', 1.4)
GO
INSERT INTO SASHAILO.Tipo_Servicio (DESCRIPCION, ADICIONAL) VALUES ('Cama', 1.6)
GO
INSERT INTO SASHAILO.Tipo_Servicio (DESCRIPCION, ADICIONAL) VALUES ('Premium', 1.8)
GO
INSERT INTO SASHAILO.Tipo_Servicio (DESCRIPCION, ADICIONAL) VALUES ('Ejecutivo', 2.0)
GO

-- grabo las tuplas origen destino de los recorridos
INSERT INTO SASHAILO.Recorrido_Ciudades(ID_CIUDAD_ORIGEN, ID_CIUDAD_DESTINO, PRECIO_BASE_KG, PRECIO_BASE_PASAJE)
SELECT distinct ci_o.ID_CIUDAD, ci_d.ID_CIUDAD, 
       (select max(ma2.Recorrido_Precio_BaseKG) from gd_esquema.Maestra ma2 where ma2.Recorrido_Ciudad_Origen = ma.Recorrido_Ciudad_Origen and ma2.Recorrido_Ciudad_Destino = ma.Recorrido_Ciudad_Destino) BASE_KG, 
       (select max(ma3.Recorrido_Precio_BasePasaje) from gd_esquema.Maestra ma3 where ma3.Recorrido_Ciudad_Origen = ma.Recorrido_Ciudad_Origen and ma3.Recorrido_Ciudad_Destino = ma.Recorrido_Ciudad_Destino) BASE_PASAJE
FROM gd_esquema.Maestra ma
JOIN SASHAILO.Ciudad ci_o on ci_o.NOMBRE_CIUDAD = ma.Recorrido_Ciudad_Origen
JOIN SASHAILO.Ciudad ci_d on ci_d.NOMBRE_CIUDAD = ma.Recorrido_Ciudad_Destino
GO

INSERT INTO SASHAILO.Recorrido(ID_RECORRIDO, ID_RECORRIDO_CIUDADES, ID_TIPO_SERVICIO)
select distinct ma.Recorrido_Codigo, rc.ID_RECORRIDO_CIUDADES, ts.ID_TIPO_SERVICIO
from gd_esquema.Maestra ma
join SASHAILO.Ciudad ci_o on ci_o.NOMBRE_CIUDAD = ma.Recorrido_Ciudad_Origen
join SASHAILO.Ciudad ci_d on ci_d.NOMBRE_CIUDAD = ma.Recorrido_Ciudad_Destino
join SASHAILO.Recorrido_Ciudades rc on (rc.ID_CIUDAD_ORIGEN = ci_o.ID_CIUDAD and rc.ID_CIUDAD_DESTINO = ci_d.ID_CIUDAD)
join SASHAILO.Tipo_Servicio ts on ts.DESCRIPCION = ma.Tipo_Servicio
where ma.Recorrido_Precio_BaseKG = 0
GO

UPDATE SASHAILO.Recorrido
SET CODIGO_RECORRIDO = (SELECT upper(SUBSTRING(master.dbo.fn_varbintohexstr(HashBytes('MD5', CAST(ID_RECORRIDO as varchar(10)))), 3, 15)))
;

INSERT INTO SASHAILO.Marca_Micro(DESCRIPCION)
select distinct Micro_Marca
from gd_esquema.Maestra
GO

INSERT INTO SASHAILO.Tipo_Butaca(DESCRIPCION)
select distinct Butaca_Tipo
from gd_esquema.Maestra
where Butaca_Tipo<>'0'
GO

INSERT INTO SASHAILO.Cliente(NOMBRE,APELLIDO,DNI,DIRECCION,TELEFONO,MAIL,F_NACIMIENTO)
SELECT DISTINCT Cli_Nombre, Cli_Apellido, Cli_Dni, Cli_Dir, Cli_Telefono, Cli_Mail, Cli_Fecha_Nac
FROM gd_esquema.Maestra
GO

/******************************************** FIN - LLENADO DE TABLAS ************************************************/

/******************************************** INICIO - CREACION DE STORED PROCEDURES, FUNCIONES Y VISTAS ************************************************/

CREATE PROCEDURE SASHAILO.login
    	@p_usuario VARCHAR(15),
    	@p_password VARCHAR(64),
    	@hayErr int OUT,
    	@errores varchar(200) OUT
AS
	
BEGIN

	SET @hayErr = 0
	SET @errores = ''

	/*verifico que exista el username*/
	DECLARE @existeUser int 
	select @existeUser = (select COUNT(*) from SASHAILO.Usuario where USUARIO=@p_usuario)
	if @existeUser = 0
	BEGIN
		set @hayErr = 1
		set @errores = 'El usuario no existe.'
		RETURN
	END
	
	/*verifico que el usuario no esté bloqueado*/
	DECLARE @bloqueado char 
	select @bloqueado = (select BLOQUEADO from SASHAILO.Usuario where USUARIO=@p_usuario)
	if @bloqueado = 'S'
	BEGIN
		set @hayErr = 1
		set @errores = 'El usuario está bloqueado.'
		RETURN
	END
		
	/*verifico si la password es correcta*/
	DECLARE @password_db varchar(64) 
	select @password_db = (select PASS from SASHAILO.Usuario where USUARIO=@p_usuario)
	IF @password_db <> @p_password
	BEGIN
		
		set @hayErr = 1
		set @errores = 'La contraseña es incorrecta. '
		
		/*sumo los login fallidos*/
		update SASHAILO.Usuario set LOGIN_FALLIDOS=(LOGIN_FALLIDOS + 1) where USUARIO=@p_usuario
		DECLARE @login_fallidos int 
		select @login_fallidos = (select LOGIN_FALLIDOS from SASHAILO.Usuario where USUARIO=@p_usuario)
		
		if @login_fallidos >= 3
		BEGIN
			update SASHAILO.Usuario set BLOQUEADO='S' where USUARIO=@p_usuario
			set @errores = @errores + 'El usuario ha sido bloqueado.'
		END
	
		RETURN
	END
	ELSE
	BEGIN
		/*Se logueó correctamente. Blanqueo los login fallidos*/
		update SASHAILO.Usuario set LOGIN_FALLIDOS=0 where USUARIO=@p_usuario
	END
	
END

GO

CREATE PROCEDURE SASHAILO.sp_canjear_producto
    	@p_id_cliente int,
    	@p_id_producto int,
    	@p_cantidad int,
    	@p_fecha datetime,
    	@hayErr int OUT,
    	@errores varchar(200) OUT
AS
	
BEGIN

	SET @hayErr = 0
	SET @errores = ''

	/*verifico que alcance el stock*/
	DECLARE @stockActual int 
	select @stockActual = (select STOCK from SASHAILO.Producto where ID_PRODUCTO=@p_id_producto)
	if @stockActual < @p_cantidad
	BEGIN
		set @hayErr = 1
		set @errores = 'El stock actual no es suficiente para realizar el canje.'
		RETURN
	END
	
	/*verifico que alcance el stock*/
	DECLARE @puntos_producto int 
	DECLARE @puntos_cliente int
	DECLARE @puntos_totales int
	select @puntos_producto = (select PUNTOS_NECESARIOS from SASHAILO.Producto where ID_PRODUCTO=@p_id_producto)
	select @puntos_cliente = (select PUNTOS from SASHAILO.Cliente where ID_CLIENTE=@p_id_cliente)
	set @puntos_totales = @puntos_producto * @p_cantidad
	if @puntos_totales > @puntos_cliente
	BEGIN
		set @hayErr = 1
		set @errores = 'Los puntos del Cliente no son suficientes para realizar el canje.'
		RETURN
	END
	
	/*realizo el canje*/
	BEGIN TRANSACTION
	
	INSERT INTO SASHAILO.Canje(ID_CLIENTE, ID_PRODUCTO, CANTIDAD, FECHA)
	VALUES(@p_id_cliente, @p_id_producto, @p_cantidad, @p_fecha);
	
	UPDATE SASHAILO.Cliente SET PUNTOS = PUNTOS - (@puntos_producto * @p_cantidad) WHERE ID_CLIENTE = @p_id_cliente
	
	UPDATE SASHAILO.Producto SET STOCK = STOCK - @p_cantidad WHERE ID_PRODUCTO = @p_id_producto
	
	COMMIT TRANSACTION
	
END

GO

CREATE PROCEDURE SASHAILO.sp_registro_llegada
    	@p_patente VARCHAR(7),
		@p_f_llegada datetime,
    	@p_id_origen int,
    	@p_id_destino int,
    	@hayErr int OUT,
    	@errores varchar(200) OUT
AS
	
BEGIN

	SET @hayErr = 0
	SET @errores = 'Se ha registrado la llegada del Micro'

	/*verifico que exista el micro*/
	DECLARE @existePatente int 
	select @existePatente = (select COUNT(*) from SASHAILO.Micro where upper(PATENTE) = upper(@p_patente))
	if @existePatente = 0
	BEGIN
		set @hayErr = 1
		set @errores = 'El Micro ingresado no existe.'
		RETURN
	END
	
	/*verifico que exista el viaje segun los datos ingresados*/
	DECLARE @id_viaje int 
	select @id_viaje = (select vi.ID_VIAJE 
						from SASHAILO.Viaje vi join SASHAILO.Micro mi on mi.ID_MICRO = vi.ID_MICRO
						join SASHAILO.Recorrido re on re.ID_RECORRIDO = vi.ID_RECORRIDO
						join SASHAILO.Recorrido_Ciudades rc on rc.ID_RECORRIDO_CIUDADES = re.ID_RECORRIDO_CIUDADES
						where vi.CANCELADO = 'N' and vi.F_LLEGADA is null and rc.ID_CIUDAD_ORIGEN = @p_id_origen and upper(mi.PATENTE) = upper(@p_patente))
	
	IF @id_viaje is null BEGIN 
		set @hayErr = 1
		set @errores = 'No existe ningún Viaje para el Micro y la Ciudad de Salida ingresadas.'
		RETURN
	END
		
	DECLARE @id_ciudad_llegada int
	select @id_ciudad_llegada = (select rc.ID_CIUDAD_DESTINO
								 from SASHAILO.Viaje vi join SASHAILO.Recorrido re on re.ID_RECORRIDO = vi.ID_RECORRIDO
								 join SASHAILO.Recorrido_Ciudades rc on rc.ID_RECORRIDO_CIUDADES = re.ID_RECORRIDO_CIUDADES
								 where vi.CANCELADO = 'N' and vi.ID_VIAJE = @id_viaje)

	DECLARE @id_micro int
	select @id_micro = (select ID_MICRO from SASHAILO.Viaje where ID_VIAJE = @id_viaje)		
	
	DECLARE @d_error varchar(255)
	set @d_error = ''
	IF @p_id_destino <> @id_ciudad_llegada BEGIN
		set @errores = 'Se ha registrado la Llegada del Micro. La Ciudad de Arribo no fué la que correspondía para el Viaje.'
		set @d_error = 'El Micro arribó a una Ciudad que no correspondía'
	END
		
	BEGIN TRANSACTION						 							 
	INSERT INTO SASHAILO.Llegada(ID_VIAJE, ID_MICRO, PATENTE, ID_CIUDAD_ORIGEN, ID_CIUDAD_DESTINO, F_LLEGADA, D_ERROR)		 
	VALUES(@id_viaje, @id_micro, upper(@p_patente), @p_id_origen, @p_id_destino, @p_f_llegada, @d_error)
	COMMIT TRANSACTION
	
END

GO

CREATE PROCEDURE SASHAILO.rol_alta
	
	@nombreRol varchar(20),
	@FuncionABMRol int,
	@FuncionABMCiudad int,
	@FuncionABMRecorrido int,
	@FuncionABMMicro int,
	@FuncionGeneracionViaje int,
	@FuncionRegistroLlegada int,
	@FuncionCompraPasaje int,
	@FuncionDevolucion int,
	@FuncionConsultaPuntos int,
	@FuncionListadoEstadistico int

AS

-- Cargo las tablas

-- ID DEL ROL
DECLARE @IDROL int = (select ID_ROL from SASHAILO.Rol where NOMBRE = @nombreRol)
-- ID DE FUNCIONES
DECLARE	@idFuncionABMRol int, @idFuncionABMCiudad int, @idFuncionABMRecorrido int, @idFuncionABMMicro int, @idFuncionGeneracionViaje int,	@idFuncionRegistroLlegada int,	@idFuncionDevolucion int, @idFuncionCompraPasaje int, @idFuncionConsultaPuntos int, @idFuncionListadoEstadistico int

select @idFuncionABMCiudad = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'ABM de Ciudad'

select @idFuncionABMRecorrido = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'ABM de Recorrido'

select @idFuncionABMRol = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'ABM de Rol'

select @idFuncionABMMicro = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'ABM de Micro'

select @idFuncionGeneracionViaje = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'Generación de Viaje'

select @idFuncionRegistroLlegada = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'Registro de llegada a Destino'

select @idFuncionDevolucion = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'Devolución/Cancelación de pasaje y/o encomienda'

select @idFuncionCompraPasaje = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'Compra de Pasaje/Encomienda'

select @idFuncionConsultaPuntos = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'Consulta de puntos de pasajero frecuente'

select @idFuncionListadoEstadistico = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'Listado Estadístico'

-- Actualizo las tablas

IF @FuncionABMCiudad != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionABMCiudad, @IDROL)
END

IF @FuncionABMRol != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionABMRol, @IDROL)
END

IF @FuncionABMRecorrido != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionABMRecorrido, @IDROL)
END

IF @FuncionABMMicro != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionABMMicro, @IDROL)
END

IF @FuncionGeneracionViaje != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionGeneracionViaje, @IDROL)
END

IF @FuncionRegistroLlegada != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionRegistroLlegada, @IDROL)
END

IF @FuncionDevolucion != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionDevolucion, @IDROL)
END

IF @FuncionListadoEstadistico != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionListadoEstadistico, @IDROL)
END

IF @FuncionCompraPasaje != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionCompraPasaje, @IDROL)
END

IF @FuncionConsultaPuntos != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionConsultaPuntos, @IDROL)
END

GO

CREATE PROCEDURE SASHAILO.rol_modificacion
	
	@nombreRol varchar(20),
	@FuncionABMRol int,
	@FuncionABMCiudad int,
	@FuncionABMRecorrido int,
	@FuncionABMMicro int,
	@FuncionGeneracionViaje int,
	@FuncionRegistroLlegada int,
	@FuncionCompraPasaje int,
	@FuncionDevolucion int,
	@FuncionConsultaPuntos int,
	@FuncionListadoEstadistico int

AS

-- Cargo las tablas

-- ID DEL ROL
DECLARE @IDROL int = (select ID_ROL from SASHAILO.Rol where NOMBRE = @nombreRol)
-- ID DE FUNCIONES
DECLARE	@idFuncionABMRol int, @idFuncionABMCiudad int, @idFuncionABMRecorrido int, @idFuncionABMMicro int, @idFuncionGeneracionViaje int,	@idFuncionRegistroLlegada int,	@idFuncionDevolucion int, @idFuncionCompraPasaje int, @idFuncionConsultaPuntos int, @idFuncionListadoEstadistico int

select @idFuncionABMCiudad = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'ABM de Ciudad'

select @idFuncionABMRecorrido = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'ABM de Recorrido'

select @idFuncionABMRol = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'ABM de Rol'

select @idFuncionABMMicro = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'ABM de Micro'

select @idFuncionGeneracionViaje = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'Generación de Viaje'

select @idFuncionRegistroLlegada = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'Registro de llegada a Destino'

select @idFuncionDevolucion = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'Devolución/Cancelación de pasaje y/o encomienda'

select @idFuncionCompraPasaje = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'Compra de Pasaje/Encomienda'

select @idFuncionConsultaPuntos = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'Consulta de puntos de pasajero frecuente'

select @idFuncionListadoEstadistico = ID_FUNCION from SASHAILO.Funcion
where DESCRIPCION = 'Listado Estadístico'

-- Actualizo las tablas
DELETE SASHAILO.FuncionxRol where ID_ROL = @IDROL

IF @FuncionABMCiudad != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionABMCiudad, @IDROL)
END

IF @FuncionABMRol != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionABMRol, @IDROL)
END

IF @FuncionABMRecorrido != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionABMRecorrido, @IDROL)
END

IF @FuncionABMMicro != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionABMMicro, @IDROL)
END

IF @FuncionGeneracionViaje != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionGeneracionViaje, @IDROL)
END

IF @FuncionRegistroLlegada != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionRegistroLlegada, @IDROL)
END

IF @FuncionDevolucion != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionDevolucion, @IDROL)
END

IF @FuncionListadoEstadistico != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionListadoEstadistico, @IDROL)
END

IF @FuncionCompraPasaje != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionCompraPasaje, @IDROL)
END

IF @FuncionConsultaPuntos != 0
BEGIN
INSERT INTO SASHAILO.FuncionxRol (ID_FUNCION, ID_ROL) VALUES (@idFuncionConsultaPuntos, @IDROL)
END

GO

CREATE PROCEDURE SASHAILO.listado_recorridos
    	@p_id_ciudad_origen int, 
    	@p_id_ciudad_destino int,
	    @p_m_habilitado char(1)
AS

	SELECT ID_RECORRIDO, ori.NOMBRE_CIUDAD, dest.NOMBRE_CIUDAD, ts.DESCRIPCION, rc.PRECIO_BASE_PASAJE, rc.PRECIO_BASE_KG, re.HABILITADO
	FROM SASHAILO.Recorrido re
	JOIN SASHAILO.Recorrido_Ciudades rc on rc.ID_RECORRIDO_CIUDADES = re.ID_RECORRIDO_CIUDADES
	JOIN SASHAILO.Ciudad ori on ori.ID_CIUDAD = rc.ID_CIUDAD_ORIGEN
	JOIN SASHAILO.Ciudad dest on dest.ID_CIUDAD = rc.ID_CIUDAD_DESTINO
	JOIN SASHAILO.Tipo_Servicio ts on ts.ID_TIPO_SERVICIO = re.ID_TIPO_SERVICIO
	WHERE (@p_id_ciudad_origen is null or ori.ID_CIUDAD = @p_id_ciudad_origen)
	and (@p_id_ciudad_destino is null or dest.ID_CIUDAD = @p_id_ciudad_destino)
	and (@p_m_habilitado is null or re.HABILITADO = @p_m_habilitado)
	;
		
GO

CREATE PROCEDURE SASHAILO.puntos_cliente
    	@p_id_cliente int
AS

	select * from (
		select hp.ID_CLIENTE, hp.ID_PASAJE, ID_ENCOMIENDA, PUNTOS, FECHA, 
			   null PRODUCTO, c_o.NOMBRE_CIUDAD + ' - ' + c_d.NOMBRE_CIUDAD VIAJE
		from SASHAILO.Historial_Puntos hp
		join SASHAILO.Pasaje pa on pa.ID_PASAJE = hp.ID_PASAJE
		join SASHAILO.Viaje vi on vi.ID_VIAJE = pa.ID_VIAJE
		join SASHAILO.Recorrido re on re.ID_RECORRIDO = vi.ID_RECORRIDO
		join SASHAILO.Recorrido_Ciudades rc on rc.ID_RECORRIDO_CIUDADES = re.ID_RECORRIDO_CIUDADES
		join SASHAILO.Ciudad c_o on c_o.ID_CIUDAD = rc.ID_CIUDAD_ORIGEN
		join SASHAILO.Ciudad c_d on c_d.ID_CIUDAD = rc.ID_CIUDAD_DESTINO
		where hp.ID_CLIENTE = @p_id_cliente and hp.ID_PASAJE is not null

		union all

		select hp.ID_CLIENTE, hp.ID_PASAJE, hp.ID_ENCOMIENDA, PUNTOS, FECHA, 
			   null PRODUCTO, c_o.NOMBRE_CIUDAD + ' - ' + c_d.NOMBRE_CIUDAD VIAJE
		from SASHAILO.Historial_Puntos hp
		join SASHAILO.Encomienda en on en.ID_ENCOMIENDA = hp.ID_ENCOMIENDA
		join SASHAILO.Viaje vi on vi.ID_VIAJE = en.ID_VIAJE
		join SASHAILO.Recorrido re on re.ID_RECORRIDO = vi.ID_RECORRIDO
		join SASHAILO.Recorrido_Ciudades rc on rc.ID_RECORRIDO_CIUDADES = re.ID_RECORRIDO_CIUDADES
		join SASHAILO.Ciudad c_o on c_o.ID_CIUDAD = rc.ID_CIUDAD_ORIGEN
		join SASHAILO.Ciudad c_d on c_d.ID_CIUDAD = rc.ID_CIUDAD_DESTINO
		where hp.ID_CLIENTE = @p_id_cliente and hp.ID_ENCOMIENDA is not null

		union all

		select ID_CLIENTE, null ID_PASAJE, null ID_ENCOMIENDA, 
			  -1 * (ca.CANTIDAD * pr.PUNTOS_NECESARIOS) PUNTOS, FECHA,
			  cast(ca.CANTIDAD as varchar) + ' ' + pr.DESCRIPCION PRODUCTO,
			  null VIAJE
		from SASHAILO.Canje ca 
		join SASHAILO.Producto pr on pr.ID_PRODUCTO = ca.ID_PRODUCTO
		where ca.ID_CLIENTE = @p_id_cliente
	) tabla
	order by tabla.FECHA desc
	;
		
GO

CREATE PROCEDURE SASHAILO.sp_alta_recorrido
	@p_id_ciudad_origen INT,
	@p_id_ciudad_destino INT,
	@p_base_kg DECIMAL(10,2),
	@p_base_pasaje DECIMAL(10,2),
	@p_id_tipo_servicio INT,
	@hayErr int OUT,
    @errores varchar(200) OUT
AS
	SET @hayErr = 0
	SET @errores = ''

	DECLARE @id_recorrido int 
	DECLARE @cod_recorrido nvarchar(15) 
	select @id_recorrido = (select MAX(ID_RECORRIDO)+1 from SASHAILO.Recorrido)
	select @cod_recorrido = (SELECT upper(SUBSTRING(master.dbo.fn_varbintohexstr(HashBytes('MD5', CAST(@id_recorrido as varchar(10)))), 3, 15)))
	
	DECLARE @existe_recorrido_ciudades int
	select @existe_recorrido_ciudades = (select COUNT(1) from SASHAILO.Recorrido_Ciudades rc where rc.ID_CIUDAD_ORIGEN = @p_id_ciudad_origen and rc.ID_CIUDAD_DESTINO = @p_id_ciudad_destino)
	DECLARE @id_recorrido_ciudades int
	IF @existe_recorrido_ciudades > 0 BEGIN
		select @id_recorrido_ciudades = (select ID_RECORRIDO_CIUDADES from SASHAILO.Recorrido_Ciudades rc where rc.ID_CIUDAD_ORIGEN = @p_id_ciudad_origen and rc.ID_CIUDAD_DESTINO = @p_id_ciudad_destino)
		update SASHAILO.Recorrido_Ciudades set PRECIO_BASE_KG = @p_base_kg, PRECIO_BASE_PASAJE = @p_base_pasaje WHERE ID_RECORRIDO_CIUDADES = @id_recorrido_ciudades
	END
	ELSE BEGIN
		insert into SASHAILO.Recorrido_Ciudades(ID_CIUDAD_ORIGEN, ID_CIUDAD_DESTINO, PRECIO_BASE_KG, PRECIO_BASE_PASAJE)
		values(@p_id_ciudad_origen, @p_id_ciudad_destino, @p_base_kg, @p_base_pasaje)
		SET @id_recorrido_ciudades = SCOPE_IDENTITY()
	END
	
	INSERT INTO SASHAILO.Recorrido(ID_RECORRIDO, CODIGO_RECORRIDO, ID_RECORRIDO_CIUDADES, ID_TIPO_SERVICIO)
	VALUES (@id_recorrido, @cod_recorrido, @id_recorrido_ciudades, @p_id_tipo_servicio)

GO

CREATE PROCEDURE SASHAILO.sp_cliente_am
	@p_id_cliente INT,
	@p_nombre nvarchar(255),
	@p_apellido nvarchar(255),
	@p_dni numeric(18,0),
	@p_direccion nvarchar(255),
	@p_telefono numeric(18,0),
	@p_mail nvarchar(255),
	@p_f_nacimiento datetime,
	@p_sexo char(1),
	@p_id_cliente_gen int OUT,
	@hayErr int OUT,
    @errores varchar(200) OUT
AS
	SET @hayErr = 0
	SET @errores = ''

	IF(@p_id_cliente is null) BEGIN
		INSERT INTO SASHAILO.Cliente(NOMBRE, APELLIDO, DNI, DIRECCION, TELEFONO, MAIL, F_NACIMIENTO, SEXO)
		VALUES (@p_nombre, @p_apellido, @p_dni, @p_direccion, @p_telefono, @p_mail, @p_f_nacimiento, @p_sexo)
		SET @p_id_cliente_gen = SCOPE_IDENTITY()
	END
	ELSE BEGIN
		UPDATE SASHAILO.Cliente SET NOMBRE = @p_nombre,
									APELLIDO = @p_apellido,
									DNI = @p_dni,
									DIRECCION = @p_direccion,
									TELEFONO = @p_telefono,
									MAIL = @p_mail,
									F_NACIMIENTO = @p_f_nacimiento,
									SEXO = @p_sexo 
		WHERE ID_CLIENTE = @p_id_cliente
		SET @p_id_cliente_gen = @p_id_cliente
	END

GO

CREATE PROCEDURE SASHAILO.sp_modif_recorrido
	@p_id_recorrido numeric(18,0),
	@p_id_ciudad_origen INT,
	@p_id_ciudad_destino INT,
	@p_base_kg DECIMAL(10,2),
	@p_base_pasaje DECIMAL(10,2),
	@p_id_tipo_servicio INT,
	@hayErr int OUT,
    @errores varchar(200) OUT
AS
	SET @hayErr = 0
	SET @errores = ''
	
	DECLARE @existe_recorrido_ciudades int
	select @existe_recorrido_ciudades = (select COUNT(1) from SASHAILO.Recorrido_Ciudades rc where rc.ID_CIUDAD_ORIGEN = @p_id_ciudad_origen and rc.ID_CIUDAD_DESTINO = @p_id_ciudad_destino)
	DECLARE @id_recorrido_ciudades int
	IF @existe_recorrido_ciudades > 0 BEGIN
		select @id_recorrido_ciudades = (select ID_RECORRIDO_CIUDADES from SASHAILO.Recorrido_Ciudades rc where rc.ID_CIUDAD_ORIGEN = @p_id_ciudad_origen and rc.ID_CIUDAD_DESTINO = @p_id_ciudad_destino)
		update SASHAILO.Recorrido_Ciudades set PRECIO_BASE_KG = @p_base_kg, PRECIO_BASE_PASAJE = @p_base_pasaje WHERE ID_RECORRIDO_CIUDADES = @id_recorrido_ciudades
	END
	ELSE BEGIN
		insert into SASHAILO.Recorrido_Ciudades(ID_CIUDAD_ORIGEN, ID_CIUDAD_DESTINO, PRECIO_BASE_KG, PRECIO_BASE_PASAJE)
		values(@p_id_ciudad_origen, @p_id_ciudad_destino, @p_base_kg, @p_base_pasaje)
		SET @id_recorrido_ciudades = SCOPE_IDENTITY()
	END
	
	UPDATE SASHAILO.Recorrido SET ID_RECORRIDO_CIUDADES = @id_recorrido_ciudades, ID_TIPO_SERVICIO = @p_id_tipo_servicio
	WHERE ID_RECORRIDO = @p_id_recorrido

GO

CREATE VIEW SASHAILO.vwRandom
AS
SELECT RAND() as Rnd
GO 

CREATE FUNCTION SASHAILO.fnCustomPass 
(    
    @size AS INT, --Tamaño de la cadena aleatoria
    @op AS VARCHAR(2) --Opción para letras(ABC..), numeros(123...) o ambos.
)
RETURNS VARCHAR(62)
AS
BEGIN    

    DECLARE @chars AS VARCHAR(52),
            @numbers AS VARCHAR(10),
            @strChars AS VARCHAR(62),        
            @strPass AS VARCHAR(62),
            @index AS INT,
            @cont AS INT

    SET @strPass = ''
    SET @strChars = ''    
    SET @chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
    SET @numbers = '0123456789'

    SET @strChars = CASE @op WHEN 'C' THEN @chars --Letras
                        WHEN 'N' THEN @numbers --Números
                        WHEN 'CN' THEN @chars + @numbers --Ambos (Letras y Números)
                        ELSE '------'
                    END

    SET @cont = 0
    WHILE @cont < @size
    BEGIN
        SET @index = ceiling( ( SELECT rnd FROM SASHAILO.vwRandom ) * (len(@strChars)))--Uso de la vista para el Rand() y no generar error.
        SET @strPass = @strPass + substring(@strChars, @index, 1)
        SET @cont = @cont + 1
    END    
        
    RETURN @strPass

END
GO

CREATE FUNCTION SASHAILO.fnGetPatente()
RETURNS VARCHAR(7)
AS
BEGIN    

    DECLARE @letras  AS VARCHAR(3),
            @numbers AS VARCHAR(3)

    SET @letras = ( SELECT SASHAILO.fnCustomPass(3,'C'))
    SET @numbers = ( SELECT SASHAILO.fnCustomPass(3,'N'))
        
    RETURN @letras + '-' +  @numbers

END
GO

CREATE FUNCTION SASHAILO.puedeReemplazar(@p_id_micro int, @p_id_micro_reemplazado int)
RETURNS INT
AS
BEGIN    
	DECLARE @rtado INT
	SET @rtado = 1

	DECLARE @cant_kg int
	DECLARE @cant_kg_reemplazado int
	SET @cant_kg_reemplazado = (select CANT_KG from SASHAILO.Micro mi where mi.ID_MICRO = @p_id_micro_reemplazado)
	SET @cant_kg = (select CANT_KG from SASHAILO.Micro mi where mi.ID_MICRO = @p_id_micro)
	
	IF @cant_kg < @cant_kg_reemplazado BEGIN -- no lo puede reemplazar porque no tiene tantos kg
		SET @rtado = 0
		RETURN @rtado
	END
	
	DECLARE @id_ts int
	DECLARE @id_ts_reemplazado int
	SET @id_ts_reemplazado = (select mi.ID_TIPO_SERVICIO from SASHAILO.Micro mi where mi.ID_MICRO = @p_id_micro_reemplazado)
	SET @id_ts = (select mi.ID_TIPO_SERVICIO from SASHAILO.Micro mi where mi.ID_MICRO = @p_id_micro)
	
	IF @id_ts <> @id_ts_reemplazado BEGIN -- no lo puede reemplazar porque no brindan el mismo tipo de servicio
		SET @rtado = 0
		RETURN @rtado
	END
	
    DECLARE @nro_butaca int 
	DECLARE @id_tipo_butaca int
	DECLARE @nro_piso int
	DECLARE curr_butacas CURSOR FOR 
	select NRO_BUTACA, ID_TIPO_BUTACA, NRO_PISO from SASHAILO.Butaca bu where bu.ID_MICRO = @p_id_micro_reemplazado
	
	OPEN curr_butacas 
	FETCH curr_butacas INTO @nro_butaca, @id_tipo_butaca, @nro_piso
	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		
		DECLARE @existeButaca int
		SELECT @existeButaca = (select count(1) from SASHAILO.Butaca bu where bu.ID_MICRO=@p_id_micro and 
		                                                                      bu.NRO_BUTACA=@nro_butaca and 
		                                                                      bu.ID_TIPO_BUTACA=@id_tipo_butaca and 
		                                                                      bu.NRO_PISO=@nro_piso)
		IF @existeButaca = 0 BEGIN --la butaca no existe en el micro sustituto
			SET @rtado = 0         -- por lo tanto no puede reemplazar al otro
		END		
		
		FETCH curr_butacas INTO @nro_butaca, @id_tipo_butaca, @nro_piso
	END
	
	CLOSE curr_butacas
	DEALLOCATE curr_butacas	

	RETURN @rtado
	
END
GO

CREATE FUNCTION SASHAILO.F_GET_ESTADO_MICRO(@id_micro int)
 RETURNS int
 AS
 BEGIN
   declare @id_estado int
   select @id_estado = (select TOP 1 lem.ID_ESTADO from SASHAILO.Micro mi
						join SASHAILO.Log_Estado_Micro lem on lem.ID_MICRO = mi.ID_MICRO
						where mi.ID_MICRO = @id_micro
						order by lem.ID_LOG DESC)
   return @id_estado
 END
 GO

CREATE PROCEDURE SASHAILO.listado_micros
    	@p_id_marca int, 
    	@p_id_tipo_servicio int, 
    	@p_patente varchar(7)
AS

	SELECT mi.ID_MICRO, mi.PATENTE, ma.DESCRIPCION, mi.MODELO, ts.DESCRIPCION, 
		   CANT_BUTACAS, CANT_KG, 
		   CASE SASHAILO.F_GET_ESTADO_MICRO(mi.ID_MICRO) WHEN 2 THEN 'S' ELSE 'N' END FUERA_DE_SERVICIO, 
		   CASE SASHAILO.F_GET_ESTADO_MICRO(mi.ID_MICRO) WHEN 3 THEN 'S' ELSE 'N' END FIN_VIDA_UTIL
	FROM SASHAILO.Micro mi
	JOIN SASHAILO.Marca_Micro ma on ma.ID_MARCA=mi.ID_MARCA
	JOIN SASHAILO.Tipo_Servicio ts on ts.ID_TIPO_SERVICIO=mi.ID_TIPO_SERVICIO
	WHERE (@p_id_marca is null or mi.ID_MARCA = @p_id_marca)
	and (@p_id_tipo_servicio is null or mi.ID_TIPO_SERVICIO = @p_id_tipo_servicio)
	and (@p_patente is null or upper(mi.PATENTE) = upper(@p_patente))
	;
		
GO

CREATE PROCEDURE SASHAILO.get_micros_para_viaje
    	@p_id_tipo_servicio int, 
    	@p_id_marca int,
    	@p_f_salida datetime, 
    	@p_f_llegada_estimada datetime
AS

	SELECT mi.ID_MICRO, mi.PATENTE, ma.DESCRIPCION, mi.MODELO, ts.DESCRIPCION, 
		   mi.CANT_BUTACAS, mi.CANT_KG
	FROM SASHAILO.Micro mi
	JOIN SASHAILO.Marca_Micro ma on ma.ID_MARCA=mi.ID_MARCA
	JOIN SASHAILO.Tipo_Servicio ts on ts.ID_TIPO_SERVICIO=mi.ID_TIPO_SERVICIO
	WHERE 
	 SASHAILO.f_m_operativo_entre_fechas(mi.ID_MICRO, @p_f_salida, @p_f_llegada_estimada) = 1 AND
	(@p_id_tipo_servicio is null or mi.ID_TIPO_SERVICIO = @p_id_tipo_servicio) and
	(@p_id_marca is null or ma.ID_MARCA = @p_id_marca) and
	(SASHAILO.F_GET_ESTADO_MICRO(mi.ID_MICRO) = 1) and
	 NOT EXISTS (SELECT 1 from SASHAILO.Viaje vi
				 WHERE 
				 vi.CANCELADO = 'N' AND
				 vi.ID_MICRO = mi.ID_MICRO AND
				 (
				   (@p_f_salida >=  vi.F_SALIDA and @p_f_salida <=  vi.F_LLEGADA_ESTIMADA)
				    	OR
				   (@p_f_llegada_estimada >=  vi.F_SALIDA and @p_f_llegada_estimada <=  vi.F_LLEGADA_ESTIMADA)
				 )				
				 )
	 ;
		
GO

CREATE PROCEDURE SASHAILO.sp_alta_butaca_provisoria
	@p_id_viaje INT,
	@p_id_butaca INT,
	@p_id_cliente INT,
	@p_id_generado INT OUT
AS

	INSERT INTO SASHAILO.Pasaje_Encomienda_Temporal(ID_VIAJE, ID_BUTACA, ID_CLIENTE)
	VALUES (@p_id_viaje, @p_id_butaca, @p_id_cliente)
	SET @p_id_generado = SCOPE_IDENTITY()
	
GO

CREATE PROCEDURE SASHAILO.sp_alta_compra_pasaje
	@p_id_cliente INT,
	@p_id_compra INT,
	@p_id_viaje INT,
	@p_id_butaca INT,
	@p_precio NUMERIC(18,2),
	@p_discapacidad CHAR(1),
	@p_id_pasaje_gen NUMERIC(18,0) OUT,
	@hayErr int OUT,
    @errores varchar(200) OUT
AS
	SET @hayErr = 0
	SET @errores = ''
	
	BEGIN TRANSACTION
	
	SELECT @p_id_pasaje_gen = (MAX(ID_PASAJE) + 1) FROM SASHAILO.Pasaje

	INSERT INTO SASHAILO.Pasaje(ID_PASAJE, ID_COMPRA, ID_CLIENTE, ID_VIAJE, ID_BUTACA, PRECIO, DISCAPACIDAD)
	VALUES (@p_id_pasaje_gen, @p_id_compra, @p_id_cliente, @p_id_viaje, @p_id_butaca, @p_precio, @p_discapacidad)
	IF @@error != 0 BEGIN
		ROLLBACK TRANSACTION
		SET @hayErr = 1
		RETURN
	END
	
	DELETE FROM SASHAILO.Pasaje_Encomienda_Temporal WHERE ID_CLIENTE = @p_id_cliente AND ID_VIAJE = @p_id_viaje AND ID_BUTACA = @p_id_butaca
	
	COMMIT TRANSACTION
GO

CREATE PROCEDURE SASHAILO.sp_alta_compra_encomienda
	@p_id_cliente INT,
	@p_id_compra INT,
	@p_id_viaje INT,
	@p_precio NUMERIC(18,2),
	@p_kg NUMERIC(18,0),
	@p_id_provisorio INT,
	@p_id_encomienda_gen NUMERIC(18,0) OUT,
	@hayErr int OUT,
    @errores varchar(200) OUT
AS
	SET @hayErr = 0
	SET @errores = ''
	
	BEGIN TRANSACTION
	
	SELECT @p_id_encomienda_gen = (MAX(ID_ENCOMIENDA) + 1) FROM SASHAILO.Encomienda

	INSERT INTO SASHAILO.Encomienda(ID_ENCOMIENDA, ID_COMPRA, ID_CLIENTE, ID_VIAJE, KG, PRECIO)
	VALUES (@p_id_encomienda_gen, @p_id_compra, @p_id_cliente, @p_id_viaje, @p_kg, @p_precio)
	IF @@error != 0 BEGIN
		ROLLBACK TRANSACTION
		SET @hayErr = 1
		RETURN
	END
	
	DELETE FROM SASHAILO.Pasaje_Encomienda_Temporal WHERE ID_PE_TEMPORAL = @p_id_provisorio
	
	COMMIT TRANSACTION
GO


CREATE PROCEDURE SASHAILO.sp_alta_encomienda_provisoria
	@p_id_viaje INT,
	@p_id_cliente INT,
	@p_kilos NUMERIC(18,0),
	@p_id_generado INT OUT
AS

	INSERT INTO SASHAILO.Pasaje_Encomienda_Temporal(ID_VIAJE, KG, ID_CLIENTE)
	VALUES (@p_id_viaje, @p_kilos, @p_id_cliente)
	SET @p_id_generado = SCOPE_IDENTITY()
	
GO

CREATE PROCEDURE SASHAILO.sp_baja_butaca_encomienda_provisoria
	@p_id INT
AS

	DELETE FROM SASHAILO.Pasaje_Encomienda_Temporal WHERE ID_PE_TEMPORAL = @p_id
	
GO

CREATE PROCEDURE SASHAILO.alta_micro
    	@p_patente varchar(7),
    	@p_id_marca int, 
    	@p_modelo varchar(25),
    	@p_id_tipo_servicio int, 
    	@p_m_fuera_servicio char(1),
    	@p_cant_kg numeric(18,0), 
    	@p_cant_butacas int,
	@p_f_alta datetime,
    	@id_micro_generado int OUT,
    	@hayErr int OUT,
		@errores varchar(200) OUT
    	
AS
BEGIN
	SET @hayErr = 0
	SET @errores = ''
	
	BEGIN TRANSACTION	
	/*grabo el micro*/
	INSERT INTO SASHAILO.Micro (PATENTE, ID_MARCA, MODELO, ID_TIPO_SERVICIO, CANT_BUTACAS, CANT_KG, F_ALTA) 
	VALUES (@p_patente, @p_id_marca, @p_modelo, @p_id_tipo_servicio, @p_cant_butacas, @p_cant_kg, @p_f_alta)
	IF @@error != 0 BEGIN
		ROLLBACK TRANSACTION
	END
	ELSE BEGIN
		SET @id_micro_generado = SCOPE_IDENTITY()
	END
	
	DECLARE @id_estado int
	SET @id_estado = 1
	IF @p_m_fuera_servicio = 'S' BEGIN
		SET @id_estado = 2
	END

	INSERT INTO SASHAILO.Log_Estado_Micro (ID_MICRO, ID_ESTADO, FECHA) 
	VALUES (@id_micro_generado, @id_estado, @p_f_alta)

	
	COMMIT TRANSACTION  
END
GO

CREATE PROCEDURE SASHAILO.sp_alta_compra
	@p_id_cliente INT,
	@p_f_compra DATETIME,
	@p_importe NUMERIC(18,2),
	@p_id_medio_pago INT,
	@p_nro_tarjeta NVARCHAR(16),
	@p_id_compra_gen int OUT,
	@hayErr int OUT,
    @errores varchar(200) OUT
AS
	SET @hayErr = 0
	SET @errores = ''
	
	BEGIN TRANSACTION
	
	DECLARE @id_tarjeta INT
	IF @p_id_medio_pago = 1 BEGIN
		SET @id_tarjeta = NULL;
	END
	ELSE BEGIN
		SELECT @id_tarjeta = ID_TARJETA FROM SASHAILO.Tarjeta_Credito WHERE NRO_TARJETA = @p_nro_tarjeta
	END
	
	SELECT @p_id_compra_gen = (MAX(ID_COMPRA) + 1) FROM SASHAILO.Compra

	INSERT INTO SASHAILO.Compra(ID_COMPRA, F_COMPRA, IMPORTE, ID_CLIENTE, ID_MEDIO_PAGO, ID_TARJETA)
	VALUES (@p_id_compra_gen, @p_f_compra, @p_importe, @p_id_cliente, @p_id_medio_pago, @id_tarjeta)
	IF @@error != 0 BEGIN
		ROLLBACK TRANSACTION
		SET @hayErr = 1
		RETURN
	END
	COMMIT TRANSACTION
GO

CREATE PROCEDURE SASHAILO.modif_micro
    	@p_id_micro int,
    	@p_patente varchar(7),
    	@p_id_marca int, 
    	@p_modelo varchar(25),
    	@p_id_tipo_servicio int, 
    	@p_m_fuera_servicio char(1),
    	@p_fecha datetime,
    	@p_f_fuera_servicio datetime,
    	@p_f_reinicio_servicio datetime,
    	@p_m_baja_definitiva char(1),
    	@p_f_baja_definitiva datetime,
    	@p_cant_kg numeric(18,0), 
    	@hayErr int OUT,
		@errores varchar(200) OUT
    	
AS
BEGIN
	SET @hayErr = 0
	SET @errores = ''
	
	/*verifico que la patente no pertenezca a otro micro*/
	DECLARE @existePatente int 
	select @existePatente = (select COUNT(1) from SASHAILO.Micro where upper(PATENTE)=upper(@p_patente) and ID_MICRO <> @p_id_micro)
	if @existePatente > 0
	BEGIN
		set @hayErr = 1
		set @errores = 'La patente ingresada pertenece a otro micro.'
		RETURN
	END
	
	BEGIN TRANSACTION	
	/*actualizo el micro*/
	UPDATE SASHAILO.Micro SET PATENTE = @p_patente, 
	                          ID_MARCA = @p_id_marca, 
	                          MODELO = @p_modelo, 
	                          ID_TIPO_SERVICIO = @p_id_tipo_servicio, 
	                          --FUERA_DE_SERVICIO = @p_m_fuera_servicio,
	                          --F_FUERA_SERVICIO = @p_f_fuera_servicio,
	                          --F_REINICIO_SERVICIO = @p_f_reinicio_servicio,
	                         -- FIN_VIDA_UTIL = @p_m_baja_definitiva,
	                         -- F_FIN_VIDA_UTIL = @p_f_baja_definitiva,
	                          CANT_KG = @p_cant_kg
	WHERE ID_MICRO = @p_id_micro
	
	IF @p_m_baja_definitiva = 'N' and @p_m_fuera_servicio = 'N' BEGIN
		insert into SASHAILO.Log_Estado_Micro(ID_MICRO, ID_ESTADO, FECHA)
		values(@p_id_micro, 1, @p_fecha);
		COMMIT TRANSACTION
		RETURN
	END
	
	DECLARE @id_estado_update int
	DECLARE @id_estado_actual int
	SELECT @id_estado_actual = (SELECT SASHAILO.F_GET_ESTADO_MICRO(@p_id_micro))
	
	IF @p_m_fuera_servicio = 'S' BEGIN
		IF @p_f_fuera_servicio = @p_fecha BEGIN
			SET @id_estado_update = 2
		END
		IF @p_f_fuera_servicio > @p_fecha BEGIN
			SET @id_estado_update = 1
		END
		insert into SASHAILO.Log_Estado_Micro(ID_MICRO, ID_ESTADO, FECHA, FECHA_F_SERVICIO, FECHA_REINICIO, FECHA_BAJA_DEF)
		values(@p_id_micro, @id_estado_update, @p_fecha, @p_f_fuera_servicio, @p_f_reinicio_servicio, @p_f_baja_definitiva);
	END
	IF @p_m_baja_definitiva = 'S' BEGIN
		IF @p_f_baja_definitiva = @p_fecha BEGIN
			SET @id_estado_update = 3
		END
		IF @p_f_baja_definitiva > @p_fecha BEGIN
			SET @id_estado_update = 1
		END
		insert into SASHAILO.Log_Estado_Micro(ID_MICRO, ID_ESTADO, FECHA, FECHA_F_SERVICIO, FECHA_REINICIO, FECHA_BAJA_DEF)
		values(@p_id_micro, @id_estado_update, @p_fecha, @p_f_fuera_servicio, @p_f_reinicio_servicio, @p_f_baja_definitiva);
	END	
	
	IF @@error != 0
		ROLLBACK TRANSACTION
	
	COMMIT TRANSACTION 
	 
END
GO

CREATE PROCEDURE SASHAILO.evalua_mic_f_de_servicio
    	@p_id_micro int,
    	@p_f_desde datetime,
    	@p_f_hasta datetime,
    	@todosSeReemplazan int OUT,
    	@cantViajes int OUT,
    	@cantViajesSinMicro int OUT
    	
AS
BEGIN
	SET @todosSeReemplazan = 1
	SET @cantViajesSinMicro = 0
	
	select @cantViajes = (select COUNT(1) from SASHAILO.Viaje vi where vi.ID_MICRO = @p_id_micro
																 and vi.CANCELADO = 'N'
																 and (vi.F_SALIDA BETWEEN @p_f_desde and @p_f_hasta)
																 and (vi.F_LLEGADA_ESTIMADA BETWEEN @p_f_desde and @p_f_hasta))
	
	--no tiene viajes programados, puede salir de servicio sin ningun problema
	if @cantViajes = 0
	BEGIN
		RETURN
	END

	DECLARE @id_viaje int 
	DECLARE @f_salida datetime
	DECLARE @f_llegada_estim datetime
	
	DECLARE curr_viajes CURSOR FOR 
	select vi.ID_VIAJE, vi.F_SALIDA, vi.F_LLEGADA_ESTIMADA 
	from SASHAILO.Viaje vi where vi.ID_MICRO = @p_id_micro
	and vi.CANCELADO = 'N'
	and (vi.F_SALIDA BETWEEN @p_f_desde and @p_f_hasta)
	and (vi.F_LLEGADA_ESTIMADA BETWEEN @p_f_desde and @p_f_hasta)
	
	OPEN curr_viajes 
	FETCH curr_viajes INTO @id_viaje, @f_salida, @f_llegada_estim
	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		
		DECLARE @cantReemplazantes int
		SELECT @cantReemplazantes = (SELECT COUNT(1) from SASHAILO.Micro mi
		                             WHERE mi.ID_MICRO not IN (select distinct vi.ID_MICRO from SASHAILO.Viaje vi where (vi.F_SALIDA between @f_salida and @f_llegada_estim) and (vi.F_LLEGADA_ESTIMADA between @f_salida and @f_llegada_estim))
		                             AND SASHAILO.puedeReemplazar(mi.ID_MICRO, @p_id_micro) = 1
		                             AND SASHAILO.f_m_operativo_entre_fechas(mi.ID_MICRO, @f_salida, @f_llegada_estim) = 1
		                             )
		
		IF @cantReemplazantes = 0 begin
			SET @todosSeReemplazan = 0
			SET @cantViajesSinMicro = @cantViajesSinMicro + 1
		end
		
		
		FETCH curr_viajes INTO @id_viaje, @f_salida, @f_llegada_estim
	END
	
	CLOSE curr_viajes
	DEALLOCATE curr_viajes	

END
GO

CREATE PROCEDURE SASHAILO.mic_fs_reemplazar_cancelar
    	@p_id_micro int,
    	@p_f_actual datetime,
    	@p_f_desde datetime,
    	@p_f_hasta datetime,
    	@viajesCancelados int OUT,
    	@pasajesCancelados int OUT,
    	@encoCanceladas int OUT
    	
AS
BEGIN
	SET @viajesCancelados = 0
	SET @pasajesCancelados = 0
	SET @encoCanceladas = 0
	
	DECLARE @cantViajes int
	select @cantViajes = (select COUNT(1) from SASHAILO.Viaje vi where vi.ID_MICRO = @p_id_micro
																 and vi.CANCELADO = 'N'
																 and (vi.F_SALIDA BETWEEN @p_f_desde and @p_f_hasta)
																 and (vi.F_LLEGADA_ESTIMADA BETWEEN @p_f_desde and @p_f_hasta))
	
	--no tiene viajes programados, puede salir de servicio sin ningun problema
	if @cantViajes = 0
	BEGIN
		RETURN
	END

	DECLARE @id_viaje int 
	DECLARE @f_salida datetime
	DECLARE @f_llegada_estim datetime
	
	DECLARE curr_viajes CURSOR FOR 
	select vi.ID_VIAJE, vi.F_SALIDA, vi.F_LLEGADA_ESTIMADA 
	from SASHAILO.Viaje vi where vi.ID_MICRO = @p_id_micro
	and vi.CANCELADO = 'N'
	and (vi.F_SALIDA BETWEEN @p_f_desde and @p_f_hasta)
	and (vi.F_LLEGADA_ESTIMADA BETWEEN @p_f_desde and @p_f_hasta)
	
	BEGIN TRANSACTION
	
	OPEN curr_viajes 
	FETCH curr_viajes INTO @id_viaje, @f_salida, @f_llegada_estim
	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		
		DECLARE @cantReemplazantes int
		SELECT @cantReemplazantes = (SELECT COUNT(1) from SASHAILO.Micro mi
		                             WHERE mi.ID_MICRO not IN (select distinct vi.ID_MICRO from SASHAILO.Viaje vi where (vi.F_SALIDA between @f_salida and @f_llegada_estim) and (vi.F_LLEGADA_ESTIMADA between @f_salida and @f_llegada_estim))
		                             AND SASHAILO.puedeReemplazar(mi.ID_MICRO, @p_id_micro) = 1
		                             AND SASHAILO.f_m_operativo_entre_fechas(mi.ID_MICRO, @f_salida, @f_llegada_estim) = 1
		                             )
		--cancelo el viaje y los pasajes/encomiendas
		IF @cantReemplazantes = 0 BEGIN
			
			
			SET @viajesCancelados = @viajesCancelados + 1
			DECLARE @cantPasajes int
			DECLARE @cantEnco int
			SET @cantPasajes = (select COUNT(1) from SASHAILO.Pasaje pa where pa.ID_VIAJE = @id_viaje)
			SET @cantEnco = (select COUNT(1) from SASHAILO.Encomienda en where en.ID_VIAJE = @id_viaje)
			SET @pasajesCancelados = @pasajesCancelados + @cantPasajes
			SET @encoCanceladas = @encoCanceladas + @cantEnco
			
			--cancelo pasajes
			INSERT INTO SASHAILO.Devolucion(ID_PASAJE, F_DEVOLUCION, MOTIVO)
			SELECT ID_PASAJE, @p_f_actual, 'Viaje Cancelado' FROM SASHAILO.Pasaje where ID_VIAJE = @id_viaje
			
			--cancelo encomiendas
			INSERT INTO SASHAILO.Devolucion(ID_ENCOMIENDA, F_DEVOLUCION, MOTIVO)
			SELECT ID_ENCOMIENDA, @p_f_actual, 'Viaje Cancelado' FROM SASHAILO.Encomienda where ID_VIAJE = @id_viaje
			
			--marco el viaje como cancelado
			UPDATE SASHAILO.Viaje SET CANCELADO = 'S' WHERE ID_VIAJE = @id_viaje
			
		END
		ELSE BEGIN
			DECLARE @id_micro_reemplazante int
			SELECT @id_micro_reemplazante = (SELECT TOP 1 mi.ID_MICRO from SASHAILO.Micro mi
		                                     WHERE mi.ID_MICRO not IN (select distinct vi.ID_MICRO from SASHAILO.Viaje vi 
		                                                               where  vi.CANCELADO = 'N' and
		                                                                     (vi.F_SALIDA between @f_salida and @f_llegada_estim) and 
		                                                                     (vi.F_LLEGADA_ESTIMADA between @f_salida and @f_llegada_estim))
		                                     AND SASHAILO.puedeReemplazar(mi.ID_MICRO, @p_id_micro) = 1
		                                     AND SASHAILO.f_m_operativo_entre_fechas(mi.ID_MICRO, @f_salida, @f_llegada_estim) = 1
		                                     )
			--le cambio el micro al viaje
			UPDATE SASHAILO.Viaje SET ID_MICRO = @id_micro_reemplazante WHERE ID_VIAJE = @id_viaje
			
			--cambio el id de las butacas de los pasajes por los id_butaca analogas en el micro nuevo
			DECLARE @id_pasaje int 
			DECLARE @id_butaca int 
			DECLARE curr_butacas CURSOR FOR 
			select ID_PASAJE, ID_BUTACA from SASHAILO.Pasaje where ID_VIAJE = @id_viaje
			
			OPEN curr_butacas 
			FETCH curr_butacas INTO @id_pasaje, @id_butaca
			
			WHILE (@@FETCH_STATUS = 0)
			BEGIN
				
				DECLARE @nro_butaca int 
				DECLARE @id_tipo_butaca int
				DECLARE @nro_piso int
				DECLARE @id_butaca_reemplazante int
				
				SELECT @nro_butaca = bu.NRO_BUTACA, @id_tipo_butaca = bu.ID_TIPO_BUTACA, @nro_piso = bu.NRO_PISO FROM SASHAILO.Butaca bu WHERE bu.ID_BUTACA = @id_butaca
				SELECT @id_butaca_reemplazante = bu.ID_BUTACA FROM SASHAILO.Butaca bu WHERE bu.NRO_BUTACA = @nro_butaca AND
				                                                                            bu.ID_TIPO_BUTACA = @id_tipo_butaca AND
				                                                                            bu.NRO_PISO = @nro_piso AND
				                                                                            bu.ID_MICRO = @id_micro_reemplazante
				
				--actualizo el id_butaca con la reemplazante
				UPDATE SASHAILO.Pasaje SET ID_BUTACA = @id_butaca_reemplazante WHERE ID_PASAJE = @id_pasaje	                                                                            
				
				
				FETCH curr_butacas INTO @id_pasaje, @id_butaca
			END
			
			CLOSE curr_butacas
			DEALLOCATE curr_butacas				
					                                     
		END
		
		FETCH curr_viajes INTO @id_viaje, @f_salida, @f_llegada_estim
	END
	
	CLOSE curr_viajes
	DEALLOCATE curr_viajes	
	
	COMMIT TRANSACTION

END
GO

CREATE PROCEDURE SASHAILO.sp_devolver_compra
    	@p_id_compra int,
		@p_id_pasaje numeric(18,0),
    	@p_id_encomienda numeric(18,0),
    	@p_f_devolucion datetime,
    	@p_motivo nvarchar(255),
    	@hayErr int OUT,
    	@errores varchar(200) OUT
AS
	
BEGIN

	SET @hayErr = 0
	SET @errores = ''

	/*verifico que exista la compra*/
	DECLARE @existeCompra int 
	select @existeCompra = (select COUNT(1) from SASHAILO.Compra where ID_COMPRA = @p_id_compra)
	if @existeCompra = 0
	BEGIN
		set @hayErr = 1
		set @errores = 'El Código de Compra ingresado no existe.'
		RETURN
	END
	
	/*verifico que la compra no sea antigua*/
	DECLARE @compraAntigua int 
	select @compraAntigua = (select top 1 co.ID_COMPRA from SASHAILO.Compra co 
	                        join SASHAILO.Pasaje pa on pa.ID_COMPRA = co.ID_COMPRA
	                        join SASHAILO.Viaje vi on vi.ID_VIAJE = pa.ID_VIAJE
	                        where co.ID_COMPRA = @p_id_compra and 
	                        vi.F_SALIDA <= @p_f_devolucion
	                        )
	if @compraAntigua is null BEGIN
	select @compraAntigua = (select top 1 co.ID_COMPRA from SASHAILO.Compra co 
	                        join SASHAILO.Encomienda en on en.ID_COMPRA = co.ID_COMPRA
	                        join SASHAILO.Viaje vi on vi.ID_VIAJE = en.ID_VIAJE
	                        where co.ID_COMPRA = @p_id_compra and 
	                        vi.F_SALIDA <= @p_f_devolucion
	                        )	
	END	                        
	if @compraAntigua is not null
	BEGIN
		set @hayErr = 1
		set @errores = 'La Compra que intenta cancelar ya se hizo efectiva. Es un viaje pasado.'
		RETURN
	END
	
	/*verifico que exista el pasaje*/
	DECLARE @existePasaje int 
	select @existePasaje = (select COUNT(1)
						  from SASHAILO.Pasaje pa join SASHAILO.Compra co on co.ID_COMPRA = pa.ID_COMPRA
						  where pa.ID_PASAJE = @p_id_pasaje and co.ID_COMPRA = @p_id_compra)
	
	IF @p_id_pasaje is not null and @existePasaje = 0 BEGIN 
		set @hayErr = 1
		set @errores = 'El Código de Pasaje ingresado no existe'
		RETURN
	END	
	
	/*verifico que exista la encomienda*/
	DECLARE @existeEnco int 
	select @existeEnco = (select COUNT(1)
						  from SASHAILO.Encomienda en join SASHAILO.Compra co on co.ID_COMPRA = en.ID_COMPRA
						  where en.ID_ENCOMIENDA = @p_id_encomienda and co.ID_COMPRA = @p_id_compra)
	
	IF @p_id_encomienda is not null and @existeEnco = 0 BEGIN 
		set @hayErr = 1
		set @errores = 'El Código de Encomienda ingresado no existe'
		RETURN
	END
	
	/*verifico si el pasaje ya fue devuelto*/
	DECLARE @pasajeDevuelto int 
	select @pasajeDevuelto = (select COUNT(1) from SASHAILO.Devolucion de where de.ID_PASAJE = @p_id_pasaje)
	
	IF @p_id_pasaje is not null and @pasajeDevuelto > 0 BEGIN 
		set @hayErr = 1
		set @errores = 'El Pasaje ingresado ya ha sido devuelto'
		RETURN
	END
	
	/*verifico si el pasaje ya fue devuelto*/
	DECLARE @encoDevuelta int 
	select @encoDevuelta = (select COUNT(1) from SASHAILO.Devolucion de where de.ID_ENCOMIENDA = @p_id_encomienda)
	
	IF @p_id_encomienda is not null and @encoDevuelta > 0 BEGIN 
		set @hayErr = 1
		set @errores = 'La Encomienda ingresada ya ha sido devuelta'
		RETURN
	END	
	
	/*elimino pasaje*/
	IF @p_id_pasaje is not null BEGIN 
		BEGIN TRANSACTION
		INSERT INTO SASHAILO.Devolucion(ID_PASAJE, F_DEVOLUCION, MOTIVO)
		VALUES(@p_id_pasaje, @p_f_devolucion, @p_motivo)
		COMMIT TRANSACTION
		RETURN
	END
	
	/*elimino encomienda*/
	IF @p_id_encomienda is not null BEGIN 
		BEGIN TRANSACTION
		INSERT INTO SASHAILO.Devolucion(ID_ENCOMIENDA, F_DEVOLUCION, MOTIVO)
		VALUES(@p_id_encomienda, @p_f_devolucion, @p_motivo)
		COMMIT TRANSACTION
		RETURN
	END
		
	-- elimino la compra completa
	DECLARE @eliminaAlgo int
	set @eliminaAlgo = 0
	BEGIN TRANSACTION
	
	DECLARE @id_pasaje numeric(18,0) 
	DECLARE @id_encomienda numeric(18,0)
	
	DECLARE curr_pasajes CURSOR FOR 
	select ID_PASAJE from SASHAILO.Pasaje 
	where ID_COMPRA = @p_id_compra and ID_PASAJE not in (select distinct id_pasaje from SASHAILO.Devolucion where id_pasaje is not null)
	OPEN curr_pasajes 
	FETCH curr_pasajes INTO @id_pasaje	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		set @eliminaAlgo = 1
		INSERT INTO SASHAILO.Devolucion(ID_PASAJE, F_DEVOLUCION, MOTIVO)
		VALUES(@id_pasaje, @p_f_devolucion, @p_motivo)                                                                          
		
		FETCH curr_pasajes INTO @id_pasaje
	END
	CLOSE curr_pasajes
	DEALLOCATE curr_pasajes	
	
	DECLARE curr_encomiendas CURSOR FOR 
	select ID_ENCOMIENDA from SASHAILO.Encomienda
	where ID_COMPRA = @p_id_compra and ID_ENCOMIENDA not in (select distinct id_encomienda from SASHAILO.Devolucion where id_encomienda is not null)
	OPEN curr_encomiendas 
	FETCH curr_encomiendas INTO @id_encomienda	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		set @eliminaAlgo = 1
		INSERT INTO SASHAILO.Devolucion(ID_ENCOMIENDA, F_DEVOLUCION, MOTIVO)
		VALUES(@id_encomienda, @p_f_devolucion, @p_motivo)                                                                          
		
		FETCH curr_encomiendas INTO @id_encomienda
	END
	CLOSE curr_encomiendas
	DEALLOCATE curr_encomiendas				
	
	COMMIT TRANSACTION
	
	if @eliminaAlgo = 0 begin
		set @hayErr = 1
		set @errores = 'La Compra no tiene nada por cancelar'
	end
	
END

GO

CREATE PROCEDURE SASHAILO.fin_vida_util_micro
    	@p_id_micro int,
    	@p_m_baja_definitiva char(1),
    	@p_f_baja_definitiva datetime,
    	@p_fecha datetime,
    	@hayErr int OUT,
		@errores varchar(200) OUT
    	
AS
BEGIN
	SET @hayErr = 0
	SET @errores = ''
	
	DECLARE @id_estado int
	IF @p_m_baja_definitiva = 'S' BEGIN
		SET @id_estado = 3
	END
	ELSE BEGIN
		SET @id_estado = 1
	END
	
	BEGIN TRANSACTION	
		/*actualizo el micro*/
		INSERT INTO SASHAILO.Log_Estado_Micro(ID_MICRO, ID_ESTADO, FECHA, FECHA_BAJA_DEF)
		VALUES(@p_id_micro, @id_estado, @p_fecha, @p_f_baja_definitiva)
	
	IF @@error != 0
		ROLLBACK TRANSACTION
	
	COMMIT TRANSACTION  
END
GO

CREATE PROCEDURE SASHAILO.sp_alta_viaje
	@p_id_recorrido numeric(18,0),
	@p_id_micro INT,
	@p_f_salida datetime,
	@p_f_llegada_estim datetime,
	@p_f_llegada datetime,
	@hayErr int OUT,
    @errores varchar(200) OUT
AS
	SET @hayErr = 0
	SET @errores = ''
	
	BEGIN TRANSACTION
	INSERT INTO SASHAILO.Viaje(ID_RECORRIDO, ID_MICRO, F_SALIDA, F_LLEGADA_ESTIMADA, F_LLEGADA)
	VALUES (@p_id_recorrido, @p_id_micro, @p_f_salida, @p_f_llegada_estim, @p_f_llegada)
	
	IF @@error != 0 BEGIN
		ROLLBACK TRANSACTION
		SET @hayErr = 1
		SET @errores = 'Errores al insertar el Viaje'
	END
	
	COMMIT TRANSACTION
	
GO

CREATE PROCEDURE SASHAILO.listado_viajes
    	@p_id_ciudad_origen int, 
    	@p_id_ciudad_destino int
AS

	select cio.NOMBRE_CIUDAD ORIGEN, cid.NOMBRE_CIUDAD DESTINO, mi.PATENTE, mi.CANT_BUTACAS, mi.CANT_KG,
	ts.DESCRIPCION, vi.F_SALIDA, vi.F_LLEGADA_ESTIMADA, vi.F_LLEGADA 
	from SASHAILO.Viaje vi
	join SASHAILO.Recorrido re on vi.ID_RECORRIDO = re.ID_RECORRIDO
	join SASHAILO.Recorrido_Ciudades rc on rc.ID_RECORRIDO_CIUDADES = re.ID_RECORRIDO_CIUDADES
	join SASHAILO.Micro mi on mi.ID_MICRO = vi.ID_MICRO
	join SASHAILO.Ciudad cio on cio.ID_CIUDAD = rc.ID_CIUDAD_ORIGEN
	join SASHAILO.Ciudad cid on cid.ID_CIUDAD = rc.ID_CIUDAD_DESTINO
	join SASHAILO.Tipo_Servicio ts on ts.ID_TIPO_SERVICIO = mi.ID_TIPO_SERVICIO
	WHERE 
	(@p_id_ciudad_origen is null or rc.ID_CIUDAD_ORIGEN = @p_id_ciudad_origen) and 
	(@p_id_ciudad_destino is null or rc.ID_CIUDAD_DESTINO = @p_id_ciudad_destino)
	;
		
GO

CREATE FUNCTION SASHAILO.F_CANT_BUTACAS_MICRO(@id_micro int)
 RETURNS int
 AS
 BEGIN
   declare @cant_butacas int
   select @cant_butacas = (select mi.CANT_BUTACAS from SASHAILO.Micro mi where mi.ID_MICRO = @id_micro)
   return @cant_butacas
 END
 GO

CREATE FUNCTION SASHAILO.F_CANT_BUTACAS_DISP(@id_viaje int)
 RETURNS int
 AS
 BEGIN
   declare @id_micro int
   declare @cant_butacas_micro int
   declare @cant_butacas_vendidas int
   select @id_micro = (SELECT vi.ID_MICRO FROM SASHAILO.Viaje vi where vi.ID_VIAJE = @id_viaje)
   select @cant_butacas_micro = (select mi.CANT_BUTACAS from SASHAILO.Micro mi where mi.ID_MICRO = @id_micro)
   select @cant_butacas_vendidas = (select COUNT(1) from SASHAILO.Pasaje pa where pa.ID_VIAJE = @id_viaje and 
                                                                                  pa.ID_PASAJE not in (select distinct ID_PASAJE
                                                                                                       from SASHAILO.Devolucion
                                                                                                       where ID_PASAJE is not null))
   
   return (@cant_butacas_micro - @cant_butacas_vendidas)
   
 END
 GO

CREATE FUNCTION SASHAILO.f_m_operativo_entre_fechas(@id_micro int,
                                                @f_desde datetime,
                                                @f_hasta datetime)
RETURNS int
AS
BEGIN

	declare @f_f_servicio datetime
	declare @f_r_servicio datetime
	declare @f_b_definitiva datetime

	select top 1 @f_f_servicio = FECHA_F_SERVICIO, @f_r_servicio = FECHA_REINICIO, @f_b_definitiva = FECHA_BAJA_DEF 
	from SASHAILO.Log_Estado_Micro l where l.ID_MICRO = @id_micro
	order by l.ID_LOG desc

	--el micro no tiene programadas fechas de baja, estará operativo
	if @f_f_servicio is null and @f_b_definitiva is null begin
		return 1
	end
	
	--el micro sera dado de baja entre las fechas en cuestion
	if @f_b_definitiva is not null and @f_b_definitiva <= @f_hasta begin
		return 0
	end
	
	--el micro saldra de servicio entre las fechas en cuestion
	if @f_f_servicio between @f_desde and @f_hasta begin
		return 0
	end
	
	--el micro retomará de servicio entre las fechas en cuestion
	if @f_r_servicio > @f_desde and @f_r_servicio < @f_hasta begin
		return 0
	end
	
	--el micro estaria fuera de servicio al momento de salir
	if @f_desde >= @f_f_servicio and @f_desde < @f_r_servicio begin
		return 0
	end
	
	--el micro estaria fuera de servicio el dia de arribo
	if @f_hasta >= @f_f_servicio and @f_hasta < @f_r_servicio begin
		return 0
	end
      
    return 1
    
END
GO

CREATE FUNCTION SASHAILO.F_CANT_KG_DISP(@id_viaje int)
 RETURNS numeric(18,0)
 AS
 BEGIN
   declare @id_micro int
   declare @cant_kg_micro numeric(18,0)
   declare @cant_kg_vendidos numeric(18,0)
   select @id_micro = (SELECT vi.ID_MICRO FROM SASHAILO.Viaje vi where vi.ID_VIAJE = @id_viaje)
   select @cant_kg_micro = (select mi.CANT_KG from SASHAILO.Micro mi where mi.ID_MICRO = @id_micro)
   select @cant_kg_vendidos = (select ISNULL(SUM(en.KG),0) from SASHAILO.Encomienda en 
                               where en.ID_VIAJE = @id_viaje and 
                               en.ID_ENCOMIENDA not in (select distinct ID_ENCOMIENDA
														from SASHAILO.Devolucion
														where ID_ENCOMIENDA is not null))
   
   return (@cant_kg_micro - @cant_kg_vendidos)
   
 END
 GO

 CREATE FUNCTION SASHAILO.F_CANT_KG_MICRO(@id_micro int)
 RETURNS numeric(18,0)
 AS
 BEGIN
   declare @cant_kg numeric(18,0)
   select @cant_kg = (select mi.CANT_KG from SASHAILO.Micro mi where mi.ID_MICRO = @id_micro)
   return @cant_kg
 END
 GO

CREATE PROCEDURE SASHAILO.get_viajes_disponibles
    	@p_f_salida datetime,
    	@p_id_ciudad_origen int,
    	@p_id_ciudad_destino int
AS

	SELECT TOP 25 vi.ID_VIAJE, mi.PATENTE, ts.DESCRIPCION, vi.F_SALIDA, vi.F_LLEGADA_ESTIMADA,
	       SASHAILO.F_CANT_BUTACAS_MICRO(mi.ID_MICRO) BUTACAS_MICRO, 
	       SASHAILO.F_CANT_BUTACAS_DISP(vi.ID_VIAJE) BUTACAS_DISP,
	       SASHAILO.F_CANT_KG_MICRO(mi.ID_MICRO) KG_MICRO,
	       SASHAILO.F_CANT_KG_DISP(vi.ID_VIAJE) KG_DISP
	FROM SASHAILO.Viaje vi
	JOIN SASHAILO.Micro mi on mi.ID_MICRO = vi.ID_MICRO
	JOIN SASHAILO.Recorrido re on re.ID_RECORRIDO = vi.ID_RECORRIDO
	JOIN SASHAILO.Recorrido_Ciudades rc on rc.ID_RECORRIDO_CIUDADES = re.ID_RECORRIDO_CIUDADES
	JOIN SASHAILO.Tipo_Servicio ts on ts.ID_TIPO_SERVICIO = re.ID_TIPO_SERVICIO
	WHERE
	vi.CANCELADO = 'N' AND
	vi.F_SALIDA >= @p_f_salida AND
	YEAR(vi.F_SALIDA) = YEAR(@p_f_salida) AND
	MONTH(vi.F_SALIDA) = MONTH(@p_f_salida) AND
	DAY(vi.F_SALIDA) = DAY(@p_f_salida) AND
	rc.ID_CIUDAD_ORIGEN = @p_id_ciudad_origen AND
	rc.ID_CIUDAD_DESTINO = @p_id_ciudad_destino AND
        (SASHAILO.F_GET_ESTADO_MICRO(mi.ID_MICRO) = 1) AND
    (SASHAILO.F_CANT_KG_DISP(vi.ID_VIAJE) > 0 or SASHAILO.F_CANT_BUTACAS_DISP(vi.ID_VIAJE) > 0)
	ORDER BY BUTACAS_DISP DESC
	;
		
GO

CREATE PROCEDURE SASHAILO.get_butacas_disponibles
    	@p_id_viaje int,
    	@p_id_micro int
AS

	SELECT bu.ID_BUTACA, bu.NRO_BUTACA, bu.ID_TIPO_BUTACA, tb.DESCRIPCION, bu.NRO_PISO, mi.PATENTE
	FROM SASHAILO.Micro mi
	JOIN SASHAILO.Butaca bu on bu.ID_MICRO = mi.ID_MICRO
	JOIN SASHAILO.Tipo_Butaca tb on tb.ID_TIPO_BUTACA = bu.ID_TIPO_BUTACA
	WHERE mi.ID_MICRO = @p_id_micro
	AND bu.ID_BUTACA not in (SELECT pa.ID_BUTACA
							 FROM SASHAILO.Pasaje pa
							 WHERE pa.ID_VIAJE = @p_id_viaje and 
							 pa.ID_PASAJE not in (select ID_PASAJE from SASHAILO.Devolucion where ID_PASAJE is not null))
	AND bu.ID_BUTACA not in (SELECT pet.ID_BUTACA
							 FROM SASHAILO.Pasaje_Encomienda_Temporal pet
							 WHERE pet.ID_VIAJE = @p_id_viaje AND pet.ID_BUTACA is not null)	
	;
		
GO


CREATE PROCEDURE SASHAILO.top_destinos_mas_pasajes
    	@p_f_desde datetime,
    	@p_f_hasta datetime
AS

	select top 5 rc.ID_CIUDAD_DESTINO, ci.NOMBRE_CIUDAD, COUNT(1) CANT_PASAJES
	from SASHAILO.Pasaje pa
	join SASHAILO.Viaje vi on vi.ID_VIAJE = pa.ID_VIAJE
	join SASHAILO.Recorrido re on re.ID_RECORRIDO = vi.ID_RECORRIDO
	join SASHAILO.Recorrido_Ciudades rc on rc.ID_RECORRIDO_CIUDADES = re.ID_RECORRIDO_CIUDADES
	join SASHAILO.Ciudad ci on ci.ID_CIUDAD = rc.ID_CIUDAD_DESTINO
	join SASHAILO.Compra co on co.ID_COMPRA = pa.ID_COMPRA
	where co.F_COMPRA >= @p_f_desde and co.F_COMPRA <= @p_f_hasta
	     and pa.ID_PASAJE not in (select de.ID_PASAJE from SASHAILO.Devolucion de where de.ID_PASAJE is not null)
	group by rc.ID_CIUDAD_DESTINO, ci.NOMBRE_CIUDAD 
	order by cant_pasajes desc
	;
		
GO

CREATE PROCEDURE SASHAILO.top_destinos_micros_vacios
    	@p_f_desde datetime,
    	@p_f_hasta datetime
AS

	select top 5 rc.ID_CIUDAD_DESTINO, ci.NOMBRE_CIUDAD, COUNT(1) CANT_MICROS_VACIOS
	from SASHAILO.Viaje vi
	join SASHAILO.Recorrido re on re.ID_RECORRIDO = vi.ID_RECORRIDO
	join SASHAILO.Recorrido_Ciudades rc on rc.ID_RECORRIDO_CIUDADES = re.ID_RECORRIDO_CIUDADES
	join SASHAILO.Ciudad ci on ci.ID_CIUDAD = rc.ID_CIUDAD_DESTINO
	where not exists (select 1 from SASHAILO.Pasaje pa where pa.ID_VIAJE = vi.ID_VIAJE)
	      and vi.F_LLEGADA >= @p_f_desde and vi.F_LLEGADA <= @p_f_hasta
	group by rc.ID_CIUDAD_DESTINO, ci.NOMBRE_CIUDAD
	order by CANT_MICROS_VACIOS desc
	;
		
GO

CREATE PROCEDURE SASHAILO.top_clientes_puntos
AS

	select top 5 NOMBRE, APELLIDO, DNI, TELEFONO ,PUNTOS 
	from SASHAILO.Cliente
	order by PUNTOS desc
	;
		
GO

CREATE PROCEDURE SASHAILO.top_destinos_devueltos
    	@p_f_desde datetime,
    	@p_f_hasta datetime
AS

	select top 5 rc.ID_CIUDAD_DESTINO, ci.NOMBRE_CIUDAD, COUNT(1) CANT_DEVUELTOS
	from SASHAILO.Pasaje pa
	join SASHAILO.Viaje vi on vi.ID_VIAJE = pa.ID_VIAJE
	join SASHAILO.Recorrido re on re.ID_RECORRIDO = vi.ID_RECORRIDO
	join SASHAILO.Recorrido_Ciudades rc on rc.ID_RECORRIDO_CIUDADES = re.ID_RECORRIDO_CIUDADES
	join SASHAILO.Ciudad ci on ci.ID_CIUDAD = rc.ID_CIUDAD_DESTINO
	join SASHAILO.Compra co on co.ID_COMPRA = pa.ID_COMPRA
	where pa.ID_PASAJE in (select de.id_pasaje from SASHAILO.Devolucion de where ID_PASAJE is not null)
		  and co.F_COMPRA >= @p_f_desde and co.F_COMPRA <= @p_f_hasta
	group by rc.ID_CIUDAD_DESTINO, ci.NOMBRE_CIUDAD
	order by CANT_DEVUELTOS desc
	;
		
GO

CREATE PROCEDURE SASHAILO.sp_evalua_cliente_en_viaje
	@p_id_cliente INT,
	@p_id_viaje INT,
	@hayError INT OUT,
	@errores varchar(255) OUT
AS
	SET @hayError = 0
	SET @errores = ''
	
	DECLARE @cantidad INT
	SELECT @cantidad = (SELECT COUNT(1) FROM SASHAILO.Pasaje pa WHERE pa.ID_VIAJE = @p_id_viaje AND 
	                                                                  pa.ID_CLIENTE = @p_id_cliente AND
	                                                                  pa.ID_PASAJE not in (select ID_PASAJE from SASHAILO.Devolucion where ID_PASAJE is not null))
	IF @cantidad > 0 BEGIN
		SET @hayError = 1
		SET @errores = 'El Cliente ingresado ya tiene un Pasaje para el Viaje seleccionado'
		RETURN
	END
	
	SELECT @cantidad = (SELECT COUNT(1) FROM SASHAILO.Pasaje_Encomienda_Temporal pet WHERE pet.ID_VIAJE = @p_id_viaje AND pet.ID_CLIENTE = @p_id_cliente AND pet.ID_BUTACA is not null)
	IF @cantidad > 0 BEGIN
		SET @hayError = 1
		SET @errores = 'El Cliente ingresado ya se encuentra en la lista de Pasajes a comprar para el Viaje seleccionado'
		RETURN
	END
	
	DECLARE @fecha_salida datetime
	DECLARE @fecha_llegada_estim datetime
	SELECT @fecha_salida = (SELECT vi.F_SALIDA FROM SASHAILO.Viaje vi WHERE vi.ID_VIAJE = @p_id_viaje)
	SELECT @fecha_llegada_estim = (SELECT vi.F_LLEGADA_ESTIMADA FROM SASHAILO.Viaje vi WHERE vi.ID_VIAJE = @p_id_viaje)
	SELECT @cantidad = (SELECT COUNT(1) from SASHAILO.Pasaje pa
						JOIN SASHAILO.Viaje vi on vi.ID_VIAJE = pa.ID_VIAJE
						WHERE pa.ID_CLIENTE = @p_id_cliente
						AND (vi.F_SALIDA BETWEEN @fecha_salida AND @fecha_llegada_estim 
						     OR 
							 vi.F_LLEGADA BETWEEN @fecha_salida AND @fecha_llegada_estim)
						AND pa.ID_PASAJE not in (select ID_PASAJE from SASHAILO.Devolucion where ID_PASAJE is not null)
						)
	IF @cantidad > 0 BEGIN
		SET @hayError = 1
		SET @errores = 'El Cliente ingresado tiene Pasaje/s cuyas fechas se superponen con las del Viaje seleccionado'
		RETURN
	END		
	
	SELECT @cantidad = (SELECT COUNT(1) from SASHAILO.Pasaje_Encomienda_Temporal pet
						JOIN SASHAILO.Viaje vi on vi.ID_VIAJE = pet.ID_VIAJE
						WHERE pet.ID_CLIENTE = @p_id_cliente
						AND pet.ID_BUTACA is not null
						AND (vi.F_SALIDA BETWEEN @fecha_salida AND @fecha_llegada_estim 
						     OR 
							 vi.F_LLEGADA BETWEEN @fecha_salida AND @fecha_llegada_estim)
						)
	IF @cantidad > 0 BEGIN
		SET @hayError = 1
		SET @errores = 'El Cliente ingresado está en una lista de Pasajes a comprar cuya fecha de viaje se superponen con la del Viaje seleccionado'
		RETURN
	END							
     
GO 

CREATE PROCEDURE SASHAILO.alta_butaca
    	@p_id_micro int, 
    	@p_nro_butaca int,
    	@p_id_tipo_butaca int, 
    	@p_nro_piso smallint,
    	@hayErr int OUT,
		@errores varchar(200) OUT
    	
AS
BEGIN
	SET @hayErr = 0
	SET @errores = ''
	
	BEGIN TRANSACTION	
	/*grabo butaca*/
	INSERT INTO SASHAILO.Butaca (ID_MICRO, NRO_BUTACA, ID_TIPO_BUTACA, NRO_PISO) 
	VALUES (@p_id_micro, @p_nro_butaca, @p_id_tipo_butaca, @p_nro_piso)
	IF @@error != 0
		ROLLBACK TRANSACTION
	
	COMMIT TRANSACTION  
END
GO

/******************************************** FIN - CREACION DE STORED PROCEDURES, FUNCIONES Y VISTAS ************************************************/

/****************************** INICIO -  LLENADO DE TABLAS A TRAVES DE SP *********************************/

INSERT INTO SASHAILO.Micro(PATENTE, ID_MARCA, MODELO, ID_TIPO_SERVICIO, CANT_KG, F_ALTA)
select distinct ma.Micro_Patente, mm.ID_MARCA, Micro_Modelo, ts.ID_TIPO_SERVICIO, Micro_KG_Disponibles, CONVERT(Datetime, '1900-01-01 00:00:00.000', 120)
from gd_esquema.Maestra ma
join SASHAILO.Marca_Micro mm on mm.DESCRIPCION = ma.Micro_Marca
join SASHAILO.Tipo_Servicio ts on ts.DESCRIPCION = ma.Tipo_Servicio
GO

--pongo los micros como activos
INSERT INTO SASHAILO.Log_Estado_Micro(ID_MICRO, ID_ESTADO, FECHA)
SELECT mi.ID_MICRO, 1, mi.F_ALTA FROM SASHAILO.Micro mi
GO

-- inserto butacas
BEGIN

	SET NOCOUNT ON;
	
	DECLARE @id_micro int
	DECLARE @patente varchar(7)
	DECLARE @nro_factura int
	DECLARE curr_micros CURSOR FOR 
	select distinct ID_MICRO, PATENTE from SASHAILO.Micro order by 1
	
	BEGIN TRANSACTION;
	
	OPEN curr_micros 
	FETCH curr_micros INTO @id_micro, @patente
	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		
		DECLARE @butaca_nro int
		DECLARE @butaca_tipo int
		DECLARE @butaca_piso smallint
		DECLARE curr_butacas CURSOR FOR 
		select distinct Butaca_Nro, tb.ID_TIPO_BUTACA, Butaca_Piso 
		from gd_esquema.Maestra ma join SASHAILO.Tipo_Butaca tb on ma.Butaca_Tipo = tb.DESCRIPCION
		where Micro_Patente=@patente and Pasaje_Codigo <> 0 order by 1
		
		BEGIN TRANSACTION;
		
		OPEN curr_butacas 
		FETCH curr_butacas INTO @butaca_nro, @butaca_tipo, @butaca_piso
		
		WHILE (@@FETCH_STATUS = 0)
		BEGIN
		
			-- Inserto la butaca
			INSERT INTO SASHAILO.Butaca(ID_MICRO, NRO_BUTACA, ID_TIPO_BUTACA, NRO_PISO)
			VALUES (@id_micro, @butaca_nro, @butaca_tipo, @butaca_piso);
			
			FETCH curr_butacas INTO @butaca_nro, @butaca_tipo, @butaca_piso
		END
		
		COMMIT TRANSACTION;
		CLOSE curr_butacas
		DEALLOCATE curr_butacas
		
		
		FETCH curr_micros INTO @id_micro, @patente	
	END
	
	COMMIT TRANSACTION;
	CLOSE curr_micros
	DEALLOCATE curr_micros

END

GO

CREATE PROCEDURE SASHAILO.evaluar_micros
	@p_f_actual datetime
AS
	
	BEGIN TRANSACTION

	DECLARE @id_micro int
	DECLARE curr_micros CURSOR FOR 
	select distinct ID_MICRO from SASHAILO.Micro order by 1
		
	OPEN curr_micros 
	FETCH curr_micros INTO @id_micro
	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		
		DECLARE @id_estado int
		DECLARE @f_f_servicio datetime
		DECLARE @f_r_servicio datetime
		DECLARE @f_b_definitiva datetime
		select @id_estado = ID_ESTADO,
		       @f_f_servicio = FECHA_F_SERVICIO,
			   @f_r_servicio = FECHA_REINICIO,
			   @f_b_definitiva = FECHA_BAJA_DEF
		from SASHAILO.Log_Estado_Micro
		where ID_MICRO = @id_micro
				
		if @p_f_actual = @f_b_definitiva and @id_estado <> 3 begin
			insert into SASHAILO.Log_Estado_Micro(ID_MICRO, ID_ESTADO, FECHA, FECHA_F_SERVICIO, FECHA_REINICIO, FECHA_BAJA_DEF)
			values(@id_micro, 3, @p_f_actual, null, null, @p_f_actual);
		end
		
		if @p_f_actual > @f_b_definitiva and @id_estado <> 3 begin
			insert into SASHAILO.Log_Estado_Micro(ID_MICRO, ID_ESTADO, FECHA, FECHA_F_SERVICIO, FECHA_REINICIO, FECHA_BAJA_DEF)
			values(@id_micro, 3, @p_f_actual, null, null, @f_b_definitiva);
		end
		
		if @p_f_actual >= @f_f_servicio and @id_estado <> 2 begin
			insert into SASHAILO.Log_Estado_Micro(ID_MICRO, ID_ESTADO, FECHA, FECHA_F_SERVICIO, FECHA_REINICIO, FECHA_BAJA_DEF)
			values(@id_micro, 2, @p_f_actual, @f_f_servicio, @f_r_servicio, null);
		end
		
		if @p_f_actual >= @f_r_servicio and @id_estado <> 1 begin
			insert into SASHAILO.Log_Estado_Micro(ID_MICRO, ID_ESTADO, FECHA, FECHA_F_SERVICIO, FECHA_REINICIO, FECHA_BAJA_DEF)
			values(@id_micro, 1, @p_f_actual, null, null, null);
		end
		
		
		FETCH curr_micros INTO @id_micro	
	END
	
	CLOSE curr_micros
	DEALLOCATE curr_micros
	
	COMMIT TRANSACTION
	
GO

CREATE PROCEDURE SASHAILO.sp_get_kg_disponibles_en_viaje
	@p_id_viaje INT,
	@p_kilos NUMERIC(18,0) OUT
AS

	DECLARE @kg_micro NUMERIC(18,0)
	DECLARE @kg_comprados NUMERIC(18,0)
	DECLARE @kg_temporales NUMERIC(18,0)
	
	SELECT @kg_micro = mi.CANT_KG from SASHAILO.Viaje vi
								  join SASHAILO.Micro mi on mi.ID_MICRO = vi.ID_MICRO
								  where vi.ID_VIAJE = @p_id_viaje
								  
	SELECT @kg_comprados = ISNULL(SUM(KG),0) from SASHAILO.Encomienda en where en.ID_VIAJE = @p_id_viaje								  
	SELECT @kg_temporales = ISNULL(SUM(KG),0) from SASHAILO.Pasaje_Encomienda_Temporal pet where pet.ID_VIAJE = @p_id_viaje
	
	SET @p_kilos = @kg_micro - @kg_comprados - @kg_temporales
	
GO

-- actualizo cantidad de butacas
BEGIN

	SET NOCOUNT ON;
	
	DECLARE @id_micro int
	DECLARE curr_micros CURSOR FOR 
	select distinct ID_MICRO from SASHAILO.Micro order by 1
	
	BEGIN TRANSACTION;
	
	OPEN curr_micros 
	FETCH curr_micros INTO @id_micro
	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		
		DECLARE @cant_butacas int
		select @cant_butacas = (select COUNT(1) from SASHAILO.Butaca bu where bu.ID_MICRO = @id_micro)

		UPDATE SASHAILO.Micro SET CANT_BUTACAS = @cant_butacas WHERE ID_MICRO = @id_micro;
		
		FETCH curr_micros INTO @id_micro	
	END
	
	COMMIT TRANSACTION;
	CLOSE curr_micros
	DEALLOCATE curr_micros

END

GO

/****************************** FIN -  LLENADO DE TABLAS A TRAVES DE SP *********************************/

/****************************** INICIO -  LLENADO DE TABLAS II *********************************/

INSERT INTO SASHAILO.Viaje (ID_RECORRIDO, ID_MICRO, F_SALIDA, F_LLEGADA_ESTIMADA, F_LLEGADA)
SELECT DISTINCT Recorrido_Codigo, mi.id_micro, FechaSalida, Fecha_LLegada_Estimada, FechaLLegada
from gd_esquema.Maestra ma join SASHAILO.Micro mi on mi.patente = ma.Micro_Patente
GO

/*INSERT INTO SASHAILO.Pasaje_Encomienda(ID_PASAJE_ENCOMIENDA, ID_CLIENTE, ID_VIAJE, ID_BUTACA, ID_TIPO_PASAJE, PRECIO, KG)
select case ma.Pasaje_Codigo when 0 then ma.Paquete_Codigo else ma.Pasaje_Codigo end Codigo,
	cli.ID_CLIENTE, vi.ID_VIAJE, bu.ID_BUTACA, 
	case ma.Pasaje_Codigo when 0 then 2 else 1 end Tipo_Pasaje,
	case ma.Pasaje_Codigo when 0 then ma.Paquete_Precio else ma.Pasaje_Precio end PRECIO,
	case ma.Pasaje_Codigo when 0 then ma.Paquete_KG else NULL end KG
	from gd_esquema.Maestra ma
	join SASHAILO.Cliente cli on cli.DNI = ma.Cli_Dni
	join SASHAILO.Micro mi on ma.Micro_Patente = mi.PATENTE
	left join SASHAILO.Butaca bu on (bu.ID_MICRO = mi.ID_MICRO and
								bu.NRO_BUTACA = ma.Butaca_Nro and 
								Pasaje_Codigo <>0)
	join SASHAILO.Viaje vi on (vi.ID_RECORRIDO = ma.Recorrido_Codigo and 
							   vi.F_SALIDA = ma.FechaSalida and 
							   vi.F_LLEGADA_ESTIMADA = ma.Fecha_LLegada_Estimada and 
							   vi.F_LLEGADA = ma.FechaLLegada and 
							   vi.ID_MICRO = mi.ID_MICRO)
GO*/

-- cargo los pasajes
INSERT INTO SASHAILO.Pasaje(ID_PASAJE, ID_CLIENTE, ID_VIAJE, ID_BUTACA, PRECIO)
select ma.Pasaje_Codigo Codigo,
	   cli.ID_CLIENTE, vi.ID_VIAJE, bu.ID_BUTACA, 
	   ma.Pasaje_Precio PRECIO
from gd_esquema.Maestra ma
join SASHAILO.Cliente cli on cli.DNI = ma.Cli_Dni
join SASHAILO.Micro mi on ma.Micro_Patente = mi.PATENTE
left join SASHAILO.Butaca bu on (bu.ID_MICRO = mi.ID_MICRO and
							bu.NRO_BUTACA = ma.Butaca_Nro and 
							Pasaje_Codigo <>0)
join SASHAILO.Viaje vi on (vi.ID_RECORRIDO = ma.Recorrido_Codigo and 
						   vi.F_SALIDA = ma.FechaSalida and 
						   vi.F_LLEGADA_ESTIMADA = ma.Fecha_LLegada_Estimada and 
						   vi.F_LLEGADA = ma.FechaLLegada and 
						   vi.ID_MICRO = mi.ID_MICRO)
WHERE ma.Pasaje_Codigo<>0	
GO						   

-- cargo las encomiendas
INSERT INTO SASHAILO.Encomienda(ID_ENCOMIENDA, ID_CLIENTE, ID_VIAJE, KG, PRECIO)
select ma.Paquete_Codigo Codigo,
	   cli.ID_CLIENTE, vi.ID_VIAJE, ma.Paquete_KG, 
	   ma.Paquete_Precio PRECIO
from gd_esquema.Maestra ma
join SASHAILO.Cliente cli on cli.DNI = ma.Cli_Dni
join SASHAILO.Micro mi on ma.Micro_Patente = mi.PATENTE
join SASHAILO.Viaje vi on (vi.ID_RECORRIDO = ma.Recorrido_Codigo and 
						   vi.F_SALIDA = ma.FechaSalida and 
						   vi.F_LLEGADA_ESTIMADA = ma.Fecha_LLegada_Estimada and 
						   vi.F_LLEGADA = ma.FechaLLegada and 
						   vi.ID_MICRO = mi.ID_MICRO)
WHERE ma.Pasaje_Codigo=0	
GO	

/*BEGIN

	SET NOCOUNT ON;

	DECLARE @id_pasaje_encomienda numeric(18,0)
	DECLARE @contador int
	SET @contador = 0;
	DECLARE curr_pasajes CURSOR FOR 
	SELECT ID_PASAJE_ENCOMIENDA FROM SASHAILO.Pasaje_Encomienda

	BEGIN TRANSACTION;

	OPEN curr_pasajes 
	FETCH curr_pasajes INTO @id_pasaje_encomienda

	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		
		SET @contador = @contador + 1;
		
		UPDATE SASHAILO.Pasaje_Encomienda SET ID_COMPRA = @contador WHERE ID_PASAJE_ENCOMIENDA = @id_pasaje_encomienda
		
		FETCH curr_pasajes INTO @id_pasaje_encomienda
	END

	COMMIT TRANSACTION;

	CLOSE curr_pasajes
	DEALLOCATE curr_pasajes

END

GO*/

BEGIN

	SET NOCOUNT ON;

	DECLARE @id_pasaje numeric(18,0)
	DECLARE @contador int
	SET @contador = 0;
	DECLARE curr_pasajes CURSOR FOR 
	SELECT ID_PASAJE FROM SASHAILO.Pasaje

	BEGIN TRANSACTION;

	OPEN curr_pasajes 
	FETCH curr_pasajes INTO @id_pasaje

	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		
		SET @contador = @contador + 1;
		
		UPDATE SASHAILO.Pasaje SET ID_COMPRA = @contador WHERE ID_PASAJE = @id_pasaje
		
		FETCH curr_pasajes INTO @id_pasaje
	END

	COMMIT TRANSACTION;

	CLOSE curr_pasajes
	DEALLOCATE curr_pasajes

END

GO

BEGIN

	SET NOCOUNT ON;

	DECLARE @id_encomienda numeric(18,0)
	DECLARE @contador int
	SET @contador = (select MAX(ID_COMPRA) from SASHAILO.Pasaje);
	DECLARE curr_encomiendas CURSOR FOR 
	SELECT ID_ENCOMIENDA FROM SASHAILO.Encomienda

	BEGIN TRANSACTION;

	OPEN curr_encomiendas 
	FETCH curr_encomiendas INTO @id_encomienda

	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		
		SET @contador = @contador + 1;
		
		UPDATE SASHAILO.Encomienda SET ID_COMPRA = @contador WHERE ID_ENCOMIENDA = @id_encomienda
		
		FETCH curr_encomiendas INTO @id_encomienda
	END

	COMMIT TRANSACTION;

	CLOSE curr_encomiendas
	DEALLOCATE curr_encomiendas

END

GO

--inserto las compras de los pasajes
INSERT INTO SASHAILO.Compra(ID_COMPRA, F_COMPRA, IMPORTE, ID_CLIENTE, ID_MEDIO_PAGO)
SELECT Pa.ID_COMPRA, MA.Pasaje_FechaCompra, pa.PRECIO, pa.ID_CLIENTE, 1
FROM SASHAILO.Pasaje pa
JOIN gd_esquema.Maestra ma on ma.Pasaje_Codigo = pa.ID_PASAJE 
GO

--inserto las compras de los paquetes
INSERT INTO SASHAILO.Compra(ID_COMPRA, F_COMPRA, IMPORTE, ID_CLIENTE, ID_MEDIO_PAGO)
SELECT en.ID_COMPRA, MA.Paquete_FechaCompra, en.PRECIO, en.ID_CLIENTE, 1
FROM SASHAILO.Encomienda en
JOIN gd_esquema.Maestra ma on ma.Paquete_Codigo = en.ID_ENCOMIENDA 
GO

--creo las fk a compra
ALTER TABLE SASHAILO.Pasaje
ADD CONSTRAINT fk_pasaje_id_compra
FOREIGN KEY (ID_COMPRA)
REFERENCES SASHAILO.Compra(ID_COMPRA)
GO

ALTER TABLE SASHAILO.Encomienda
ADD CONSTRAINT fk_encomienda_id_compra
FOREIGN KEY (ID_COMPRA)
REFERENCES SASHAILO.Compra(ID_COMPRA)
GO

-- lleno el historial de puntos
INSERT INTO SASHAILO.Historial_Puntos(ID_CLIENTE, ID_PASAJE, PUNTOS, FECHA)
SELECT id_cliente, id_pasaje, round (pa.PRECIO/5,0) as PUNTOS, vi.F_SALIDA
FROM SASHAILO.Pasaje pa
JOIN SASHAILO.Viaje vi on vi.ID_VIAJE = pa.ID_VIAJE
GO

INSERT INTO SASHAILO.Historial_Puntos(ID_CLIENTE, ID_ENCOMIENDA, PUNTOS, FECHA)
SELECT id_cliente, id_encomienda, round (en.PRECIO/5,0) as PUNTOS, vi.F_SALIDA
FROM SASHAILO.Encomienda en
JOIN SASHAILO.Viaje vi on vi.ID_VIAJE = en.ID_VIAJE
GO

-- lleno la tabla de llegada a destino
INSERT INTO SASHAILO.Llegada(PATENTE, ID_MICRO, F_LLEGADA, ID_VIAJE, ID_CIUDAD_ORIGEN, ID_CIUDAD_DESTINO)
SELECT mi.PATENTE, mi.ID_MICRO, vi.F_LLEGADA, vi.ID_VIAJE, rc.ID_CIUDAD_ORIGEN, rc.ID_CIUDAD_DESTINO
FROM SASHAILO.Viaje vi
join SASHAILO.Micro mi on mi.ID_MICRO = vi.ID_MICRO
join SASHAILO.Recorrido re on re.ID_RECORRIDO = vi.ID_RECORRIDO
join SASHAILO.Recorrido_Ciudades rc on rc.ID_RECORRIDO_CIUDADES = re.ID_RECORRIDO_CIUDADES
GO

--actualizo los puntos de los clientes
UPDATE SASHAILO.Cliente SET PUNTOS = t2.PUNTOS
FROM SASHAILO.Cliente
INNER JOIN (SELECT ID_CLIENTE, SUM(PUNTOS) as PUNTOS
			FROM SASHAILO.Historial_Puntos
			GROUP BY ID_CLIENTE) t2
ON SASHAILO.Cliente.ID_CLIENTE = t2.id_CLIENTE
GO

/****************************** FIN -  LLENADO DE TABLAS II *********************************/


/******************************************** INICIO - TRIGGERS *****************************************/

create trigger t_registro_llegada
on SASHAILO.Llegada
for insert
as
BEGIN
	
	BEGIN TRANSACTION 
	
	declare @id_viaje int
	declare @f_llegada datetime
	select @id_viaje=id_viaje, @f_llegada=f_llegada from inserted
	
	UPDATE SASHAILO.Viaje SET F_LLEGADA = @f_llegada WHERE ID_VIAJE = @id_viaje
	
	DECLARE @precio numeric(18,2)
	DECLARE @id_pasaje numeric(18,0)
	DECLARE @id_encomienda numeric(18,0)
	DECLARE @id_cliente int
	DECLARE @puntos int
	
	DECLARE curr_pasajes CURSOR FOR 
	select PRECIO, ID_PASAJE, ID_CLIENTE from SASHAILO.Pasaje pa where pa.ID_VIAJE = @id_viaje
	OPEN curr_pasajes 
	FETCH curr_pasajes INTO @precio, @id_pasaje, @id_cliente	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
	
		SET @puntos = @precio / 5
		
		INSERT INTO SASHAILO.Historial_Puntos(ID_CLIENTE, ID_PASAJE, PUNTOS, FECHA)
		VALUES(@id_cliente, @id_pasaje, @puntos, @f_llegada)
		
		UPDATE SASHAILO.Cliente SET PUNTOS = PUNTOS + @puntos WHERE ID_CLIENTE = @id_cliente
		
		FETCH curr_pasajes INTO @precio, @id_pasaje, @id_cliente
	END
	CLOSE curr_pasajes
	DEALLOCATE curr_pasajes	
	
	DECLARE curr_encomienda CURSOR FOR 
	select PRECIO, ID_ENCOMIENDA, ID_CLIENTE from SASHAILO.Encomienda en where en.ID_VIAJE = @id_viaje
	OPEN curr_encomienda 
	FETCH curr_encomienda INTO @precio, @id_encomienda, @id_cliente	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN

		SET @puntos = @precio / 5
		
		INSERT INTO SASHAILO.Historial_Puntos(ID_CLIENTE, ID_ENCOMIENDA, PUNTOS, FECHA)
		VALUES(@id_cliente, @id_encomienda, @puntos, @f_llegada)
		
		UPDATE SASHAILO.Cliente SET PUNTOS = PUNTOS + @puntos WHERE ID_CLIENTE = @id_cliente
		
		FETCH curr_encomienda INTO @precio, @id_encomienda, @id_cliente
	END
	CLOSE curr_encomienda
	DEALLOCATE curr_encomienda		
		
	COMMIT TRANSACTION 
	
END

/******************************************** FIN - TRIGGERS *****************************************/
