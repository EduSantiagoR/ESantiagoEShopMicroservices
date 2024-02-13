using System;
using System.Collections.Generic;

namespace ProductoService.Data;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string Detalles { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Stock { get; set; }
}
