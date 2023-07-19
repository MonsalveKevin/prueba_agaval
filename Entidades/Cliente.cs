namespace Entidades
{
    public class Cliente
    {
        public Guid IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Identificacion { get; set; }
        public string TipoPersona { get; set; }
        public Guid IdTipoPersona { get; set; }
    }
}
