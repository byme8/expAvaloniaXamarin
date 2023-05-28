using System;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Avalonia;
using Avalonia.Android;
using Avalonia.Controls;
using Avalonia.Controls.Embedding;
using Avalonia.Controls.Platform;
using Avalonia.Platform;
using Avalonia.Rendering;
using expAvaloniaXamarin.Core;
using expAvaloniaXamarin.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Application = Android.App.Application;
using Color = Android.Graphics.Color;
using Rect = Avalonia.Rect;
using Size = Xamarin.Forms.Size;
using Switch = Android.Widget.Switch;
using View = Xamarin.Forms.View;

[assembly: ExportRenderer(typeof(AvaloniaHost), typeof(AvaloniaHostRenderer))]

namespace expAvaloniaXamarin.Droid.Renderers;

public class AvaloniaHostRenderer : ViewRenderer<AvaloniaHost, AvaloviaXamarinView>
{
    protected override AvaloviaXamarinView CreateNativeControl()
    {
        var avaloviaXamarinView = new AvaloviaXamarinView(Context);
        return avaloviaXamarinView;
    }

    protected override void OnElementChanged(ElementChangedEventArgs<AvaloniaHost> e)
    {
        if (e.NewElement != null)
        {
            var control = CreateNativeControl();
            control.AvaloniaAndroidView.Content = e.NewElement.Content;
            if (control.AvaloniaAndroidView.Content is Control avaloniaControl)
            {
                avaloniaControl.SizeChanged += (sender, args) =>
                {
                    control.Invalidate();
                };
                avaloniaControl.DataContext = e.NewElement.BindingContext;
                AvaloniaControl = avaloniaControl;
            }

            SetNativeControl(control);
        }
    }

    public Control AvaloniaControl
    {
        get;
        set;
    }

    protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == AvaloniaHost.ContentProperty.PropertyName)
        {
            Control.AvaloniaAndroidView.Content = Element.Content;
        }

        if (e.PropertyName == nameof(AvaloniaHost.BindingContext))
        {
            if (Control.AvaloniaAndroidView.Content is StyledElement element)
            {
                element.DataContext = Element.BindingContext;
            }
        }
    }

    public override void Invalidate()
    {
        AvaloniaControl.InvalidateMeasure();
    }

    public override void InvalidateDrawable(Drawable drawable)
    {
        AvaloniaControl.InvalidateVisual();
    }

    protected override Size MinimumSize()
    {
        var size = AvaloniaControl.DesiredSize;
        return new Size(size.Width, size.Height);
    }

    public override SizeRequest GetDesiredSize(int widthConstraint, int heightConstraint)
    {
        var scale = Context.Resources.DisplayMetrics.Density;
        var widthSpecSize = MeasureDimension(widthConstraint) / scale;
        var heightSpecSize = MeasureDimension(heightConstraint) / scale;

        AvaloniaControl.Arrange(new Rect(0, 0, widthSpecSize, heightSpecSize));
        AvaloniaControl.Measure(new Avalonia.Size(widthSpecSize, heightSpecSize));
        var size = AvaloniaControl.DesiredSize;

        var sizeWidth = (int)(size.Width * scale);
        var sizeHeight = (int)(size.Height * scale);
        base.GetDesiredSize(sizeWidth, sizeHeight);

        return new SizeRequest(new Size(sizeWidth, sizeHeight));
    }

    public int MeasureDimension(int size)
    {
        var result = 0;
        var specMode = MeasureSpec.GetMode(size);
        var specSize = MeasureSpec.GetSize(size);

        if (specSize <= 0)
        {
            return int.MaxValue;
        }

        switch (specMode)
        {

            case MeasureSpecMode.AtMost:
            case MeasureSpecMode.Exactly:
                return (int)specSize;
            case MeasureSpecMode.Unspecified:
                return int.MaxValue;
        }

        return result;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Control.AvaloniaAndroidView.Content = null;
        }
        base.Dispose(disposing);
    }

    protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
    {
        Control.Invalidate();
    }
}

public class AvaloviaXamarinView : FrameLayout
{

    protected AvaloviaXamarinView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
    {
        AddAvalonia(null);
    }

    public AvaloviaXamarinView(Context context) : base(context)
    {
        AddAvalonia(context);
    }

    public AvaloviaXamarinView(Context context, IAttributeSet? attrs) : base(context, attrs)
    {
        AddAvalonia(context);
    }

    public AvaloviaXamarinView(Context context, IAttributeSet? attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
    {
        AddAvalonia(context);
    }

    public AvaloviaXamarinView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
    {
        AddAvalonia(context);
    }

    private void AddAvalonia(Context? context)
    {
        AvaloniaAndroidView = new AvaloniaView(context ?? MainActivity.Instance);
        AvaloniaAndroidView.SetBackgroundColor(Color.Transparent);
        SetBackgroundColor(Color.Transparent);

        AddView(AvaloniaAndroidView, new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));
    }

    public AvaloniaView AvaloniaAndroidView
    {
        get;
        set;
    }

    public int MeasureDimension(int size)
    {
        var result = 0;
        var specMode = MeasureSpec.GetMode(size);
        var specSize = MeasureSpec.GetSize(size);

        if (specSize <= 0)
        {
            return int.MaxValue;
        }

        switch (specMode)
        {

            case MeasureSpecMode.AtMost:
            case MeasureSpecMode.Exactly:
                return specSize;
            case MeasureSpecMode.Unspecified:
                return int.MaxValue;
        }

        return result;
    }
}