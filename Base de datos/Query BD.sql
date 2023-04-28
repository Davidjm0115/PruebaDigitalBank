-- Crea la base de datos
CREATE DATABASE BdPrueba;
 GO
-- Selecciona la base de datos
USE BdPrueba;

-- Crea la tabla "usuarios"
CREATE TABLE usuarios (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100),
    fecha_nacimiento DATE,
    sexo CHAR(1)
);
GO 
-- Crea el SP
CREATE PROCEDURE SP_CRUD_Usuarios
    @Id INT = NULL,
    @Nombre VARCHAR(100) = NULL,
    @FechaNacimiento DATE = NULL,
    @Sexo CHAR(1) = NULL,
    @opcion VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    
    IF (@opcion = 'SELECT')
    BEGIN
        -- Consulta todos los registros de la tabla
        SELECT * FROM Usuarios
    END
	ELSE IF (@opcion = 'SELECTID')
    BEGIN
        -- Consulta por id
		SELECT * FROM Usuarios where Id = @id
    END
    ELSE IF (@opcion = 'INSERT')
    BEGIN
        -- Inserta un nuevo registro en la tabla
        INSERT INTO Usuarios (Nombre, Fecha_Nacimiento, Sexo)
        VALUES (@Nombre, @FechaNacimiento, @Sexo)
    END
    ELSE IF (@opcion = 'UPDATE')
    BEGIN
        -- Actualiza un registro existente en la tabla
        UPDATE Usuarios SET
            Nombre = @Nombre,
            Fecha_Nacimiento = @FechaNacimiento,
            Sexo = @Sexo
        WHERE Id = @Id
    END
    ELSE IF (@opcion = 'DELETE')
    BEGIN
        -- Elimina un registro existente de la tabla
        DELETE FROM Usuarios WHERE Id = @Id
    END
END