using Microsoft.AspNetCore.Mvc;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        // Lista de productos simulada en memoria
        private static List<Producto> productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Notebook", Precio = 799.99M, Disponible = true },
            new Producto { Id = 2, Nombre = "Mouse", Precio = 19.99M, Disponible = true },
            new Producto { Id = 3, Nombre = "Teclado", Precio = 49.99M, Disponible = false }
        };

        // GET /productos
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            return Ok(productos);
        }

        // GET /productos/{id}
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        // POST /productos
        [HttpPost]
        public IActionResult Crear([FromBody] Producto nuevoProducto)
        {
            nuevoProducto.Id = productos.Count + 1;
            productos.Add(nuevoProducto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoProducto.Id }, nuevoProducto);
        }

        // PUT /productos/{id}
        [HttpPut("{id}")]
        public IActionResult Editar(int id, [FromBody] Producto productoEditado)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
                return NotFound();

            producto.Nombre = productoEditado.Nombre;
            producto.Precio = productoEditado.Precio;
            producto.Disponible = productoEditado.Disponible;

            return NoContent(); // 204 OK sin contenido
        }

        // DELETE /productos/{id}
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
                return NotFound();

            productos.Remove(producto);
            return NoContent(); // 204 OK sin contenido
        }
    }
}