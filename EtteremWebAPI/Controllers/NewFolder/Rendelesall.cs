namespace EtteremWebAPI.Controllers.NewFolder
{
    public class Rendelesall
    {
        public int Id { get; set; }
        public string Dish { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime OrderTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int VendegId { get; set; }
    }
}
