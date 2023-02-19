namespace ProjectCars.Models
{
    public class OwnerDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string OwnerCollectionName { get; set; } = null!;
    }
}
