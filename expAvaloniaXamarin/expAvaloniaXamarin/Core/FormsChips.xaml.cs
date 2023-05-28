using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Collections;
using Xamarin.Forms;

namespace expAvaloniaXamarin.Core
{
    public partial class FormsChips
    {
        public static readonly BindableProperty ItemsProperty =
            BindableProperty.Create(nameof(Items), typeof(string[]), typeof(FormsChips), propertyChanged: ItemsChanged);

        private static void ItemsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is FormsChips chips)
            {
                BindableLayout.SetItemsSource(chips, newValue as IEnumerable);
            }
        }

        public string[] Items
        {
            get => (string[])GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        public FormsChips()
        {
            InitializeComponent();
        }
    }
}