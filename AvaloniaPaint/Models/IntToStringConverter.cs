using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Data.Converters;
using Avalonia.Media;
using System.Globalization;



    namespace AvaloniaPaint.Converters
    {
        public class IntToStringConverter : IValueConverter
        {
            public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
            {
                if (value is int num)
                {
                    return num.ToString();
                }
                return "";
            }

            public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            {
                if(value is string str)
                {
                    int num;
                    if(int.TryParse(str, out num) == true)
                    {
                        return num;
                    }
                }
                return 0;
            }
        }
    }

