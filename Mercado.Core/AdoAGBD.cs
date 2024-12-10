using Mercado.Core.Ado;

namespace Mercado.Core;

public class AdoAGBD : IAdo
{
    public void AltaCompra(Compra compra)
    {
        using var connection = new SqlConnection(_MercadoLibre);
        using var command = new SqlCommand("INSERT INTO Compra (FechaHora, cantidad, precio, idComprador, idProducto) VALUES (@fechaHora, @cantidad, @precio, @idComprador, @idProducto)", connection);
        command.Parameters.AddWithValue("@fechaHora", compra.FechaHora);
        command.Parameters.AddWithValue("@cantidad", compra.Cantidad);
        command.Parameters.AddWithValue("@precio", compra.Precio);
        command.Parameters.AddWithValue("@idComprador", compra.IdComprador);
        command.Parameters.AddWithValue("@idProducto", compra.IdProducto);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public void AltaProducto(Producto producto)
    {
        using var connection = new SqlConnection(_MercadoLibre);
        using var command = new SqlCommand("INSERT INTO Producto (idProducto, precio, cantidad, nombre, idVendedor, fecha) VALUES (@idProducto, @precio, @cantidad, @nombre, @idVendedor, @fecha)", connection);
        command.Parameters.AddWithValue("@idProducto", producto.IdProducto);
        command.Parameters.AddWithValue("@precio", producto.Precio);
        command.Parameters.AddWithValue("@cantidad", producto.Cantidad);
        command.Parameters.AddWithValue("@nombre", producto.Nombre);
        command.Parameters.AddWithValue("@idVendedor", producto.IdVendedor);
        command.Parameters.AddWithValue("@fecha", producto.Fecha);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public void AltaUsuario(Usuario usuario)
    {
        using var connection = new SqlConnection(_MercadoLibre);
        using var command = new SqlCommand("INSERT INTO Usuario (idUsuario, nombre, apellido, telefono, email, pass) VALUES (@idUsuario, @nombre, @apellido, @telefono, @email, @pass)", connection);

        command.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);
        command.Parameters.AddWithValue("@nombre", usuario.Nombre);
        command.Parameters.AddWithValue("@apellido", usuario.Apellido);
        command.Parameters.AddWithValue("@telefono", usuario.Telefono);
        command.Parameters.AddWithValue("@email", usuario.Email);
        command.Parameters.AddWithValue("@pass", usuario.Pass);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public List<Compra> ObtenerCompras()
    {
        var compras = new List<Compra>();

            using var connection = new SqlConnection(_MercadoLibre);
            using var command = new SqlCommand("SELECT * FROM Compra", connection);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                compras.Add(new Compra
                {
                    FechaHora = reader.GetDateTime("FechaHora"),
                    Cantidad = reader.GetUInt16("cantidad"),
                    Precio = reader.GetDecimal("precio"),
                    IdComprador = reader.GetInt16("idComprador"),
                    IdProducto = reader.GetUInt16("idProducto")
            });

            return compras;
    }

    public List<Producto> ObtenerProductos()
    {
       var productos = new List<Producto>();

            using var connection = new SqlConnection(_MercadoLibre);
            using var command = new SqlCommand("SELECT * FROM Producto", connection);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                productos.Add(new Producto
                {
                    IdProducto = reader.GetInt16("idProducto"),
                    Precio = reader.GetDecimal("precio"),
                    Cantidad = reader.GetUInt16("cantidad"),
                    Nombre = reader.GetString("nombre"),
                    IdVendedor = reader.GetInt16("idVendedor"),
                    Fecha = reader.GetDateTime("fecha")
                });
             }

             return productos;
    }

    public List<Usuario> ObtenerUsuarios()
    {
        var usuarios = new List<Usuario>();

            using var connection = new SqlConnection(_MercadoLibre);
            using var command = new SqlCommand("SELECT * FROM Usuario", connection);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                usuarios.Add(new Usuario
                {
                    IdUsuario = reader.GetInt16("idUsuario"),
                    Nombre = reader.GetString("nombre"),
                    Apellido = reader.GetString("apellido"),
                    Telefono = reader.GetInt32("telefono"),
                    Email = reader.GetString("email"),
                    Pass = reader.GetString("pass")
                });
            }

            return usuarios;
    }
}
