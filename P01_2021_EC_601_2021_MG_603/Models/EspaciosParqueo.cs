namespace P01_2021_EC_601_2021_MG_603.Models
{
    public class EspaciosParqueo
    {
        public int EspacioId { get; set; }
        public string NumeroEspacio { get; set; }
        public string Ubicacion { get; set; }
        public decimal CostoHora { get; set; }
        public string Estado { get; set; }
        public int SucursalId { get; set; }
        public Sucursales Sucursal { get; set; }
    }
}
