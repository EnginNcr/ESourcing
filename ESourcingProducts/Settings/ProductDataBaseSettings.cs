namespace ESourcingProducts.Settings
{
    public class ProductDataBaseSettings : IProductDataBaseSettings
    {
        public string ConnectionStrings { get; set; }
        public string DataBaseName { get; set; }
        public string CollectionName { get; set; }
    }
}

