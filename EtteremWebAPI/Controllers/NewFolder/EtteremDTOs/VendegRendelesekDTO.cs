namespace EtteremWebAPI.Controllers.NewFolder.EtteremDTOs
{
    public class VendegRendelesekDTO
    {
        public string Name { get; set; }
        public List<RendelesReszletDTO> Orders { get; set; } = new List<RendelesReszletDTO>();
    }
}
