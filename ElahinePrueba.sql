CREATE DATABASE ElahinePrueba;

USE ElahinePrueba;

CREATE TABLE Persona (
ID int primary key identity(1,1),
Nombre varchar(50) not null,
FechaDeNacimiento date not null,
);
