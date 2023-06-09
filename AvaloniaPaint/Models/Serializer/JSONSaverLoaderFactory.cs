﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaPaint.Models.Serializer
{
    public class JSONSaverLoaderFactory : ISaverLoaderFactory
    {
        public IShapeLoader CreateLoader()
        {
            return new JSONLoader();
        }

        public IShapeSaver CreateSaver()
        {
            return new JSONSaver();
        }

        public bool IsMatch(string path)
        {
            return ".json".Equals(Path.GetExtension(path));
        }
    }
}
