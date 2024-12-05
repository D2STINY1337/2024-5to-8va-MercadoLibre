namespace Mercado.Core;

public class Usuario
{
    public int IdUsuario { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Telefono { get; set; }
    public string Email { get; set; }
    public string Pass { get; set; }
    public override string ToString()
        => $"ID: {IdUsuario}, Nombre: {Nombre} {Apellido}, Email: {Email}, Teléfono: {Telefono}";
}

