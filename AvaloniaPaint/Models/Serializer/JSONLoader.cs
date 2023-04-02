using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaPaint.Models.Serializer
{
    public class JSONLoader : IShapeLoader
    {
        public ObservableCollection<PaintBaseFigure> Load(ObservableCollection<PaintBaseFigure> figures, string path)
        {
            var figuresJsontext = File.ReadAllText(path);

            var objects = JsonConvert.DeserializeObject<List<PaintBaseFigure>>(figuresJsontext,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All,
                        Formatting = Formatting.Indented
                    });
            ObservableCollection <PaintBaseFigure> figuresList =
                new ObservableCollection<PaintBaseFigure>(objects);


            return figuresList;
        }

        
    }
}
