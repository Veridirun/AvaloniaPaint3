using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaPaint.Models.Serializer;
using AvaloniaPaint.ViewModels;
using AvaloniaPaint.Views;

namespace AvaloniaPaint
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel()
                    {
                        SaverLoaderFactoryCollection = new ISaverLoaderFactory[]
                        {
                            new XMLSaverLoaderFactory(),
                            new JSONSaverLoaderFactory(),
                        }
                    }
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
