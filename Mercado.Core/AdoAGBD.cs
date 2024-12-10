using et12.edu.ar.AGBD.Mapeadores;
using Mercado.Core.Ado;
using MySql.Data.MySqlClient;

namespace Mercado.Core;

public class AdoAGBD : IAdo
{
    public MapCompra(AdoAGBD ado):base(ado)
    {
        Tabla = "Compra";
    }

    public override Compra ObjetoDesdeFila(DataRow fila)
        => new Compra
        {
            IdComprador = Convert.ToInt16(fila["idComprador"]),
            IdProducto = Convert.ToUInt16(fila["idProducto"]),
            FechaHora = Convert.ToDateTime(fila["FechaHora"]),
            Cantidad = Convert.ToUInt16(fila["cantidad"]),
            Precio = Convert.ToDecimal(fila["precio"])
        };

    public void AltaCompra(Compra compra)
        => EjecutarComandoCon("altaCompra", ConfigurarAltaCompra, PostAltaCompra, compra);

    public void ConfigurarAltaCompra(Compra compra)
    {
        SetComandoSP("altaCompra");

        BP.CrearParametro("unaFechaHora")
          .SetTipoDateTime()
          .SetValor(compra.FechaHora)
          .AgregarParametro();

        BP.CrearParametro("unacantidad")
          .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
          .SetValor(compra.Cantidad)
          .AgregarParametro();

        BP.CrearParametro("unprecio")
          .SetTipoDecimal()
          .SetValor(compra.Precio)
          .AgregarParametro();

        BP.CrearParametro("unidComprador")
          .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
          .SetValor(compra.IdComprador)
          .AgregarParametro();

        BP.CrearParametro("unidProducto")
          .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
          .SetValor(compra.IdProducto)
          .AgregarParametro();
    }

    public void PostAltaCompra(Compra compra)
    {
        var paramIdComprador = GetParametro("unIdComprador");
        Comprador.ID = Convert.ToInt16(paramIdComprador.Value);
    }

       public List<Compra> ObtenerCompras() => ColeccionDesdeTabla();   
    }

    public void AltaProducto(Producto producto)
    {

    }

    public void AltaUsuario(Usuario usuario)
    {

    }

    public List<Compra> ObtenerCompras()
    {

    }

    public List<Producto> ObtenerProductos()
    {

    }

    public List<Usuario> ObtenerUsuarios()
    {
        
        }
}
