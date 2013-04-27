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

/******************************************** FIN - CREACION DE TABLAS *********************************************/


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
values ('Compra de Pasaje/Enconmienda');

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


/******************************************** FIN - LLENADO DE TABLAS ************************************************/


/******************************************** INICIO - CREACION DE STORED PROCEDURES ************************************************/

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
where DESCRIPCION = 'Compra de Pasaje/Enconmienda'

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
where DESCRIPCION = 'Compra de Pasaje/Enconmienda'

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