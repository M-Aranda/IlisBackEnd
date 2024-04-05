
1. Correr script SQL o migraciones
2. Compilar proyecto en Visual Studio 2022
3. Ejecutar
4. Debiese abrirse una pestaña de navegación de Swagger, con las APIS creadas

Script SQL es:

CREATE DATABASE EASTVIEW;


USE EASTVIEW;

CREATE TABLE CIUDADANO(
id INT auto_increment,
nombre VARCHAR (100),
primary key(id)
);

CREATE TABLE TAREA(
id INT auto_increment,
descripcion_tarea VARCHAR (200),
dia_de_la_semana INT,
primary key(id)
);

CREATE TABLE ASIGNACION_TAREA(
id INT auto_increment,
id_ciudadano INT,
id_tarea INT,
foreign key (id_ciudadano) references CIUDADANO(id),
foreign key (id_tarea) references TAREA(id),
primary key (id)
);

INSERT INTO CIUDADANO VALUES(NULL,'Jose');
INSERT INTO CIUDADANO VALUES(NULL,'Marcelo');
INSERT INTO CIUDADANO VALUES(NULL,'Ethan');
INSERT INTO CIUDADANO VALUES(NULL,'Miranda');
INSERT INTO CIUDADANO VALUES(NULL,'Cassandra');


INSERT INTO TAREA VALUES(NULL,'Dibujar', 1);
INSERT INTO TAREA VALUES(NULL,'Hacer artesania', 1);
INSERT INTO TAREA VALUES(NULL,'Saltar', 1);

INSERT INTO TAREA VALUES(NULL,'Cocinar', 2);
INSERT INTO TAREA VALUES(NULL,'Pasear al perro', 2);
INSERT INTO TAREA VALUES(NULL,'Pasear al gato', 2);

INSERT INTO TAREA VALUES(NULL,'Hacer una silla', 3);
INSERT INTO TAREA VALUES(NULL,'Hacer una puerta', 3);
INSERT INTO TAREA VALUES(NULL,'Hacer una mesa', 3);

INSERT INTO TAREA VALUES(NULL,'Prender una vela', 4);
INSERT INTO TAREA VALUES(NULL,'Rezar', 4);
INSERT INTO TAREA VALUES(NULL,'Cantar', 4);

INSERT INTO TAREA VALUES(NULL,'Buscar leña', 5);
INSERT INTO TAREA VALUES(NULL,'Hacer una fogata', 5);
INSERT INTO TAREA VALUES(NULL,'Plantar papas', 5);

INSERT INTO TAREA VALUES(NULL,'Hacer ejercicio', 6);
INSERT INTO TAREA VALUES(NULL,'Arreglar ventanas', 6);
INSERT INTO TAREA VALUES(NULL,'Hacer vidrio', 6);

INSERT INTO TAREA VALUES(NULL,'Bailar', 7);
INSERT INTO TAREA VALUES(NULL,'Hacer cerveza', 7);
INSERT INTO TAREA VALUES(NULL,'Lee un libro', 7);

INSERT INTO ASIGNACION_TAREA VALUES(NULL, 1,1);
INSERT INTO ASIGNACION_TAREA VALUES(NULL, 2,2);
INSERT INTO ASIGNACION_TAREA VALUES(NULL, 2,3);






