using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.VisualTree;
using AvaloniaPaint.Models;
using AvaloniaPaint.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaPaint.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddHandler(DragDrop.DropEvent, Drop);
        }

        private void Drop(object sender, DragEventArgs dragEventArgs)
        {
            if (dragEventArgs.Data.Contains(DataFormats.FileNames) == true)
            {
                string? fileName = dragEventArgs.Data.GetFileNames()?.FirstOrDefault();
                if(fileName != null)
                {
                    if(this.DataContext is MainWindowViewModel dataContext)
                    {
                        dataContext.LoadFigures(fileName);
                    }
                }
            }
        }

        private Point pointPointerPressed;
        private Point pointerPositionIntoShape;

        private void PointerPressedOnCanvas(object? sender, PointerPressedEventArgs pointerPressedEventArgs)
        {
            pointPointerPressed = pointerPressedEventArgs
                .GetPosition(
                this.GetVisualDescendants()
                .OfType<Canvas>()
                .FirstOrDefault());
            
            if(pointerPressedEventArgs.Source is Shape shape)
            {
                pointerPositionIntoShape = pointerPressedEventArgs.GetPosition(shape);
                this.PointerMoved += PointerMoveDragShape;
                this.PointerReleased += PointerPressedReleasedDragShape;
            }
        }

        private void PointerMoveDragShape(object? sender, PointerEventArgs pointerEventArgs)
        {
            if(pointerEventArgs.Source is Shape shape)
            {
                Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());

                if(shape.DataContext is PaintBaseFigure myShape)
                {
                    myShape.StartPoint = new Point(
                        currentPointerPosition.X - pointerPositionIntoShape.X,
                        currentPointerPosition.Y - pointerPositionIntoShape.Y);
                }
            }
        }
        private void PointerPressedReleasedDragShape(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (this.DataContext is MainWindowViewModel viewModel)
            {
                this.PointerMoved -= PointerMoveDragShape;
                this.PointerReleased -= PointerPressedReleasedDragShape;
            }
        }
        private async void OnExportMenuClickXML(object sender, RoutedEventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Xml files",
                    Extensions = new string[] {"xml"}.ToList()
                });

            string? path = await saveFileDialog.ShowAsync(this);

            if (path != null)
            {
                if(this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.SaveFigures(path);
                }
            }
        }
        private async void OnImportMenuClickXML(object sender, RoutedEventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Xml files",
                    Extensions = new string[] { "xml" }.ToList()
                });

            string[]? path = await openFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.LoadFigures(path[0]);
                }
            }
        }
        private async void OnExportMenuClickJSON(object sender, RoutedEventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "JSON files",
                    Extensions = new string[] { "json" }.ToList()
                });

            string? path = await saveFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.SaveFigures(path);
                }
            }
        }
        private async void OnImportMenuClickJSON(object sender, RoutedEventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "JSON files",
                    Extensions = new string[] { "json" }.ToList()
                });

            string[]? path = await openFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.LoadFigures(path[0]);
                }
            }
        }
        private async void SaveFileDialogMenuPngClick(object sender, RoutedEventArgs routedEventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "PNG files",
                    Extensions = new string[] { "png" }.ToList()
                });

            string? path = await saveFileDialog.ShowAsync(this);

            var canvas = this.GetVisualDescendants().OfType<Canvas>().Where(canvas => canvas.Name.Equals("canvas")).FirstOrDefault();
            if (path != null)
            {
                var pixelSize = new PixelSize((int)canvas.Bounds.Width, (int)canvas.Bounds.Height);
                var size = new Size(canvas.Bounds.Width, canvas.Bounds.Height);
                using (RenderTargetBitmap bitmap = new RenderTargetBitmap(pixelSize, new Avalonia.Vector(96, 96)))
                {
                    canvas.Measure(size);
                    canvas.Arrange(new Rect(size));
                    bitmap.Render(canvas);
                    bitmap.Save(path);
                }
            }
        }
    }
}
