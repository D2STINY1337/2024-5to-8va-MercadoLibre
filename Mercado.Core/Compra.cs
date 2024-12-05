namespace Mercado.Core;

public class Compra
{
    public int IdComprador { get; set; }
    public int IdProducto { get; set; }
    public DateTime FechaHora { get; set; }
    public ushort Cantidad { get; set; }
    public decimal Precio { get; set; }

    public Usuario Comprador { get; set; }
    public Producto Producto { get; set; }

    public override string ToString()
        => $"Comprador ID: {IdComprador}, Producto ID: {IdProducto}, Fecha: {FechaHora}, Cantidad: {Cantidad}, Precio Total: {Cantidad * Precio}";
}




