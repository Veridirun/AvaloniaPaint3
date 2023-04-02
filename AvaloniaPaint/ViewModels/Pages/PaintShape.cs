using AvaloniaPaint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaPaint.ViewModels.Pages
{
    public abstract class PaintShape : ViewModelBase
    {
        public abstract string ViewName { get; }
        public abstract PaintBaseFigure? GetShape();
        public abstract Unit ClearShape();
    }
}
