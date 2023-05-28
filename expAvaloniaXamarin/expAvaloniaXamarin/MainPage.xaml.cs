using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using DynamicData;
using expAvaloniaXamarin.AvaloniaV2.Components;
using expAvaloniaXamarin.AvaloniaV2.ViewModels;
using expAvaloniaXamarin.Core;
using Xamarin.Forms;

namespace expAvaloniaXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ListingViewModel();
        }

        private void CreateAvalonia(object sender, EventArgs e)
        {
            var items = CreateItems();
            var chips = items.Select(o => new AvaloniaHost { Content = new AvaloniaChips { Items = o} }).ToArray();
            var layout = new StackLayout();
            layout.Children.AddRange(chips);

            var scroll = new ScrollView()
            {
                Content =  layout 
            };

            ContentP.Content = scroll;
        }

        private void CreateForms(object sender, EventArgs e)
        {
            var items = CreateItems();

            var chips = items.Select(o => new FormsChips { Items = o }).ToArray();
            var layout = new StackLayout();
            layout.Children.AddRange(chips);

            var scroll = new ScrollView
            {
                Content = layout
            };

            ContentP.Content = scroll;
        }

        private string[][] CreateItems() => Enumerable.Range(0, 5).Select(o => Enumerable.Range(0, 40).Select(oo => $"Item {o}-{oo}").ToArray()).ToArray();
    }
}