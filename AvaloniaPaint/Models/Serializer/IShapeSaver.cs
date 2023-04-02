using AvaloniaPaint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AvaloniaPaint.Models.Serializer
{
    public interface IShapeSaver
    {
        void Save(IEnumerable<PaintBaseFigure> figures, string path);
    }
}
