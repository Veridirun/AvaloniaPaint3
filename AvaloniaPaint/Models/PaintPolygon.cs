using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Media;

namespace AvaloniaPaint.Models
{
    public class PaintPolygon : PaintBaseFigure
    {
        private List<Point> points;
        public List<Point> Points
        {
            get => points;
            set => points = value;
        }

        private Color fillColor;
        public Color FillColor
        {
            get => fillColor;
            set => fillColor = value;
        }
    }
}
