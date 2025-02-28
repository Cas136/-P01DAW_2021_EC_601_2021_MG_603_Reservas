namespace P01_2021_EC_601_2021_MG_603.Models
{
    public class Sucursales
    {
        public int SucursalId { get; set; }           
        public string NombreSucursal { get; set; }       
        public string Direccion { get; set; }            
        public string Telefono { get; set; }            
        public int? AdministradorId { get; set; }        
        public int NumeroEspacios { get; set; }         

       
        public Usuarios Administrador { get; set; }
    }
}
