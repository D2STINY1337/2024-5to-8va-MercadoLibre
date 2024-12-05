namespace Mercado.Core.Ado;

public interface IAdo
{
    // Acciones para la entidad Usuario
    void AltaUsuario(Usuario usuario);
    List<Usuario> ObtenerUsuarios();

    // Acciones para la entidad Producto
    void AltaProducto(Producto producto);
    List<Producto> ObtenerProductos();

    // Acciones para la entidad Compra
    void AltaCompra(Compra compra);
    List<Compra> ObtenerCompras();
}