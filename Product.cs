namespace ProductsAPI
{
    public class Producto
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }
    }
}