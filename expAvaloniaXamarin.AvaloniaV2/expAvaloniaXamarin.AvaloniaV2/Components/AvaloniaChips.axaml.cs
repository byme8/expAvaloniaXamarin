using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace expAvaloniaXamarin.AvaloniaV2.Components;

public partial class AvaloniaChips : UserControl
{
    public static StyledProperty<string[]> ItemsProperty = AvaloniaProperty.Register<AvaloniaChips, string[]>(nameof(Items));

    public string[] Items
    {
        get => GetValue<string[]>(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    public AvaloniaChips()
    {
    }
}