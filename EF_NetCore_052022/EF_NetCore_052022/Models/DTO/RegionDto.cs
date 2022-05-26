namespace EF_NetCore_052022.Models.DTO
{
    public class RegionDto
    {
        public Guid IdDto { get; set; }
        public string NameDto { get; set; }
        public string Code { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }
    }
}
