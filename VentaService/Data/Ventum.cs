using System;
using System.Collections.Generic;

namespace VentaService.Data;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
