using Microsoft.EntityFrameworkCore;

namespace VentaService.Models
{
    public class Venta
    {
        public int? IdVenta { get; set; }
        public Producto Producto { get; set; }
        public DateTime? Fecha { get; set; }

        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using(Data.StoreContext context = new Data.StoreContext())
                {
                    var query = (from venta in context.Venta
                                 join producto in context.Productos on venta.IdProducto equals producto.IdProducto
                                 select new
                                 {
                                     IdVenta = venta.IdVenta,
                                     IdProducto = producto.IdProducto,
                                     Nombre = producto.Nombre,
                                     Detalles = producto.Detalles,
                                     Precio = producto.Precio,
                                     Cantidad = venta.Cantidad,
                                     Fecha = venta.Fecha
                                 }).ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            Venta venta = new Venta();
                            venta.Producto = new Producto();

                            venta.IdVenta = item.IdVenta;
                            venta.Producto.IdProducto = item.IdProducto;
                            venta.Producto.Nombre = item.Nombre;
                            venta.Producto.Detalles = item.Detalles;
                            venta.Producto.Precio = item.Precio;
                            venta.Producto.Cantidad = item.Cantidad;
                            venta.Fecha = item.Fecha;

                            result.Objects.Add(venta);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al recuperar las ventas.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static Result Add(Producto producto)
        {
            Result result = new Result();
            try
            {
                using(Data.StoreContext context = new Data.StoreContext())
                {
                    int rowsAffected = context.Database.ExecuteSqlRaw($"VentaAdd {producto.IdProducto}, {producto.Cantidad}");
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                        result.Message = "Venta registrada correctamente.";
                    }
                    else
                    {
                        result.Message = "Error al registrar la venta.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static Result Delete(int idVenta)
        {
            Result result = new Result();
            try
            {
                using(Data.StoreContext context = new Data.StoreContext())
                {
                    int rowsAffected = context.Database.ExecuteSqlRaw($"VentaDelete {idVenta}");
                    if( rowsAffected > 0)
                    {
                        result.Correct = true;
                        result.Message = "Venta eliminada correctamente.";
                    }
                    else
                    {
                        result.Message = "Error al eliminar la venta.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
