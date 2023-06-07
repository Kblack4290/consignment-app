namespace ConsignmentApi.Models;

public class ConsignmentFormDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string ConsignmentFormCollectionName { get; set; } = null!;


    public string UserCollectionName { get; set; } = null!;
}