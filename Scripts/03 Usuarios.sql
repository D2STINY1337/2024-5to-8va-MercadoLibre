-- Creacion de usuarios

-- Administrador
DROP USER IF EXISTS 'Administrador'@'%';
CREATE USER 'Administrador'@'%' IDENTIFIED BY 'passAdmin';
GRANT ALL ON Mercadolibre.* TO 'Administrador'@'%';

-- SistemaUsuario
DROP USER IF EXISTS 'SistemaUsuario'@'10.3.45.%';
CREATE USER 'SistemaUsuario'@'10.3.45.%' IDENTIFIED BY 'passSistemas';
GRANT SELECT, INSERT, UPDATE ON Mercadolibre.Usuario TO 'SistemaUsuario'@'10.3.45.%';
GRANT UPDATE (pass) ON Mercadolibre.Usuario TO 'SistemaUsuario'@'10.3.45.%';
GRANT SELECT, INSERT ON Mercadolibre.Producto TO 'SistemaUsuario'@'10.3.45.%';
GRANT UPDATE (precio, cantidad) ON Mercadolibre.Producto TO 'SistemaUsuario'@'10.3.45.%';

-- Usuario
DROP USER IF EXISTS 'Usuario'@'%';
CREATE USER 'Usuario'@'%' IDENTIFIED BY 'passUsuario';
GRANT SELECT ON Mercadolibre.Usuario TO 'Usuario'@'%';
GRANT SELECT ON Mercadolibre.Producto TO 'Usuario'@'%';
GRANT SELECT ON Mercadolibre.Compra TO 'Usuario'@'%';


