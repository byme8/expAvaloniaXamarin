using Xamarin.Forms;

namespace expAvaloniaXamarin.Core
{
    [ContentProperty(nameof(AvaloniaHost.Content))]
    public class AvaloniaHost : View
    {
        public static readonly BindableProperty ContentProperty =
            BindableProperty.Create(nameof(Content), typeof(object), typeof(AvaloniaHost), default);

        public object Content
        {
            get => (object)GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }
    }
}