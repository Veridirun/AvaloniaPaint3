using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaPaint.Models;

namespace AvaloniaPaint.Models.Serializer
{
    public interface IShapeLoader
    {
        ObservableCollection<PaintBaseFigure> Load(ObservableCollection<PaintBaseFigure> figures, string path);
    }
}
