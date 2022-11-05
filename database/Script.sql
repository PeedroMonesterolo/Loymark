-- CREO BD
CREATE DATABASE loymark


-- CREO TABLA Usuarios
CREATE TABLE Usuarios
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(25) NOT NULL,
	apellido VARCHAR(35) NOT NULL,
	email VARCHAR(50) NOT NULL,
	fecha_nacimiento DATE NOT NULL, 
	telefono BIGINT,
	cod_pais VARCHAR(3) NOT NULL,
	recibir_info BIT DEFAULT 0 NOT NULL
)

-- CREO TABLA Actividad
CREATE TABLE Actividad
(
	id_actividad INT IDENTITY(1,1) PRIMARY KEY,
	create_date DATETIME NOT NULL,
	id_usuario INT NOT NULL,
	actividad VARCHAR(MAX) NOT NULL,
)

-- AGREGO CLAVE FORANEA
ALTER TABLE Actividad
ADD CONSTRAINT FK_id_usuario
FOREIGN KEY (id_usuario) REFERENCES Usuarios (id)
GO

SELECT
	*
FROM Usuarios

SELECT
	*
FROM Actividad