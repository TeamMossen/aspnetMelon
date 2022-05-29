namespace aspnetMelon.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public string CurrentCategory { get; set; }

    }
}
