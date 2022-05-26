namespace EF_NetCore_052022.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }
        //Navigation walkDifficulty
        public Region Region { get; set; }
        public WalkDifficulty WalkDifficultie { get; set; }
}
}
