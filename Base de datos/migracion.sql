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
	ID_CIUDAD smallint not null IDENTITY,
	NOMBRE_CIUDAD varchar(60) not null,
	HABILITADA char(1) not null DEFAULT 'S',
	UNIQUE(NOMBRE_CIUDAD),
	PRIMARY KEY (ID_CIUDAD)
)

GO


/******************************************** FIN - CREACION DE TABLAS *********************************************/

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

/******************************************** INICIO - LLENADO DE TABLAS *********************************************/

-- ROLES
INSERT INTO SASHAILO.Rol(NOMBRE)
values ('Administrador');

GO

INSERT INTO SASHAILO.Rol(NOMBRE)
values ('Cliente');

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

INSERT INTO SASHAILO.Ciudad(NOMBRE_CIUDAD)
SELECT DISTINCT Recorrido_Ciudad_Origen FROM gd_esquema.Maestra where Recorrido_Ciudad_Origen is not null
GO


/******************************************** FIN - LLENADO DE TABLAS ************************************************/


/******************************************** INICIO - CREACION DE STORED PROCEDURES ************************************************/

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

/******************************************** FIN - CREACION DE STORED PROCEDURES ************************************************/