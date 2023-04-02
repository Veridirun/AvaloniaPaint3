using Avalonia;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaPaint.Models
{
    public class PaintPath : PaintBaseFigure
    {
        private string data;
        public string Data
        {
            get => data;
            set => data = value;
        }
        private Color fillColor;
        public Color FillColor
        {
            get => fillColor;
            set => fillColor = value;
        }
    }
}
