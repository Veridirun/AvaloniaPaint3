using Avalonia;
using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaPaint.Converters
{
    public class StringPointsConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is String stringPoints)
            {
                string[] stringPoint = stringPoints.Split(' ');
                List<Point> points = new List<Point>();

                foreach(string i in stringPoint)
                {
                    string[] coords = i.Split(',');
                    if (coords.Length == 2)
                    {
                        int coordX;
                        int coordY;
                        if (int.TryParse(coords[0], out coordX) == true &&
                            int.TryParse(coords[1], out coordY) == true)
                        {
                            points.Add(new Point(coordX, coordY));
                        }
                    }
                }
                return points;
                
            }
            return null;
        }
    }
}
