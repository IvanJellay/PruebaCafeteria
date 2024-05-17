CREATE DATABASE DB_CAFETERIA;
USE DB_CAFETERIA;

CREATE TABLE Tb_HccOrdenes (
  ord_id INT PRIMARY KEY NOT NULL,
  mes_id INT NOT NULL,
  catord_id INT NOT NULL,
  ord_fecha_inicio DATE NOT NULL,
  ord_estatus TINYINT NOT NULL,
  FOREIGN KEY (mes_id) REFERENCES Tb_HccMesas(mes_id),
  FOREIGN KEY (catord_id) REFERENCES Tb_HccCatEstatusOrden(catord_id)
);

CREATE TABLE Tb_HccOrdenesDetalle (
  orddet_id INT PRIMARY KEY NOT NULL,
  ord_id INT NOT NULL,
  pro_id INT NOT NULL,
  orddet_cantidad SMALLINT NOT NULL,
  orddet_estatus TINYINT NOT NULL,
  FOREIGN KEY (ord_id) REFERENCES Tb_HccOrdenes(ord_id),
  FOREIGN KEY (pro_id) REFERENCES Tb_HccProductos(pro_id)
);

CREATE TABLE Tb_HccCatEstatusOrden (
  catord_id INT PRIMARY KEY NOT NULL,
  catord_nombre VARCHAR(50) NOT NULL,
  catord_estatus TINYINT NOT NULL
);

CREATE TABLE Tb_HccMesas (
  mes_id INT PRIMARY KEY NOT NULL,
  mes_lugares SMALLINT NOT NULL,
  mes_disponible TINYINT NOT NULL,
  mes_estatus TINYINT NOT NULL
);

CREATE TABLE Tb_HccProductos (
  pro_id INT PRIMARY KEY NOT NULL,
  alm_id INT NOT NULL,
  pro_nombre VARCHAR(50) NOT NULL,
  pro_descripcion VARCHAR(120) NOT NULL,
  pro_precio DECIMAL(10,4) NOT NULL,
  pro_estatus TINYINT NOT NULL,
  FOREIGN KEY (alm_id) REFERENCES Tb_HccAlmacen(alm_id)
);

CREATE TABLE Tb_HccAlmacen (
  alm_id INT PRIMARY KEY NOT NULL,
  alm_cantidad INT NOT NULL,
  alm_fecha_actualizacion DATE NOT NULL,
  alm_estatus TINYINT NOT NULL
);


-- Llenando la tabla Tb_HccOrdenes
INSERT INTO Tb_HccOrdenes (ord_id, mes_id, catord_id, ord_fecha_inicio, ord_estatus) VALUES
(1, 1, 1, '2024-05-16', 1),
(2, 2, 1, '2024-05-16', 1),
(3, 3, 1, '2024-05-16', 1),
(4, 4, 1, '2024-05-16', 1),
(5, 5, 1, '2024-05-16', 1),
(6, 6, 1, '2024-05-16', 1),
(7, 7, 1, '2024-05-16', 1);

-- Llenando la tabla Tb_HccOrdenesDetalle
INSERT INTO Tb_HccOrdenesDetalle (orddet_id, ord_id, pro_id, orddet_cantidad, orddet_estatus) VALUES
(1, 1, 1, 2, 1),
(2, 1, 3, 1, 1),
(3, 2, 2, 3, 1),
(4, 2, 4, 2, 1),
(5, 3, 5, 2, 1),
(6, 3, 6, 1, 1),
(7, 4, 7, 2, 1);

-- Llenando la tabla Tb_HccCatEstatusOrden
INSERT INTO Tb_HccCatEstatusOrden (catord_id, catord_nombre, catord_estatus) VALUES
(1, 'Nueva orden', 1),
(2, 'Orden recibida', 1),
(3, 'Orden en preparación', 1),
(4, 'Orden lista', 1),
(5, 'Orden pagada', 1);

-- Llenando la tabla Tb_HccMesas
INSERT INTO Tb_HccMesas (mes_id, mes_lugares, mes_disponible, mes_estatus) VALUES
(1, 4, 1, 1),
(2, 6, 1, 1),
(3, 2, 1, 1),
(4, 8, 1, 1),
(5, 3, 1, 1),
(6, 5, 1, 1),
(7, 4, 1, 1);

-- Llenando la tabla Tb_HccProductos
INSERT INTO Tb_HccProductos (pro_id, alm_id, pro_nombre, pro_descripcion, pro_precio, pro_estatus) VALUES
(1, 1, 'Café Americano', 'Café negro sin azúcar', 2.50, 1),
(2, 2, 'Café Latte', 'Café con leche y un toque de espuma', 3.00, 1),
(3, 3, 'Cappuccino', 'Café con leche y espuma de leche', 3.50, 1),
(4, 4, 'Expresso Doble', 'Doble tiro de café negro', 4.00, 1),
(5, 5, 'Mocha', 'Café con chocolate y crema batida', 4.50, 1),
(6, 6, 'Té Verde', 'Infusión de té verde', 2.00, 1),
(7, 7, 'Té Negro', 'Infusión de té negro', 2.00, 1);

-- Llenando la tabla Tb_HccAlmacen
INSERT INTO Tb_HccAlmacen (alm_id, alm_cantidad, alm_fecha_actualizacion, alm_estatus) VALUES
(1, 100, '2024-05-16', 1),
(2, 50, '2024-05-16', 1),
(3, 200, '2024-05-16', 1),
(4, 80, '2024-05-16', 1),
(5, 120, '2024-05-16', 1),
(6, 150, '2024-05-16', 1),
(7, 70, '2024-05-16', 1);

USE DB_CAFETERIA
SELECT * FROM Tb_HccOrdenes
SELECT * FROM Tb_HccOrdenesDetalle
SELECT * FROM Tb_HccCatEstatusOrden
SELECT * FROM Tb_HccMesas
SELECT * FROM Tb_HccProductos
SELECT * FROM Tb_HccAlmacen