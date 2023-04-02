using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Media;
using AvaloniaPaint.Models;
using ReactiveUI;

namespace AvaloniaPaint.ViewModels.Pages
{
    public class AvaloniaPaintEllipseViewModel : PaintShape
    {
        public override string ViewName => "Эллипс";

        private int rotateAngle;
        public int RotateAngle
        {
            get => rotateAngle;
            set
            {
                this.RaiseAndSetIfChanged(ref rotateAngle, value);
            }
        }
        private Point rotateCenter;
        public Point RotateCenter
        {
            get => rotateCenter;
            set
            {
                this.RaiseAndSetIfChanged(ref rotateCenter, value);
            }
        }
        private Point scale;
        public Point Scale
        {
            get => scale;
            set
            {
                this.RaiseAndSetIfChanged(ref scale, value);
            }
        }
        private Point skew;
        public Point Skew
        {
            get => skew;
            set
            {
                this.RaiseAndSetIfChanged(ref skew, value);
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                this.RaiseAndSetIfChanged(ref name, value);
            }
        }
        private int strokeThickness;
        public int StrokeThickness
        {
            get => strokeThickness;
            set
            {
                this.RaiseAndSetIfChanged(ref strokeThickness, value);
            }
        }
        private ISolidColorBrush selectedColor;
        public ISolidColorBrush SelectedColor
        {
            get => selectedColor;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedColor, value);
            }
        }
        private ISolidColorBrush selectedFillColor;
        public ISolidColorBrush SelectedFillColor
        {
            get => selectedFillColor;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedFillColor, value);
            }
        }
        private ObservableCollection<ISolidColorBrush> fillColors;
        public ObservableCollection<ISolidColorBrush> FillColors
        {
            get => fillColors;
            set
            {
                this.RaiseAndSetIfChanged(ref fillColors, value);
            }
        }
        private int width;
        public int Width
        {
            get => width;
            set
            {
                this.RaiseAndSetIfChanged(ref width, value);
            }
        }
        private int height;
        public int Height
        {
            get => height;
            set
            {
                this.RaiseAndSetIfChanged(ref height, value);
            }
        }

        private Point startPoint;
        public Point StartPoint
        {
            get => startPoint;
            set
            {
                this.RaiseAndSetIfChanged(ref startPoint, value);
            }
        }
        public AvaloniaPaintEllipseViewModel()
        {
            Name = "";
            StrokeThickness = 1;
            selectedColor = new SolidColorBrush(Colors.White);
            selectedFillColor = new SolidColorBrush(Colors.White);
            StartPoint = new Point(0, 0);
            Width = 0;
            Height = 0;

            RotateAngle = 0;
            Skew = new Point(0, 0);
            Scale = new Point(1, 1);
            RotateCenter = new Point(0, 0);

            var brushes = typeof(Brushes).GetProperties().Select(brush => (ISolidColorBrush)brush.GetValue(brush));
            fillColors = new ObservableCollection<ISolidColorBrush>(brushes);
        }
        public override Unit ClearShape()
        {
            Name = "";
            StartPoint = new Point(0, 0);
            SelectedColor = new SolidColorBrush(Colors.White);
            SelectedFillColor = new SolidColorBrush(Colors.White);
            StrokeThickness = 1;
            Width = 0;
            Height = 0;

            RotateAngle = 0;
            Skew = new Point(0, 0);
            Scale = new Point(1, 1);
            RotateCenter = new Point(0, 0);

            return Unit.Default;
        }

        public override PaintBaseFigure GetShape()
        {
            if (Name != "")
                if (Width != 0 && Height != 0)
                    return new PaintEllipse()
                    {
                        Name = Name,
                        StartPoint = StartPoint,
                        Stroke = SelectedColor.Color,
                        FillColor = SelectedFillColor.Color,
                        StrokeThickness = StrokeThickness,
                        Width = Width,
                        Height = Height,

                        Skew = Skew,
                        RotateAngle = RotateAngle,
                        RotateCenter = RotateCenter,
                        Scale = Scale,
                    };
            return null;
        }
    }
}
