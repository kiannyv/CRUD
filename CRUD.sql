--DROP TABLE IF EXISTS tb_edificios;

--CREATE TABLE tb_persona (
--	id_usuario VARCHAR(255) PRIMARY KEY NOT NULL,
--	nombre VARCHAR(255) NOT NULL,
--    edad INT NOT NULL,
--	email VARCHAR(255) NOT NULL
--);

--CREATE TABLE tb_sede (
--	id_sede VARCHAR(255) PRIMARY KEY NOT NULL,
--	nombre VARCHAR(255) NOT NULL,
--	id_usuario VARCHAR(255) NOT NULL
--);

--CREATE TABLE tb_carreras (
	--id_carrera VARCHAR(255) PRIMARY KEY NOT NULL,
	--nombre VARCHAR(255) NOT NULL,
	--id_sede VARCHAR(255) NOT NULL
--);

--CREATE TABLE tb_materias (
--   id_materia VARCHAR(255) PRIMARY KEY NOT NULL,
--	nombre VARCHAR(255) NOT NULL,
--	id_carrera VARCHAR(255) NOT NULL
--);

--CREATE TABLE tb_horario (
--	id_horario VARCHAR(255) PRIMARY KEY NOT NULL,
--	nombre VARCHAR(255) NOT NULL,
--	id_materia VARCHAR(255) NOT NULL
--);

--CREATE TABLE tb_aula (
--	id_aula VARCHAR(255) PRIMARY KEY NOT NULL,
--	nombre VARCHAR(255) NOT NULL,
--	id_horario VARCHAR(255) NOT NULL
--);

--CREATE TABLE tb_edificio (
--	id_edificio VARCHAR(255) PRIMARY KEY NOT NULL,
--	nombre VARCHAR(255) NOT NULL,
--	id_aula VARCHAR(255) NOT NULL
--);

--SELECT * from tb_personas