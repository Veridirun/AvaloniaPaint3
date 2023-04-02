using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AvaloniaPaint.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;


namespace AvaloniaPaint.Models.Serializer
{
    public class JSONSaver : IShapeSaver
    {
        public void Save(IEnumerable<PaintBaseFigure> figures, string path)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            string output = string.Empty;
            output = JsonConvert.SerializeObject(figures.ToList(), 
                new JsonSerializerSettings { 
                    TypeNameHandling = TypeNameHandling.All,
                    Formatting = Formatting.Indented });
            
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(output);
            }
        }
    }
}
