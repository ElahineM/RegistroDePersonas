IF db_id('ElahinePrueba') IS NULL 
    CREATE DATABASE ElahinePrueba;

GO

USE ElahinePrueba;

CREATE TABLE Persona (
ID int primary key identity(1,1),
Nombre varchar(50) not null,
FechaDeNacimiento date not null,
);
