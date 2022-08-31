DROP SCHEMA IF EXISTS empleadosdb;
CREATE SCHEMA IF NOT EXISTS empleadosdb;
USE empleadosdb;

CREATE TABLE PUESTO (
  id_puesto INT NOT NULL AUTO_INCREMENT,
  nombre VARCHAR(45) NOT NULL,
  descripcion VARCHAR(200) NULL DEFAULT "",
  PRIMARY KEY (id_puesto));

CREATE TABLE DEPARTAMENTO (
  id_departamento INT NOT NULL AUTO_INCREMENT,
  nombre VARCHAR(100) NOT NULL,
  presupuesto DOUBLE NOT NULL,
  descripcion VARCHAR(250) NULL DEFAULT "",
  PRIMARY KEY (id_departamento));

CREATE TABLE EMPLEADO (
  cui VARCHAR(13) NOT NULL,
  nombre VARCHAR(45) NOT NULL,
  apellidos VARCHAR(60) NOT NULL,
  sueldo DOUBLE NOT NULL,
  fecha_ingreso DATE NOT NULL,
  fecha_baja DATE NULL,
  id_puesto INT NOT NULL,
  id_departamento INT NOT NULL,
  id_jefe VARCHAR(13) NULL,
  PRIMARY KEY (cui),
  CONSTRAINT fk_EMPLEADO_PUESTO
    FOREIGN KEY (id_puesto)
    REFERENCES PUESTO (id_puesto)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT fk_EMPLEADO_DEPARTAMENTO1
    FOREIGN KEY (id_departamento)
    REFERENCES DEPARTAMENTO (id_departamento)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT,
  CONSTRAINT fk_EMPLEADO_EMPLEADO1
    FOREIGN KEY (id_jefe)
    REFERENCES EMPLEADO (cui)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT);

CREATE TABLE HIST_AUMENTO_EMPLEADO (
  id_hist_aumentos INT NOT NULL AUTO_INCREMENT,
  salario_anterior DOUBLE NOT NULL,
  nuevo_salario DOUBLE NOT NULL,
  fecha_aumento DATE NOT NULL,
  cui_empleado VARCHAR(13) NOT NULL,
  PRIMARY KEY (id_hist_aumentos),
  CONSTRAINT fk_HIST_AUMENTO_EMPLEADO_EMPLEADO1
    FOREIGN KEY (EMPLEADO_cui)
    REFERENCES EMPLEADO (cui)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT);

INSERT INTO PUESTO(nombre, descripcion) VALUES('Gerente general', 'descripcion');
INSERT INTO DEPARTAMENTO(nombre, presupuesto) VALUES('Finanzas', 15000);
INSERT INTO EMPLEADO(cui, nombre, apellidos, sueldo, fecha_ingreso, id_puesto, id_departamento)
VALUES('3370312150920', 'Asael', 'Hernandez', 10000, '2020-02-02', 1, 1);
