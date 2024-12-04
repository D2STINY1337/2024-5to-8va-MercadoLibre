DELIMITER $$

-- Verificar stock antes de realizar la compra
CREATE TRIGGER beforeCompraInsert
BEFORE INSERT ON Compra
FOR EACH ROW
BEGIN
    DECLARE stockDisponible SMALLINT;

    SELECT cantidad INTO stockDisponible
    FROM Producto
    WHERE idProducto = NEW.idProducto;

    IF stockDisponible < NEW.cantidad THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Unidades Insuficientes';
    END IF;
END $$

-- Actualizar el stock después de realizar la compra
CREATE TRIGGER afterCompraInsert
AFTER INSERT ON Compra
FOR EACH ROW
BEGIN
    UPDATE Producto
    SET cantidad = cantidad - NEW.cantidad
    WHERE idProducto = NEW.idProducto;
END $$

DELIMITER $$
