using Avalonia.Controls;
using expAvaloniaXamarin.AvaloniaV2.ViewModels;

namespace expAvaloniaXamarin.AvaloniaV2.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = new ListingViewModel();
    }
}