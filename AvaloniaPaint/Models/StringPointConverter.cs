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
    public class StringPointConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string stringPoint)
            {
                string[] coords = stringPoint.Split(',');
                
                if (coords.Length == 2)
                {
                    int coordX;
                    int coordY;
                    if (int.TryParse(coords[0], out coordX) == true &&
                        int.TryParse(coords[1], out coordY) == true)
                    {
                        return new Point(coordX, coordY);
                    }
                }
            }

            return new Point(0, 0);
        }
    }
}
