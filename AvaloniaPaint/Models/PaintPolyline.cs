using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaPaint.Models
{
    public class PaintPolyline : PaintBaseFigure
    {
        private List<Point> points;
        public List<Point> Points
        {
            get => points;
            set => points = value;
        }
    }
}
