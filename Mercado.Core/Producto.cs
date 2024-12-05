namespace Mercado.Core;

public class Producto
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public decimal Precio { get; set; }
        public ushort Cantidad { get; set; }
        public string Nombre { get; set; }
        public int IdVendedor { get; set; }
        public DateTime Fecha { get; set; }
        public Usuario Vendedor { get; set; }
        public override string ToString()
        {
            return $"ID: {IdProducto}, Nombre: {Nombre}, Precio: {Precio}, Cantidad: {Cantidad}, Fecha: {Fecha}";
        }
    }
}
