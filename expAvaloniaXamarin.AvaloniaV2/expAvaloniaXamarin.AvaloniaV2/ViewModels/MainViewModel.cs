namespace expAvaloniaXamarin.AvaloniaV2.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";
}

public class ListingViewModel : ViewModelBase
{
    public string Price { get; set; } = "$ 1,000,200";

    public string Address { get; set; } = "1234 Main St, Anytown, USA";

    public string[] Images { get; set; } = new string[] { "https://via.placeholder.com/150", "https://via.placeholder.com/151", "https://via.placeholder.com/152" };

    public string[] Items { get; set; } = new string[] { "Item 1", "Item 2", "Item 3" };

}