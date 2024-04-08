using System;
using System.Collections.Generic;

namespace PruebaEntity.-Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Categoria { get; set; }

    public double? Precio { get; set; }

    public DateTime? Fecha { get; set; }
}
