using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace expAvaloniaXamarin.AvaloniaV2.Listings;

public partial class ListingDetailsPreview : UserControl
{
    public ListingDetailsPreview()
    {
        InitializeComponent();

        PrevB.Click += PrevB_Click;
        NextB.Click += NextB_Click;
    }

    private void PrevB_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e) => this.Carusell.Previous();
    private void NextB_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e) => this.Carusell.Next();
}