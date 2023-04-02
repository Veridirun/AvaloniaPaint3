using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaPaint.Models
{
    public class PaintLine : PaintBaseFigure
    {
        
        private Point startLinePoint;
        public Point StartLinePoint
        {
            get => startLinePoint;
            set => startLinePoint = value;
        }
        

        private Point endPoint;
        public Point EndPoint
        {
            get => endPoint;
            set => endPoint = value;
        }

    }
}
