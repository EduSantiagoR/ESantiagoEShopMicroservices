using Microsoft.EntityFrameworkCore;

namespace ProductoService.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Detalles { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (Data.StoreContext context = new Data.StoreContext())
                {
                    var query = (from producto in context.Productos
                                 select new
                                 {
                                     IdProducto = producto.IdProducto,
                                     Nombre = producto.Nombre,
                                     Detalles = producto.Detalles,
                                     Precio = producto.Precio,
                                     Stock = producto.Stock
                                 }).ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            Producto producto = new Producto();
                            producto.IdProducto = item.IdProducto;
                            producto.Nombre = item.Nombre;
                            producto.Detalles = item.Detalles;
                            producto.Precio = item.Precio;
                            producto.Stock = item.Stock;

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Error al recuperar los productos.";
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
        public static Result GetById(int idProducto)
        {
            Result result = new Result();
            try
            {
                using (Data.StoreContext _context = new Data.StoreContext())
                {
                    var query = (from producto in _context.Productos
                                 where producto.IdProducto == idProducto
                                 select new
                                 {
                                     IdProducto = producto.IdProducto,
                                     Nombre = producto.Nombre,
                                     Detalles = producto.Detalles,
                                     Precio = producto.Precio,
                                     Stock = producto.Stock
                                 }).AsEnumerable().FirstOrDefault();
                    if (query != null)
                    {
                        Producto producto = new Producto();
                        producto.IdProducto = query.IdProducto;
                        producto.Nombre = query.Nombre;
                        producto.Detalles = query.Detalles;
                        producto.Precio = query.Precio;
                        producto.Stock = query.Stock;

                        result.Objeto = producto;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "Producto no encontrado.";
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
        public static Result Add(Producto producto)
        {
            Result result = new Result();
            try
            {
                using(Data.StoreContext context = new Data.StoreContext())
                {
                    int rowsAffected = context.Database.ExecuteSqlRaw($"ProductoAdd '{producto.Nombre}', '{producto.Detalles}',{producto.Precio},{producto.Stock}");
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                        result.Message = "Producto agregado correctamente.";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al agregar el producto.";
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
        public static Result Update(Producto producto)
        {
            Result result = new Result();
            try
            {
                using(Data.StoreContext context = new Data.StoreContext())
                {
                    int rowsAffected = context.Database.ExecuteSqlRaw($"ProductoUpdate {producto.IdProducto}, '{producto.Nombre}', '{producto.Detalles}', {producto.Precio}, {producto.Stock}");
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                        result.Message = "Producto actualizado correctamente.";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al tratar de actualizar el producto.";
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
        public static Result Delete(int idProducto)
        {
            Result result = new Result();
            try
            {
                using (Data.StoreContext context = new Data.StoreContext())
                {
                    int rowsAffected = context.Database.ExecuteSqlRaw($"ProductoDelete {idProducto}");
                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                        result.Message = "Producto eliminado correctamente.";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Error al tratar de eliminar el producto.";
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
