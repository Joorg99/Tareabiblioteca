CREATE DATABASE libreria;
USE libreria;
CREATE TABLE libros (
id INT(8) AUTO_INCREMENT PRIMARY KEY,
nombre VARCHAR(20),
icbn INT(15) UNIQUE NOT NULL,
autor VARCHAR(30),
genero VARCHAR(10),
fecha_lanzamiento VARCHAR(60),
cantidad_paginas INT(4)
);

CREATE TABLE socios(
id int auto_increment primary key,
apellido varchar(15),
nombre varchar(15),
telefono INT(12)
);

CREATE TABLE prestamos (
id INT AUTO_INCREMENT PRIMARY KEY,
libro INT(8),
socio INT(8),
fecha_prestamo varchar(20),
fecha_devolucion VARCHAR(20),
FOREIGN KEY (libro_id) REFERENCES libros(id),
FOREIGN KEY (socio_id) REFERENCES socios(id)
);