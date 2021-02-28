	create database TELEVISA
	USE CRUD
	CREATE TABLE PERSONAL (
	ID INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	NOMBRE VARCHAR (15),
	APELLIDO_P VARCHAR (15),
	APELLIDO_M VARCHAR (15),
	EDAD INT ,
	IosActive bit
	)
	CREATE PROCEDURE PROC_TODO
	@ID INT,
	@NOMBRE VARCHAR (15),
	@APELLIDO_P VARCHAR (15),
	@APELLIDO_M VARCHAR (15),
	@EDAD INT ,
	@IosActive bit,
	@ELEGIR CHAR (1)
	AS
	IF @ELEGIR = 'S'
	BEGIN
	SELECT * FROM PERSONAL
	END
	IF @ELEGIR = 'I'
	BEGIN
	INSERT INTO PERSONAL ([NOMBRE],[APELLIDO_P], [APELLIDO_M],[EDAD],[IosActive])
	VALUES (@NOMBRE, @APELLIDO_P, @APELLIDO_M, @EDAD, @IosActive) 
	END
	IF @ELEGIR = 'U'
	BEGIN
	UPDATE PERSONAL SET [NOMBRE] = @NOMBRE, [APELLIDO_P] = @APELLIDO_P, [APELLIDO_M] = @APELLIDO_M, [EDAD] = @EDAD, [IosActive] = @IosActive
	WHERE ID = @ID
	END
	IF @ELEGIR = 'D'
	BEGIN
	DELETE FROM PERSONAL WHERE ID = @ID
	END 
	GO

	EXECUTE PROC_TODO @ELEGIR = 'D', @ID = 6, @NOMBRE ='RAFIS' ,@APELLIDO_P = 'CERVANTES' ,@APELLIDO_M = 'ROMERO' ,@EDAD = 22, @IosActive = 1

	SELECT *  FROM PERSONAL
	INSERT INTO PERSONAL VALUES ('RAFAEL' ,'CERVANTES','ROMERO',22, 1)