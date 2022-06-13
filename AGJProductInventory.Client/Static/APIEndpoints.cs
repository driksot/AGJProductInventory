namespace AGJProductInventory.Client.Static
{
    internal static class APIEndpoints
    {
#if DEBUG
        internal const string ServerBaseUrl = "https://localhost:7115";
#else
        internal const string ServerBaseUrl = "https://derricksouthworthserver.azurewebsites.net";
#endif

        internal readonly static string s_products = $"{ServerBaseUrl}/api/products";
        internal readonly static string s_productVariations = $"{ServerBaseUrl}/api/productvariations";
        internal readonly static string s_categories = $"{ServerBaseUrl}/api/categories";
        internal readonly static string s_categoriesWithProducts = $"{ServerBaseUrl}/api/categories/withproducts";
        internal readonly static string s_customers = $"{ServerBaseUrl}/api/customers";
        internal readonly static string s_fileUpload = $"{ServerBaseUrl}/api/files";
    }
}
