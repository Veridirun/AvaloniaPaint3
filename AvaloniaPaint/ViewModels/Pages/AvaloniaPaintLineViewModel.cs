using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Media;
using AvaloniaPaint.Models;
using ReactiveUI;
using SkiaSharp;

namespace AvaloniaPaint.ViewModels.Pages
{
    public class AvaloniaPaintLineViewModel : PaintShape
    {
        public override string ViewName => "Прямая линия";

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
        private Point startLinePoint;
        public Point StartLinePoint
        {
            get => startLinePoint;
            set
            {
                this.RaiseAndSetIfChanged(ref startLinePoint, value);
            }
        }
        private Point endPoint;
        public Point EndPoint
        {
            get => endPoint;
            set
            {
                this.RaiseAndSetIfChanged(ref endPoint, value);
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

        private ObservableCollection<ISolidColorBrush> fillColors;

        public ObservableCollection<ISolidColorBrush> FillColors
        {
            get => fillColors;
            set
            {
                this.RaiseAndSetIfChanged(ref fillColors, value);
            }
        }
        public AvaloniaPaintLineViewModel()
        {
            Name = "";
            StartLinePoint = new Point(0, 0);
            EndPoint = new Point(0, 0);
            StrokeThickness = 1;
            selectedColor = new SolidColorBrush(Colors.White);

            RotateAngle = 0;
            Skew = new Point(0, 0);
            Scale = new Point(1, 1);
            RotateCenter = new Point(0, 0);

            var brushes = typeof(Brushes).GetProperties().Select(brush => (ISolidColorBrush)brush.GetValue(brush));
            fillColors = new ObservableCollection<ISolidColorBrush>(brushes);
        }

        public override PaintBaseFigure? GetShape()
        {
            if(Name!="")
                if (StartLinePoint.Y != 0 || StartLinePoint.X != 0 || EndPoint.X != 0 || EndPoint.Y != 0)
                    return new PaintLine()
                    {
                        Name = Name,
                        StartLinePoint = StartLinePoint,
                        EndPoint = EndPoint,
                        Stroke = SelectedColor.Color,
                        StrokeThickness = StrokeThickness,

                        Skew = Skew,
                        RotateAngle = RotateAngle,
                        RotateCenter = RotateCenter,
                        Scale = Scale,
                    };
            return null;
        }
        public override Unit ClearShape()
        {
            Name = "";
            StartLinePoint = new Point(0, 0);
            EndPoint = new Point(0, 0);
            SelectedColor = new SolidColorBrush(Colors.White);
            StrokeThickness = 1;

            RotateAngle = 0;
            Skew = new Point(0, 0);
            Scale = new Point(1, 1);
            RotateCenter = new Point(0, 0);

            return Unit.Default;
        }
    }
}
