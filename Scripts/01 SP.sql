DELIMITER $$

-- SP para dar de alta un usuario
CREATE PROCEDURE altaUsuario (
    unnombre VARCHAR(50),
    unapellido VARCHAR(50),
    untelefono INT,
    unemail VARCHAR(50),
    unidUsuario SMALLINT,
    unpass CHAR(64)
)
BEGIN
    INSERT INTO Usuario (nombre, apellido, telefono, email, idUsuario, pass)
    VALUES (unnombre, unapellido, untelefono, unemail, unidUsuario, unpass);
END $$

-- SP para dar de alta un producto
CREATE PROCEDURE altaProducto (
    unprecio DECIMAL(10,2),
    unacantidad SMALLINT UNSIGNED,
    unnombre VARCHAR(50),
    unidVendedor SMALLINT,
    unafecha DATE,
    unidProducto SMALLINT UNSIGNED
)
BEGIN
    INSERT INTO Producto (precio, cantidad, nombre, idVendedor, fecha, idProducto)
    VALUES (unprecio, unacantidad, unnombre, unidVendedor, unafecha, unidProducto);
END $$

-- SP para dar de alta una compra
CREATE PROCEDURE altaCompra (
    unaFechaHora DATETIME,
    unacantidad SMALLINT UNSIGNED,
    unprecio DECIMAL(10,2),
    idComprador SMALLINT,
    idProducto SMALLINT UNSIGNED
)
BEGIN
    INSERT INTO Compra (FechaHora, cantidad, precio, idComprador, idProducto)
    VALUES (unaFechaHora, unacantidad, unprecio, idComprador, idProducto);
END $$

-- Función recaudacionPara
CREATE FUNCTION recaudacionPara (
    unidProducto SMALLINT UNSIGNED,
    unaFecha DATE,
    otraFecha DATE
) RETURNS DECIMAL(10,2)
BEGIN
    DECLARE Recaudacion DECIMAL(10,2);

    SELECT SUM(cantidad * precio) INTO Recaudacion
    FROM Compra
    WHERE idProducto = unidProducto
    AND FechaHora BETWEEN unaFecha AND otraFecha;
    
    RETURN IFNULL(Recaudacion, 0);
END $$

-- SP para buscar productos por nombre
CREATE PROCEDURE BuscarProducto (
    unNombre VARCHAR(50))
BEGIN
    SELECT *
    FROM Producto
    WHERE MATCH(nombre) AGAINST (unNombre IN NATURAL LANGUAGE MODE);
END $$

-- SP para obtener las ventas de un usuario (comprador)
CREATE PROCEDURE VentasDe (
    idUsuario SMALLINT)
BEGIN
    SELECT *
    FROM Compra
    WHERE idComprador = idUsuario
    ORDER BY FechaHora DESC;
END $$

-- SP para obtener las compras de un usuario (vendedor)
CREATE PROCEDURE ComprasDe (
    idUsuario SMALLINT)
BEGIN
    SELECT *
    FROM Compra
    WHERE idComprador = idUsuario
    ORDER BY FechaHora DESC;
END $$

DELIMITER $$