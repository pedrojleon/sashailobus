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

CREATE TABLE SASHAILO.Tipo_Servicio(
	ID_TIPO_SERVICIO int PRIMARY KEY NOT NULL IDENTITY,
	DESCRIPCION nvarchar(255),
	ADICIONAL decimal(10,2)
) 

GO

CREATE TABLE SASHAILO.Recorrido(
	ID_RECORRIDO numeric(18,0) PRIMARY KEY NOT NULL,
	CODIGO_RECORRIDO nvarchar(15),
	ID_CIUDAD_ORIGEN int FOREIGN KEY REFERENCES SASHAILO.Ciudad(ID_CIUDAD),
	ID_CIUDAD_DESTINO int FOREIGN KEY REFERENCES SASHAILO.Ciudad(ID_CIUDAD),
	PRECIO_BASE_KG decimal(10,2),
	PRECIO_BASE_PASAJE decimal(10,2),
	ID_TIPO_SERVICIO int FOREIGN KEY REFERENCES SASHAILO.Tipo_Servicio(ID_TIPO_SERVICIO)
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
	FUERA_DE_SERVICIO char(1) not null DEFAULT 'N',
	FIN_VIDA_UTIL char(1) not null DEFAULT 'N',
	F_FUERA_SERVICIO smalldatetime,
	F_REINICIO_SERVICIO smalldatetime,
	F_FIN_VIDA_UTIL smalldatetime,
	F_ALTA smalldatetime,
	CANT_BUTACAS int,
	CANT_KG int,
	UNIQUE(PATENTE),
	PRIMARY KEY(ID_MICRO)
)

GO

ALTER TABLE SASHAILO.Micro ADD F_ALTA smalldatetime
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

INSERT INTO SASHAILO.Recorrido(ID_CIUDAD_ORIGEN,ID_CIUDAD_DESTINO,PRECIO_BASE_KG,PRECIO_BASE_PASAJE,ID_TIPO_SERVICIO, ID_RECORRIDO)
select distinct ci_o.ID_CIUDAD, ci_d.ID_CIUDAD,(select max(ma2.Recorrido_Precio_BaseKG) 
                                                from gd_esquema.Maestra ma2 
                                                where ma2.Recorrido_Ciudad_Origen = ma.Recorrido_Ciudad_Origen
                                                and ma2.Recorrido_Ciudad_Destino = ma.Recorrido_Ciudad_Destino
                                                and ma2.Recorrido_Precio_BaseKG <> 0), 
 ma.Recorrido_Precio_BasePasaje, ts.ID_TIPO_SERVICIO, ma.Recorrido_Codigo
from gd_esquema.Maestra ma
join SASHAILO.Ciudad ci_o on ci_o.NOMBRE_CIUDAD = ma.Recorrido_Ciudad_Origen
join SASHAILO.Ciudad ci_d on ci_d.NOMBRE_CIUDAD = ma.Recorrido_Ciudad_Destino
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
    	@p_id_ciudad_destino int
AS

	SELECT ID_RECORRIDO, ori.NOMBRE_CIUDAD, dest.NOMBRE_CIUDAD, ts.DESCRIPCION, re.PRECIO_BASE_PASAJE, re.PRECIO_BASE_KG
	FROM SASHAILO.Recorrido re
	JOIN SASHAILO.Ciudad ori on ori.ID_CIUDAD = re.ID_CIUDAD_ORIGEN
	JOIN SASHAILO.Ciudad dest on dest.ID_CIUDAD = re.ID_CIUDAD_DESTINO
	JOIN SASHAILO.Tipo_Servicio ts on ts.ID_TIPO_SERVICIO = re.ID_TIPO_SERVICIO
	WHERE (@p_id_ciudad_origen is null or ori.ID_CIUDAD = @p_id_ciudad_origen)
	and (@p_id_ciudad_destino is null or dest.ID_CIUDAD = @p_id_ciudad_destino)
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
	
	INSERT INTO SASHAILO.Recorrido(ID_RECORRIDO, CODIGO_RECORRIDO, ID_CIUDAD_ORIGEN, ID_CIUDAD_DESTINO, PRECIO_BASE_KG, PRECIO_BASE_PASAJE, ID_TIPO_SERVICIO)
	VALUES (@id_recorrido, @cod_recorrido, @p_id_ciudad_origen, @p_id_ciudad_destino, @p_base_kg, @p_base_pasaje, @p_id_tipo_servicio)
	
	UPDATE SASHAILO.Recorrido SET PRECIO_BASE_KG = @p_base_kg, PRECIO_BASE_PASAJE = @p_base_pasaje
	WHERE ID_CIUDAD_ORIGEN = @p_id_ciudad_origen AND ID_CIUDAD_DESTINO = @p_id_ciudad_destino

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
	
	UPDATE SASHAILO.Recorrido SET ID_CIUDAD_ORIGEN = @p_id_ciudad_origen, ID_CIUDAD_DESTINO = @p_id_ciudad_destino,
	                              PRECIO_BASE_KG = @p_base_kg, PRECIO_BASE_PASAJE = @p_base_pasaje, ID_TIPO_SERVICIO = @p_id_tipo_servicio
	WHERE ID_RECORRIDO = @p_id_recorrido
	
	UPDATE SASHAILO.Recorrido SET PRECIO_BASE_KG = @p_base_kg, PRECIO_BASE_PASAJE = @p_base_pasaje
	WHERE ID_CIUDAD_ORIGEN = @p_id_ciudad_origen AND ID_CIUDAD_DESTINO = @p_id_ciudad_destino

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

CREATE PROCEDURE SASHAILO.listado_micros
    	@p_id_marca int, 
    	@p_id_tipo_servicio int, 
    	@p_patente varchar(7)
AS

	SELECT ID_MICRO, PATENTE, ma.DESCRIPCION, MODELO, ts.DESCRIPCION, 
		   CANT_BUTACAS, CANT_KG, FUERA_DE_SERVICIO, FIN_VIDA_UTIL
	FROM SASHAILO.Micro mi
	JOIN SASHAILO.Marca_Micro ma on ma.ID_MARCA=mi.ID_MARCA
	JOIN SASHAILO.Tipo_Servicio ts on ts.ID_TIPO_SERVICIO=mi.ID_TIPO_SERVICIO
	WHERE (@p_id_marca is null or mi.ID_MARCA = @p_id_marca)
	and (@p_id_tipo_servicio is null or mi.ID_TIPO_SERVICIO = @p_id_tipo_servicio)
	and (@p_patente is null or upper(mi.PATENTE) = upper(@p_patente))
	;
		
GO

CREATE PROCEDURE SASHAILO.alta_micro
    	@p_patente varchar(7),
    	@p_id_marca int, 
    	@p_modelo varchar(25),
    	@p_id_tipo_servicio int, 
    	@p_m_fuera_servicio char(1),
    	@p_cant_kg int, 
    	@p_cant_butacas int,
    	@id_micro_generado int OUT,
    	@hayErr int OUT,
		@errores varchar(200) OUT
    	
AS
BEGIN
	SET @hayErr = 0
	SET @errores = ''
	
	BEGIN TRANSACTION	
	/*grabo el micro*/
	INSERT INTO SASHAILO.Micro (PATENTE, ID_MARCA, MODELO, ID_TIPO_SERVICIO, FUERA_DE_SERVICIO, CANT_BUTACAS, CANT_KG, F_ALTA) 
	VALUES (@p_patente, @p_id_marca, @p_modelo, @p_id_tipo_servicio, @p_m_fuera_servicio, @p_cant_butacas, @p_cant_kg, GETDATE())
	IF @@error != 0
		ROLLBACK TRANSACTION
	SET @id_micro_generado = SCOPE_IDENTITY()	

	
	COMMIT TRANSACTION  
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

INSERT INTO SASHAILO.Micro(PATENTE, ID_MARCA, MODELO, ID_TIPO_SERVICIO, CANT_KG)
select distinct ma.Micro_Patente, mm.ID_MARCA, Micro_Modelo, ts.ID_TIPO_SERVICIO, Micro_KG_Disponibles
from gd_esquema.Maestra ma
join SASHAILO.Marca_Micro mm on mm.DESCRIPCION = ma.Micro_Marca
join SASHAILO.Tipo_Servicio ts on ts.DESCRIPCION = ma.Tipo_Servicio
GO

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
		where Micro_Patente=@patente and Butaca_Nro <> 0 order by 1
		
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