namespace ESourcingProducts.Settings
{
    public interface IProductDataBaseSettings
    {
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
