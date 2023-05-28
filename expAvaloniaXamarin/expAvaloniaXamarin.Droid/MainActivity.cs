using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Avalonia;
using Avalonia.Android;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using expAvaloniaXamarin.AvaloniaV2;
using Application = Android.App.Application;

namespace expAvaloniaXamarin.Droid;

[Activity(Theme = "@style/MainTheme", MainLauncher = true, NoHistory = true)]
public class SplashActivity : AvaloniaSplashActivity<AvaloniaApp>
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return base.CustomizeAppBuilder(builder)
            .WithInterFont()
            .UseReactiveUI();
    }

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
    }

    protected override void OnResume()
    {
        base.OnResume();
        StartActivity(new Intent(Application.Context, typeof(MainActivity)));
    }
}

[Activity(Label = "expAvaloniaXamarin", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
{
    public static MainActivity Instance { get; private set; }
    
    protected override void OnCreate(Bundle savedInstanceState)
    {
        Instance = this;
        
        TabLayoutResource = Resource.Layout.Tabbar;
        ToolbarResource = Resource.Layout.Toolbar;

        base.OnCreate(savedInstanceState);
        XamarinBackgroundKit.Android.BackgroundKit.Init();
        global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

        LoadApplication(new App());
    }
}