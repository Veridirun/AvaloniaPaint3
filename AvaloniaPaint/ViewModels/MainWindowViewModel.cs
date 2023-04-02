using Microsoft.CodeAnalysis.Operations;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using AvaloniaPaint.ViewModels.Pages;
using AvaloniaPaint.Models;
using System.Reactive;
using static System.Net.Mime.MediaTypeNames;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using AvaloniaPaint.Models.Serializer;
using System.Linq;

namespace AvaloniaPaint.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        int selectedFigureIndex;
        public int SelectedFigureIndex
        {
            set 
            { 
                this.RaiseAndSetIfChanged(ref selectedFigureIndex, value);
                Content = vmbaseCollection[selectedFigureIndex];
            }
            get => selectedFigureIndex;
        }
        private ObservableCollection<PaintShape> vmbaseCollection;

        public ObservableCollection<PaintShape> VmbaseCollection
        {
            get
            {
                return vmbaseCollection;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref  vmbaseCollection, value);
            }
        }

        private PaintShape content;
        public PaintShape Content
        {
            get => content;
            set
            {
                this.RaiseAndSetIfChanged(ref content, value);
            }
        }
        private ObservableCollection<PaintBaseFigure> figureCollection;
        public ObservableCollection<PaintBaseFigure> FigureCollection
        {
            get => figureCollection;
            set
            {
                this.RaiseAndSetIfChanged(ref figureCollection, value);
            }
        }


        public MainWindowViewModel()
        {
            PaintBaseFigure viewModelParams = new PaintBaseFigure();
            selectedFigureIndex = 0;
            vmbaseCollection = new ObservableCollection<PaintShape>();
            vmbaseCollection.Add(new AvaloniaPaintLineViewModel());
            vmbaseCollection.Add(new AvaloniaPaintPolylineViewModel());
            vmbaseCollection.Add(new AvaloniaPaintPolygonViewModel());
            vmbaseCollection.Add(new AvaloniaPaintRectangleViewModel());
            vmbaseCollection.Add(new AvaloniaPaintEllipseViewModel());
            vmbaseCollection.Add(new AvaloniaPaintPathViewModel());
            content = vmbaseCollection[0];

            figureCollection = new ObservableCollection<PaintBaseFigure>();
           
            buttonAdd = ReactiveCommand.Create<Unit, PaintBaseFigure>(_ =>
            {
                var figure = Content.GetShape();
                if(figure != null)
                    FigureCollection.Add(figure);
                return viewModelParams;
            });

            buttonClear = ReactiveCommand.Create<Unit, Unit>(_ => Content.ClearShape());

            buttonRemove = ReactiveCommand.Create<PaintBaseFigure, Unit>(figure =>
            {
                FigureCollection.Remove(figure);
 //               System.Diagnostics.Debug.WriteLine("Removed\n");
                return Unit.Default;
            });
        }

        public ReactiveCommand<Unit, PaintBaseFigure> buttonAdd { get; }
        public ReactiveCommand<Unit, Unit> buttonClear { get; }
        public ReactiveCommand<PaintBaseFigure, Unit> buttonRemove { get; }
        
        public IEnumerable<ISaverLoaderFactory> SaverLoaderFactoryCollection { get; set; }
        public void SaveFigures(string path)
        {
            IShapeSaver? figureSaver = SaverLoaderFactoryCollection
                .FirstOrDefault(factory => factory.IsMatch(path) == true)?
                .CreateSaver();
            if (figureSaver != null)
            {
                figureSaver.Save(FigureCollection, path);
            }
        }
        public void LoadFigures(string path)
        {
            figureCollection = null;
            figureCollection = new ObservableCollection<PaintBaseFigure>();


            IShapeLoader? figureLoader = SaverLoaderFactoryCollection
                .FirstOrDefault(factory => factory.IsMatch(path) == true)?
                .CreateLoader();
            if (figureLoader != null)
            {
               FigureCollection = figureLoader.Load(FigureCollection, path);
            }
        }
    }
}
